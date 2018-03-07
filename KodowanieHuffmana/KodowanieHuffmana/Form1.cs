using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace KodowanieHuffmana
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ofd1;
        private string text;
        private BitArray _encoded;
        private HuffmanTree huffmanTree;
        private Symbols symbols;
        private string _encodedString;
        private FileInfo _savedFile;
        private FileInfo _openedFile;
        private OpenFileDialog openFile;
        public Form1()
        {
            InitializeComponent();
            ofd1 = new OpenFileDialog();
            ofd1.Filter = "Text|*.txt";
            saveFileButton.Visible = false;
            encodeButton.Visible = false;
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            symbols = new Symbols();
            DialogResult result = ofd1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string file = ofd1.FileName;
                try
                {
                    _openedFile = new FileInfo(ofd1.FileName);
                    text = File.ReadAllText(file);
                    lLength.Text = text.Length.ToString();
                    foreach(char symbol in text)
                    {
                        if (symbols.Contains(symbol))
                            symbols.AddPresence(symbol);
                        else
                            symbols.Add(symbol);
                    }



                    symbols.SortDescending();
                    lAlphabetLength.Text = symbols.List.Count.ToString();
                    gAlphabet.Visible = true;
                    gAlphabet.DataSource = symbols.List;
                    encodeButton.Visible = true;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(symbols.ToDictionary());

            // Encode
            _encoded = huffmanTree.Encode(text);

            encodedTextBox.Text = "";

            if(_encoded.Count<1000)                
                foreach(bool bit in _encoded)
                {
                    encodedTextBox.Text += ((bit ? 1 : 0) + "");
                    _encodedString+= ((bit ? 1 : 0) + "");
                }
                
            else
            {
                encodedTextBox.Text = "Sekwencja zbyt długa do wyświetlenia";
            }

            // Decode
            string decoded = huffmanTree.Decode(_encoded);

            decodedTextBox.Text += (decoded);
            foreach (var znak in symbols.List)
            {
                foreach (bool bit in huffmanTree.Encode(znak.Znak.ToString()))
                {
                    znak.code += (bit ? "1" : "0");
                }
            }
            gAlphabet.DataSource = symbols.List;
            gAlphabet.Update();
            this.Update();
            saveFileButton.Visible = true;
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "SkompresowanyPlik.compress";
            saveFile.DefaultExt = ".compress";
            saveFile.Filter = "Compressed files|*.compress";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = new byte[_encoded.Length / 8 + (_encoded.Length % 8 == 0 ? 0 : 1)];
                _encoded.CopyTo(bytes, 0);
                using (BinaryWriter writer = new BinaryWriter(File.Open(saveFile.FileName, FileMode.Create)))
                {
                    writer.Write(symbols.List.Count);
                    foreach(Symbol symbol in symbols.List)
                    {
                        writer.Write(symbol.symbol);
                        writer.Write(symbol.presence);
                    }
                    writer.Write(bytes);
                }
                _savedFile = new FileInfo(saveFile.FileName);
                double saved = (double)_savedFile.Length;
                double opened = (double)_openedFile.Length;
                double ratio = opened / saved;
                CompressionRatio.Text = opened.ToString() + " b / " + saved.ToString() + " b = " + (ratio == 0 ? "0. Wybierz plik przed kompresją." : ratio.ToString("0.00000") );
            }


        }

        private void readFileButton_Click(object sender, EventArgs e)
        {
            huffmanTree = new HuffmanTree();
            symbols = new Symbols();
            openFile = new OpenFileDialog();
            openFile.DefaultExt = ".compress";
            openFile.Filter = "Compressed files|*.compress";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(openFile.FileName, FileMode.Open)))
                {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                        symbols.Add(reader.ReadChar(), reader.ReadInt32());
                    gAlphabet.DataSource = symbols.List;
                    huffmanTree.Build(symbols.ToDictionary());
                    long length = reader.BaseStream.Length - reader.BaseStream.Position;
                    byte[] bytes = new byte[length];
                    for (int i = 0; i < length; i++)
                        bytes[i] = reader.ReadByte();
                    BitArray bitText = new BitArray(bytes);
                    string decoded = huffmanTree.Decode(bitText);
                    fileTextBox.Text = decoded;
                    lLength.Text = decoded.Length.ToString();
                    lAlphabetLength.Text = symbols.List.Count.ToString();
                }
            }
        }
    }
}
