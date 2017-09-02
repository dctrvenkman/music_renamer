using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace renamer
{
    public partial class Form1 : Form
    {
        string[] fileNames;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:\\Users\\root\\Desktop\\test\\";
            openFileDialog1.InitialDirectory = @"F:\Games\Nintendo DS\Roms\UNORG\New folder";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            //listBox1.DataSource = openFileDialog1.SafeFileNames;
            fileNames = openFileDialog1.FileNames;
            string[] newFileNames = new string[fileNames.Length];
            string[] dataSource = new string[fileNames.Length];
            for (int i = 0; i < newFileNames.Length; i++)
            {
                newFileNames[i] = updateFileName(fileNames[i]);
                //dataSource[i] = String.Concat(fileNames[i], " -> ", newFileNames[i]);
                dataSource[i] = String.Concat(new FileInfo(fileNames[i]).Name, " -> ", new FileInfo(newFileNames[i]).Name);
            }
            listBox1.DataSource = dataSource;
        }

        private string updateFileName(string fileName)
        {
            string tmpStr;
            FileInfo fi = new FileInfo(fileName);
            string dir = String.Concat(fi.DirectoryName, "\\");
            string name = fi.Name.Substring(0, fi.Name.Length - 4);
            string ext = fi.Name.Substring(fi.Name.Length - 4, 4);

            /*
            name = name.Replace('.', ' ');
            */

            int startIdx = name.Length - 11;
            int endIdx = name.Length - 6;
            tmpStr = name.Substring(0, startIdx - 1);
            string endStr = name.Substring(endIdx + 1, name.Length - endIdx - 1);
            string numberStr = name.Substring(startIdx + 1, 4);
            tmpStr = String.Concat(numberStr, " - ", tmpStr, endStr);

            name = tmpStr;
            
            return String.Concat(dir, name, ext);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo fi = new FileInfo(fileName);
                string tmp = updateFileName(fileName);
                fi.MoveTo(tmp);
                //System.IO.File.Move(fileName, fileName.Replace('.',' '));
            }
            MessageBox.Show("DONE");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            nametools.nametools.parseDate("2017-02-03");
        }
    }
}
