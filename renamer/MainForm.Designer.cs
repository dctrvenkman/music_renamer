namespace renamer
{
    partial class MainForm
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
			this.tbSelectedFolder = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.clbFolderNames = new System.Windows.Forms.CheckedListBox();
			this.parsedInfoBox = new System.Windows.Forms.RichTextBox();
			this.ID3TagBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbSelectedFolder
			// 
			this.tbSelectedFolder.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSelectedFolder.Location = new System.Drawing.Point(132, 12);
			this.tbSelectedFolder.Name = "tbSelectedFolder";
			this.tbSelectedFolder.ReadOnly = true;
			this.tbSelectedFolder.Size = new System.Drawing.Size(840, 27);
			this.tbSelectedFolder.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 27);
			this.button1.TabIndex = 1;
			this.button1.Text = "Select Folder";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(644, 475);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(328, 32);
			this.button3.TabIndex = 4;
			this.button3.Text = "Convert";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// clbFolderNames
			// 
			this.clbFolderNames.CheckOnClick = true;
			this.clbFolderNames.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clbFolderNames.FormattingEnabled = true;
			this.clbFolderNames.Location = new System.Drawing.Point(12, 45);
			this.clbFolderNames.Name = "clbFolderNames";
			this.clbFolderNames.Size = new System.Drawing.Size(626, 422);
			this.clbFolderNames.TabIndex = 5;
			this.clbFolderNames.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			// 
			// parsedInfoBox
			// 
			this.parsedInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.parsedInfoBox.Location = new System.Drawing.Point(644, 67);
			this.parsedInfoBox.Name = "parsedInfoBox";
			this.parsedInfoBox.Size = new System.Drawing.Size(328, 173);
			this.parsedInfoBox.TabIndex = 7;
			this.parsedInfoBox.Text = "";
			// 
			// ID3TagBox
			// 
			this.ID3TagBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ID3TagBox.Location = new System.Drawing.Point(644, 265);
			this.ID3TagBox.Name = "ID3TagBox";
			this.ID3TagBox.Size = new System.Drawing.Size(328, 204);
			this.ID3TagBox.TabIndex = 8;
			this.ID3TagBox.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(644, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "Parsed Information";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(644, 243);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 19);
			this.label2.TabIndex = 10;
			this.label2.Text = "ID3 Tag";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 475);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 32);
			this.button2.TabIndex = 11;
			this.button2.Text = "Edit";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(102, 475);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(84, 32);
			this.button4.TabIndex = 12;
			this.button4.Text = "Re-Generate";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(981, 513);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ID3TagBox);
			this.Controls.Add(this.parsedInfoBox);
			this.Controls.Add(this.clbFolderNames);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbSelectedFolder);
			this.Name = "MainForm";
			this.Text = "Music Folder Renamer";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSelectedFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckedListBox clbFolderNames;
		private System.Windows.Forms.RichTextBox parsedInfoBox;
		private System.Windows.Forms.RichTextBox ID3TagBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
	}
}

