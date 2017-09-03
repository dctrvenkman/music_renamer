using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using nametools;

namespace renamer
{
    public partial class MainForm : Form
    {
		List<nametools.AlbumDir> albumDirs = new List<nametools.AlbumDir>();

        public MainForm()
        {
            InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			folderDialog.ShowNewFolderButton = false;
			folderDialog.Description = "Select the folder containing folders you wish to rename";
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
			folderDialog.SelectedPath = @"D:\Downloads\_JPOP\_testing\";
			if(DialogResult.OK == folderDialog.ShowDialog())
			{
				/* Clear the list box */
				((ListBox)clbFolderNames).DataSource = null;
				clbFolderNames.Items.Clear();
				/* Empty the list of album folders if previously populated */
				albumDirs.Clear();

				/* Generate information for each sub directory */
				DirectoryInfo dirInfo = new DirectoryInfo(folderDialog.SelectedPath);
				foreach(DirectoryInfo dir in dirInfo.EnumerateDirectories())
				{
					albumDirs.Add(new nametools.AlbumDir(dir.FullName));
				}

				/* TODO: Maybe use datagridview instead */
				/* Set the data binding for the list box */
				((ListBox)clbFolderNames).DataSource = albumDirs;
				((ListBox)clbFolderNames).DisplayMember = "NewDirectoryName";
				foreach(AlbumDir dir in albumDirs)
				{
					/* Only check folders we generated names for */
					if(dir.NewDirectoryName.Length > 0)
						clbFolderNames.SetItemChecked(clbFolderNames.Items.IndexOf(dir), true);
				}

				/* Update the text box with the selected folder */
				tbSelectedFolder.Text = folderDialog.SelectedPath;
			}
			clbFolderNames.Refresh();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			String renamedDirs = "";
			String skippedDirs = "";
			foreach(AlbumDir dir in clbFolderNames.CheckedItems)
            {
				try
				{
					System.IO.Directory.Move(tbSelectedFolder.Text + @"\" + dir.OriginalDirectoryName, tbSelectedFolder.Text + @"\" + dir.NewDirectoryName);
					renamedDirs += dir.NewDirectoryName + "\n";
				}
				catch(Exception)
				{
					skippedDirs += dir.NewDirectoryName + "\n";
				}
			}
            MessageBox.Show("Renamed Dirs\n--------------\n" + renamedDirs + "\nSkipped Dirs\n--------------\n" + skippedDirs, "Directory Renaming Complete");

		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(null != clbFolderNames.SelectedItem)
			{
				parsedInfoBox.Text = "Artist: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).Artist + "\n";
				parsedInfoBox.Text += "ArtistNameInNativeLang: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).ArtistNameInNativeLang + "\n";
				parsedInfoBox.Text += "Title: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).Title + "\n";
				parsedInfoBox.Text += "Release: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).ReleaseDate + "\n";
				parsedInfoBox.Text += "Originial Dir Name: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).OriginalDirectoryName + "\n";

				if(null != ((nametools.AlbumDir)clbFolderNames.SelectedItem).Tag)
				{
					ID3TagBox.Text = "Artist: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).Tag.FirstPerformer + "\n";
					ID3TagBox.Text += "Title: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).Tag.Album + "\n";
					ID3TagBox.Text += "Date: " + ((nametools.AlbumDir)clbFolderNames.SelectedItem).Tag.Year + "\n";
				}
				else
					ID3TagBox.Text = "";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			EditForm editDialog = new EditForm(((nametools.AlbumDir)clbFolderNames.SelectedItem).NewDirectoryName);
			DialogResult res = editDialog.ShowDialog(this);
			if(res == DialogResult.OK)
			{
				((nametools.AlbumDir)clbFolderNames.SelectedItem).NewDirectoryName = editDialog.GetInput();
				clbFolderNames.Refresh();
			}
			editDialog.Dispose();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			((nametools.AlbumDir)clbFolderNames.SelectedItem).NewDirectoryName = ((nametools.AlbumDir)clbFolderNames.SelectedItem).ToString();
			clbFolderNames.Refresh();
		}
	}
}
