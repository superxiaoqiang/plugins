﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Nikse.SubtitleEdit.PluginLogic;

namespace plugin_tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _fileName = string.Empty;
        private void buttonWithFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _fileName = openFileDialog1.FileName;
                RunPlugin(File.ReadAllText(_fileName, Encoding.UTF8));
            }
        }

        private void buttonFromTextBox_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            if (text.Length == 0)
                return;
            RunPlugin(text);
        }

        private void RunPlugin(string content)
        {
            IPlugin hiColorer = new HIColorer();
            string outString = hiColorer.DoAction(this, content, 23.796, "<br />", _fileName.Length > 0 ? Path.GetFileName(_fileName) : null, null, content);
            if (content.Equals(outString))
                MessageBox.Show("Nothing changed!!!");
        }
    }
}
