using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace renamer
{
	public partial class EditForm : Form
	{
		public EditForm()
		{
			InitializeComponent();
		}

		public EditForm(String text)
		{
			InitializeComponent();
			textBox1.Text = text;
			button1.DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		public String GetInput() { return textBox1.Text; }
	}
}
