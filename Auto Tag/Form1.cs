using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TagLib;

namespace Auto_Tag
{
    public partial class Form1 : Form
    {
        BackgroundWorker SaveTagsWorker;
        BackgroundWorker ProcessWorker;

        List<string> InputList = new List<string>();
        List<string> OutputList = new List<string>();
        List<Dictionary<string, string>> OutputOperations = new List<Dictionary<string, string>>();
        public Form1()
        {
            InitializeComponent();
            
            SaveTagsWorker = new BackgroundWorker();
            SaveTagsWorker.DoWork += SaveTagsWorker_DoWork;
            SaveTagsWorker.ProgressChanged += SaveTagsWorker_ProgressChanged;
            SaveTagsWorker.RunWorkerCompleted += SaveTagsWorker_RunWorkerCompleted;
            SaveTagsWorker.WorkerReportsProgress = true;

            ProcessWorker = new BackgroundWorker();
            ProcessWorker.DoWork += ProcessWorker_DoWork;
            ProcessWorker.ProgressChanged += ProcessWorker_ProgressChanged;
            ProcessWorker.RunWorkerCompleted += ProcessWorker_RunWorkerCompleted;
            ProcessWorker.WorkerReportsProgress = true;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                InputList.Add(file);
                OutputList.Add("");
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lstDisplay.Items.Clear();
            string[] item = new string[2];
            for (int i = 0; i < InputList.Count; i++)
            {
                item[0] = Path.GetFileNameWithoutExtension(InputList[i]);
                item[1] = Path.GetFileNameWithoutExtension(OutputList[i]);
                lstDisplay.Items.Add(new ListViewItem(item));
            }
        }

        /*
         * Tags:
         * %t - Title
         * %a - Artist
         * %A - Album
         * %y - Year
         * %T - Track Number
         */

        private void btnProcess_Click(object sender, EventArgs e)
        {
            btnProcess.Enabled = false;
            btnSaveTags.Enabled = false;
            ProcessWorker.RunWorkerAsync();
        }

        private void ProcessWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            OutputList.Clear();

            string path;
            string filename;
            string extension;

            string title;
            string artist;
            string album;
            string year;
            string track;

            string output;
            string inputFormat;

            Dictionary<int, string> tokens = new Dictionary<int, string>();

            string[] operationsArray;

            // Find all input tags.

            if (txtInputFormat.Text.IndexOf("%t") != -1) // Title.
            {
                tokens.Add(txtInputFormat.Text.IndexOf("%t"), "%t");
            }
            if (txtInputFormat.Text.IndexOf("%a") != -1) // Artist.
            {
                tokens.Add(txtInputFormat.Text.IndexOf("%a"), "%a");
            }
            if (txtInputFormat.Text.IndexOf("%A") != -1) // Album.
            {
                tokens.Add(txtInputFormat.Text.IndexOf("%A"), "%A");
            }
            if (txtInputFormat.Text.IndexOf("%y") != -1) // Year.
            {
                tokens.Add(txtInputFormat.Text.IndexOf("%y"), "%y");
            }
            if (txtInputFormat.Text.IndexOf("%T") != -1) // Track.
            {
                tokens.Add(txtInputFormat.Text.IndexOf("%T"), "%T");
            }

            List<int> keys = tokens.Keys.ToList<int>();

            // Sort ascending.
            keys.Sort();
            int currentIndex = 0;

            // Replace tags.
            inputFormat = txtInputFormat.Text;
            foreach (int key in keys)
            {
                inputFormat = inputFormat.Replace(tokens[key], string.Format("{{{0}}}", currentIndex));
                currentIndex++;
            }

            // Convert output string into string.format format.
            output = txtOutputFormat.Text;
            output = output.Replace("%t", "{0}"); // Title.
            output = output.Replace("%a", "{1}"); // Artist.
            output = output.Replace("%A", "{2}"); // Album.
            output = output.Replace("%y", "{3}"); // Year.
            output = output.Replace("%T", "{4}"); // Track.

            OutputOperations.Clear();

            for (int i = 0; i < InputList.Count; i++)
            {
                Dictionary<string, string> operations = new Dictionary<string, string>();
                operationsArray = Path.GetFileNameWithoutExtension(InputList[i]).ParseExact(inputFormat);

                //title = "";
                //artist = "";
                //album = "";
                //year = "";

                title = "Title";
                artist = "Artist";
                album = "Album";
                year = "Year";
                track = "Track";

                // Process each operation.
                for (int j = 0; j < operationsArray.Length; j++)
                {
                    switch (tokens[keys[j]])
                    {
                        case "%t":
                            title = operationsArray[j];
                            break;
                        case "%a":
                            artist = operationsArray[j];
                            break;
                        case "%A":
                            album = operationsArray[j];
                            break;
                        case "%y":
                            year = operationsArray[j];
                            break;
                        case "%T":
                            track = operationsArray[j];
                            break;
                    }
                }

                // Split filename.
                path = Path.GetDirectoryName(InputList[i]);
                filename = Path.GetFileNameWithoutExtension(InputList[i]);
                extension = Path.GetExtension(InputList[i]);

                OutputList.Add(string.Format("{0}\\{1}{2}", path, string.Format(output, title, artist, album, year, track), extension));

                // Add operations for LibTag if they are set.
                if (title != "Title")
                    operations.Add("Title", title);
                if (artist != "Artist")
                    operations.Add("Artist", artist);
                if (album != "Album")
                    operations.Add("Album", album);
                if (year != "Year")
                    operations.Add("Year", year);
                if (track != "Track")
                    operations.Add("Track", track);

                OutputOperations.Add(operations);

                ProcessWorker.ReportProgress(i);
            }
        }

        private void ProcessWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgbProgress.Value = (int)(((float)e.ProgressPercentage / (float)InputList.Count) * 100);
        }

        private void ProcessWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }

            btnProcess.Enabled = true;
            btnSaveTags.Enabled = true;
            pgbProgress.Value = 0;
            UpdateDisplay();
        }

        private void btnSaveTags_Click(object sender, EventArgs e)
        {
            btnSaveTags.Enabled = false;
            btnProcess.Enabled = false;
            SaveTagsWorker.RunWorkerAsync();
        }

        private void SaveTagsWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < InputList.Count; i++)
            {
                TagLib.File tagFile = TagLib.File.Create(InputList[i]);
                List<string> keys = OutputOperations[i].Keys.ToList<string>();
                for (int j = 0; j < OutputOperations[i].Count; j++)
                {
                    switch (keys[j])
                    {
                        case "Title":
                            tagFile.Tag.Title = OutputOperations[i][keys[j]];
                            break;
                        case "Artist":
                            tagFile.Tag.AlbumArtists = null;
                            tagFile.Tag.Performers = null;
                            List<string> artists = new List<string>(OutputOperations[i][keys[j]].Split(','));
                            artists.ForEach(a => a = a.Trim());
                            tagFile.Tag.AlbumArtists = artists.ToArray();
                            tagFile.Tag.Performers = artists.ToArray();
                            break;
                        case "Album":
                            tagFile.Tag.Album = OutputOperations[i][keys[j]];
                            break;
                        case "Year":
                            tagFile.Tag.Year = uint.Parse(OutputOperations[i][keys[j]]);
                            break;
                        case "Track":
                            tagFile.Tag.Track = uint.Parse(OutputOperations[i][keys[j]]);
                            break;
                    }
                }
                tagFile.Save();
                SaveTagsWorker.ReportProgress(i);
            }
        }

        private void SaveTagsWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgbProgress.Value = (int)(((float)e.ProgressPercentage / (float)InputList.Count) * 100);
        }

        private void SaveTagsWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }

            btnSaveTags.Enabled = true;
            btnProcess.Enabled = true;
            pgbProgress.Value = 0;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {

        }

        private int CountInString(string haystack, string needle)
        {
            return ((haystack.Length - haystack.Replace(needle, "").Length) / needle.Length);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstDisplay.Items.Clear();
            InputList.Clear();
            OutputList.Clear();
        }
    }
}
