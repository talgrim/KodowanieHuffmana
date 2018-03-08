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
            //tworzenie drzewa Huffmana
            huffmanTree.Build(symbols);
            //zakodowanie tresci pliku
            _encoded = huffmanTree.Encode(text);

            //wyswietlenie zakodowanej tresci, jesli jest dostatecznie krotka
            encodedTextBox.Text = "";
            if(_encoded.Count<1000)                
                foreach(bool bit in _encoded)
                {
                    encodedTextBox.Text += ((bit ? 1 : 0) + "");
                    _encodedString+= ((bit ? 1 : 0) + "");
                }    
            else
                encodedTextBox.Text = "Sekwencja zbyt długa do wyświetlenia";

            //zdekodowanie zawartosci, celem sprawdzenia poprawnosci kodowania
            string decoded = huffmanTree.Decode(_encoded);
            //wyswietlenie zawartosci zdekodowanej oraz uaktualnienie tabeli alfabetu o kod znaku
            decodedTextBox.Text = (decoded);
            ShowAlphabet();
            saveFileButton.Visible = true;
        }

        private void ShowAlphabet()
        {
            foreach (var znak in symbols.List)
                foreach (bool bit in huffmanTree.Encode(znak.Znak.ToString()))
                    znak.code += (bit ? "1" : "0");
            gAlphabet.DataSource = symbols.List;
            gAlphabet.Update();
            Update();
        }

        // przycisk zapisu pliku
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "SkompresowanyPlik.compress";
            saveFile.DefaultExt = ".compress";
            saveFile.Filter = "Compressed files|*.compress";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ushort length = Convert.ToUInt16(_encoded.Length / 8 + (_encoded.Length % 8 == 0 ? 0 : 1));
                byte[] bytes = new byte[length];
                _encoded.CopyTo(bytes, 0);

                //otworzenie strumienia do zapisu binarnego do pliku
                using (BinaryWriter writer = new BinaryWriter(File.Open(saveFile.FileName, FileMode.Create)))
                {
                    //zapisanie dlugosci alfabetu
                    writer.Write(symbols.List.Count);
                    //zapisanie kolejnych elementow alfabetu
                    foreach(Symbol symbol in symbols.List)
                    {
                        //zapisanie znaku, zmienna char - 2 bajty
                        writer.Write( symbol.symbol );
                        //zapisanie liczby jego wystepowania, zmienna unsigned short - 2 bajty
                        writer.Write( symbol.presence );
                    }
                    //zapisanie listy bajtow, poniewaz w C# zarowno bit(bool) jak i bajt zajmuja bajt - zapisywanie BitArray byloby naduzyciem. 
                    writer.Write(bytes);
                }
                _savedFile = new FileInfo(saveFile.FileName);
                //wyznaczenie rozmiaru zapisanego pliku
                double saved = (double)_savedFile.Length;
                //wyznaczenie rozmiaru otworzonego pliku
                double opened = (double)_openedFile.Length;
                //obliczenie i wypisanie stosunku wielkosci plikow (wspolczynnika kompresji)
                double ratio = opened / saved;
                CompressionRatio.Text = opened.ToString() + " b / " + saved.ToString() + " b = " + (ratio == 0 ? "0. Wybierz plik przed kompresją." : ratio.ToString("0.00000") );
            }


        }

        //przycisk odczytu i dekompresji pliku
        private void readFileButton_Click(object sender, EventArgs e)
        {
            huffmanTree = new HuffmanTree();
            symbols = new Symbols();
            openFile = new OpenFileDialog();
            openFile.DefaultExt = ".compress";
            openFile.Filter = "Compressed files|*.compress";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //otworzenie strumienia do odczytu binarnego z pliku
                using (BinaryReader reader = new BinaryReader(File.Open(openFile.FileName, FileMode.Open)))
                {
                    //odczytywanie naglowka
                        //odczytanie dlugosci alfabetu
                        int count = reader.ReadInt32();
                        //odczytanie oraz odtworzenie listy symboli razem z liczba ich wystepowania
                        for (int i = 0; i < count; i++)
                            symbols.Add( reader.ReadChar(), reader.ReadUInt16());
                        //odtworzenie drzewa Huffmana na podstawie listy symboli przekonwertowanej do Dictionary
                        huffmanTree.Build(symbols);

                    //wyznaczenie pozostalej dlugosci pliku po odczytaniu naglowka
                    int length = Convert.ToInt32(reader.BaseStream.Length - reader.BaseStream.Position);
                    byte[] bytes = new byte[length];
                    //odczyt kolejnych bajtow skompresowanych danych az do konca pliku
                    for (int i = 0; i < length; i++)
                        bytes[i] = reader.ReadByte();

                    //konwersja tablicy bajtow na BitArray
                    BitArray bitText = new BitArray(bytes);
                    //usuniecie zer nieznaczacych celem unikniecia nadmiaru danych
                    int amountOfLeadingZeros = 8 - Convert.ToString(bytes[length - 1], 2).Length;
                    bitText.Length -= amountOfLeadingZeros;

                    //wypisanie odczytanej, zakodowanej tresci pliku
                    fileTextBox.Text = "";
                    if (bitText.Count < 1000)
                        foreach (bool bit in bitText)
                            fileTextBox.Text += ((bit ? 1 : 0) + "");
                    else
                        fileTextBox.Text = "Sekwencja zbyt długa do wyświetlenia";

                    //dekodowanie i wyswietlenie zdekodowanej tresci
                    string decoded = huffmanTree.Decode(bitText);
                    decodedTextBox.Text = decoded;
                    ShowAlphabet();
                    lLength.Text = decoded.Length.ToString();
                    lAlphabetLength.Text = symbols.List.Count.ToString();
                }
            }
        }
    }
}
