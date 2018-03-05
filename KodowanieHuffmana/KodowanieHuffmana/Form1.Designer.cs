namespace KodowanieHuffmana
{
    partial class Form1
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
            this.bBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lLength = new System.Windows.Forms.Label();
            this.lAlphabetLength = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gAlphabet = new System.Windows.Forms.DataGridView();
            this.encodeButton = new System.Windows.Forms.Button();
            this.encodedTextBox = new System.Windows.Forms.TextBox();
            this.decodedTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.readFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.writeFileKeyButton = new System.Windows.Forms.Button();
            this.readFileKeyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gAlphabet)).BeginInit();
            this.SuspendLayout();
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(12, 12);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 23);
            this.bBrowse.TabIndex = 0;
            this.bBrowse.Text = "Przeglądaj...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dane o pliku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Długość tekstu";
            // 
            // lLength
            // 
            this.lLength.AutoSize = true;
            this.lLength.Location = new System.Drawing.Point(237, 39);
            this.lLength.Name = "lLength";
            this.lLength.Size = new System.Drawing.Size(0, 13);
            this.lLength.TabIndex = 3;
            // 
            // lAlphabetLength
            // 
            this.lAlphabetLength.AutoSize = true;
            this.lAlphabetLength.Location = new System.Drawing.Point(237, 62);
            this.lAlphabetLength.Name = "lAlphabetLength";
            this.lAlphabetLength.Size = new System.Drawing.Size(0, 13);
            this.lAlphabetLength.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Długość alfabetu";
            // 
            // gAlphabet
            // 
            this.gAlphabet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gAlphabet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAlphabet.Location = new System.Drawing.Point(12, 100);
            this.gAlphabet.Name = "gAlphabet";
            this.gAlphabet.ReadOnly = true;
            this.gAlphabet.Size = new System.Drawing.Size(260, 150);
            this.gAlphabet.TabIndex = 6;
            this.gAlphabet.Visible = false;
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(12, 52);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(75, 23);
            this.encodeButton.TabIndex = 7;
            this.encodeButton.Text = "Kompresuj";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // encodedTextBox
            // 
            this.encodedTextBox.Location = new System.Drawing.Point(295, 39);
            this.encodedTextBox.Multiline = true;
            this.encodedTextBox.Name = "encodedTextBox";
            this.encodedTextBox.Size = new System.Drawing.Size(184, 209);
            this.encodedTextBox.TabIndex = 8;
            // 
            // decodedTextBox
            // 
            this.decodedTextBox.Location = new System.Drawing.Point(529, 39);
            this.decodedTextBox.Multiline = true;
            this.decodedTextBox.Name = "decodedTextBox";
            this.decodedTextBox.Size = new System.Drawing.Size(367, 88);
            this.decodedTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Skompresowane dane";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Wynik dekompresji";
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(529, 262);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 12;
            this.saveFileButton.Text = "Zapisz plik";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // readFileButton
            // 
            this.readFileButton.Location = new System.Drawing.Point(721, 262);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(75, 23);
            this.readFileButton.TabIndex = 13;
            this.readFileButton.Text = "Odczytaj plik";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Wynik odczytywania z pliku";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(529, 158);
            this.fileTextBox.Multiline = true;
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(367, 90);
            this.fileTextBox.TabIndex = 15;
            // 
            // writeFileKeyButton
            // 
            this.writeFileKeyButton.Location = new System.Drawing.Point(620, 262);
            this.writeFileKeyButton.Name = "writeFileKeyButton";
            this.writeFileKeyButton.Size = new System.Drawing.Size(81, 23);
            this.writeFileKeyButton.TabIndex = 16;
            this.writeFileKeyButton.Text = "Zapisz klucz";
            this.writeFileKeyButton.UseVisualStyleBackColor = true;
            this.writeFileKeyButton.Click += new System.EventHandler(this.writeFileKeyButton_Click);
            // 
            // readFileKeyButton
            // 
            this.readFileKeyButton.Location = new System.Drawing.Point(811, 262);
            this.readFileKeyButton.Name = "readFileKeyButton";
            this.readFileKeyButton.Size = new System.Drawing.Size(85, 23);
            this.readFileKeyButton.TabIndex = 17;
            this.readFileKeyButton.Text = "Odczytaj klucz";
            this.readFileKeyButton.UseVisualStyleBackColor = true;
            this.readFileKeyButton.Click += new System.EventHandler(this.readFileKeyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 297);
            this.Controls.Add(this.readFileKeyButton);
            this.Controls.Add(this.writeFileKeyButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.readFileButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.decodedTextBox);
            this.Controls.Add(this.encodedTextBox);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.gAlphabet);
            this.Controls.Add(this.lAlphabetLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gAlphabet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lLength;
        private System.Windows.Forms.Label lAlphabetLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gAlphabet;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.TextBox encodedTextBox;
        private System.Windows.Forms.TextBox decodedTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button writeFileKeyButton;
        private System.Windows.Forms.Button readFileKeyButton;
    }
}

