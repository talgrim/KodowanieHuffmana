﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace KodowanieHuffmana
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ofd1;
        private string text;
        public Form1()
        {
            InitializeComponent();
            ofd1 = new OpenFileDialog();
            ofd1.Filter = "Text|*.txt";
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            Symbols symbols = new Symbols();
            DialogResult result = ofd1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string file = ofd1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    lLength.Text = text.Length.ToString();

                    foreach(char znak in text)
                    {
                        if (Char.IsLetterOrDigit(znak))
                        {
                            if (!symbols.Contains(znak))
                                symbols.Add(znak);
                            else
                                symbols.AddPresence(znak);
                        }
                    }
                    symbols.SortAscending();
                    lAlphabetLength.Text = symbols.List.Count.ToString();
                    gAlphabet.Visible = true;
                    gAlphabet.DataSource = symbols.List;
                    return;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
