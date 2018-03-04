using System;
using System.Collections;
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
        private BitArray _encoded;
        private HuffmanTree huffmanTree;
        private string _encodedString;
        public Form1()
        {
            InitializeComponent();
            ofd1 = new OpenFileDialog();
            ofd1.Filter = "Text|*.txt";
            encodeButton.Visible = false;
            saveFileButton.Visible = false;
            writeFileKeyButton.Visible = false;
            readButton.Visible = false;
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
                    text = File.ReadAllText(file);
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
                    encodeButton.Visible = true;
                    saveFileButton.Visible = true;
                    writeFileKeyButton.Visible = true;
                }
                catch (IOException)
                {
                }
            }
        }

        //private BinaryTree BuildBinaryTree(Symbols symbols)
        //{
        //    var symbolInTree = new BinaryTree();
        //    var symbolList = symbols.List;
            
        //    for(int i=0;i<symbolList.Count;i++)
        //    {
        //        if (symbolInTree.isEmpty())
        //        {
        //            symbolInTree.insert(symbolList[i].presence);
        //        }
        //        else
        //        {
        //            if(symbolInTree.root.number<symbolList[i].presence)
        //        }







        //        var symbol1 = symbolList[i];
        //        var symbol2 = symbolList[i + 1];
        //        new Symbol(null,12);
        //        symbolInTree.insert(symbol1.presence + symbol2.presence);
        //        symbolInTree.insert(symbol1.presence);
        //        symbolInTree.insert(symbol2.presence);
        //    }

        //    return symbolInTree;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string input = text;
            huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            _encoded = huffmanTree.Encode(input);

            foreach (bool bit in _encoded)
            {
                encodedTextBox.Text += ((bit ? 1 : 0) + "");
                _encodedString+= ((bit ? 1 : 0) + "");
            }

            // Decode
            string decoded = huffmanTree.Decode(_encoded);

            decodedTextBox.Text += (decoded);



        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = new byte[_encoded.Length / 8 + (_encoded.Length % 8 == 0 ? 0 : 1)];
                    _encoded.CopyTo(bytes, 0);
                    File.WriteAllBytes(savefile.FileName, bytes);
                }
                catch
                {
                    MessageBox.Show("Coś poszło nie tak");
                }

            }


        }

        private void readButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                    byte[] bytes = System.IO.File.ReadAllBytes(openFile.FileName);
                    BitArray bitText = new System.Collections.BitArray(bytes);
                    string decoded = huffmanTree.Decode(bitText);
                    fileTextBox.Text = decoded;


            }
        }


        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        private void writeFileKeyButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WriteToBinaryFile(savefile.FileName, huffmanTree);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Coś poszło nie tak");
                }

            }
        }

        private void readFileKeyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    huffmanTree = ReadFromBinaryFile<HuffmanTree>(openFile.FileName);
                    readButton.Visible = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Cos poszlo nie tak");
                }



            }
        }
    }
}
