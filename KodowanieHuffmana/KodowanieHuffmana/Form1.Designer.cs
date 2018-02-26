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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
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
    }
}

