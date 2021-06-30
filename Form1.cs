using System;
using System.IO;
using System.Windows.Forms;

namespace WinForm_HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Count: 0 Words: 0";
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*)|*.* | Text files(*.txt)|*.txt"; // type of files
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Symbols: " + textBox1.Text.Length.ToString() + " Words: " + textBox1.Text.Split(' ').Length.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_Click(sender, e);
        }
    }
}
