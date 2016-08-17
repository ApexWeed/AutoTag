namespace Auto_Tag
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDisplay = new System.Windows.Forms.ListView();
            this.Input = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Output = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSaveTags = new System.Windows.Forms.Button();
            this.txtInputFormat = new System.Windows.Forms.TextBox();
            this.txtOutputFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstDisplay
            // 
            this.lstDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Input,
            this.Output});
            this.lstDisplay.Location = new System.Drawing.Point(12, 79);
            this.lstDisplay.Name = "lstDisplay";
            this.lstDisplay.Size = new System.Drawing.Size(839, 409);
            this.lstDisplay.TabIndex = 0;
            this.lstDisplay.UseCompatibleStateImageBehavior = false;
            this.lstDisplay.View = System.Windows.Forms.View.Details;
            // 
            // Input
            // 
            this.Input.Text = "Input";
            this.Input.Width = 471;
            // 
            // Output
            // 
            this.Output.Text = "Output";
            this.Output.Width = 364;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(695, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 21);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSaveTags
            // 
            this.btnSaveTags.Location = new System.Drawing.Point(695, 41);
            this.btnSaveTags.Name = "btnSaveTags";
            this.btnSaveTags.Size = new System.Drawing.Size(75, 21);
            this.btnSaveTags.TabIndex = 2;
            this.btnSaveTags.Text = "Save Tags";
            this.btnSaveTags.UseVisualStyleBackColor = true;
            this.btnSaveTags.Click += new System.EventHandler(this.btnSaveTags_Click);
            // 
            // txtInputFormat
            // 
            this.txtInputFormat.Location = new System.Drawing.Point(92, 13);
            this.txtInputFormat.Name = "txtInputFormat";
            this.txtInputFormat.Size = new System.Drawing.Size(588, 19);
            this.txtInputFormat.TabIndex = 3;
            this.txtInputFormat.Text = "%a - %t";
            // 
            // txtOutputFormat
            // 
            this.txtOutputFormat.Location = new System.Drawing.Point(92, 42);
            this.txtOutputFormat.Name = "txtOutputFormat";
            this.txtOutputFormat.Size = new System.Drawing.Size(588, 19);
            this.txtOutputFormat.TabIndex = 4;
            this.txtOutputFormat.Text = "%a - %t";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output Format";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(776, 10);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 21);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 494);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(839, 21);
            this.pgbProgress.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(776, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 21);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "%t - Title, %a - Artist, %A - Album, %y - Year, %T - Track Number";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 527);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputFormat);
            this.Controls.Add(this.txtInputFormat);
            this.Controls.Add(this.btnSaveTags);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lstDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstDisplay;
        private System.Windows.Forms.ColumnHeader Input;
        private System.Windows.Forms.ColumnHeader Output;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSaveTags;
        private System.Windows.Forms.TextBox txtInputFormat;
        private System.Windows.Forms.TextBox txtOutputFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
    }
}

