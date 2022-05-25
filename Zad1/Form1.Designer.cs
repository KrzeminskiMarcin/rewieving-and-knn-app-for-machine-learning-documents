namespace Zad1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSciezkaPlikuRepozytorium = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWybierzPlik = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnAnaliza = new System.Windows.Forms.Button();
            this.cbMetodaWczytania = new System.Windows.Forms.ComboBox();
            this.nudMi = new System.Windows.Forms.NumericUpDown();
            this.nudMa = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbAtrybutyDoPominiecia = new System.Windows.Forms.CheckedListBox();
            this.tbSciezkaPlikuProbki = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMetryka = new System.Windows.Forms.ComboBox();
            this.btnWybierzProbke = new System.Windows.Forms.Button();
            this.btnKnn2 = new System.Windows.Forms.Button();
            this.nudK = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKnn1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn1vReszta1 = new System.Windows.Forms.Button();
            this.btn1vReszta2 = new System.Windows.Forms.Button();
            this.tbPokrycie = new System.Windows.Forms.TextBox();
            this.tbTrafnosc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudK)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSciezkaPlikuRepozytorium
            // 
            this.tbSciezkaPlikuRepozytorium.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaPlikuRepozytorium.Location = new System.Drawing.Point(139, 50);
            this.tbSciezkaPlikuRepozytorium.Margin = new System.Windows.Forms.Padding(4);
            this.tbSciezkaPlikuRepozytorium.Name = "tbSciezkaPlikuRepozytorium";
            this.tbSciezkaPlikuRepozytorium.ReadOnly = true;
            this.tbSciezkaPlikuRepozytorium.Size = new System.Drawing.Size(520, 22);
            this.tbSciezkaPlikuRepozytorium.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plik repozytorium";
            // 
            // btnWybierzPlik
            // 
            this.btnWybierzPlik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzPlik.Location = new System.Drawing.Point(667, 48);
            this.btnWybierzPlik.Margin = new System.Windows.Forms.Padding(4);
            this.btnWybierzPlik.Name = "btnWybierzPlik";
            this.btnWybierzPlik.Size = new System.Drawing.Size(48, 28);
            this.btnWybierzPlik.TabIndex = 2;
            this.btnWybierzPlik.Text = "...";
            this.btnWybierzPlik.UseVisualStyleBackColor = true;
            this.btnWybierzPlik.Click += new System.EventHandler(this.btnWybierzPlik_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnAnaliza
            // 
            this.btnAnaliza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnaliza.Enabled = false;
            this.btnAnaliza.Location = new System.Drawing.Point(614, 296);
            this.btnAnaliza.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnaliza.Name = "btnAnaliza";
            this.btnAnaliza.Size = new System.Drawing.Size(100, 28);
            this.btnAnaliza.TabIndex = 3;
            this.btnAnaliza.Text = "Analizuj plik";
            this.btnAnaliza.UseVisualStyleBackColor = true;
            this.btnAnaliza.Click += new System.EventHandler(this.btnAnaliza_Click);
            // 
            // cbMetodaWczytania
            // 
            this.cbMetodaWczytania.FormattingEnabled = true;
            this.cbMetodaWczytania.Location = new System.Drawing.Point(139, 15);
            this.cbMetodaWczytania.Margin = new System.Windows.Forms.Padding(4);
            this.cbMetodaWczytania.Name = "cbMetodaWczytania";
            this.cbMetodaWczytania.Size = new System.Drawing.Size(520, 24);
            this.cbMetodaWczytania.TabIndex = 4;
            // 
            // nudMi
            // 
            this.nudMi.DecimalPlaces = 4;
            this.nudMi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudMi.Location = new System.Drawing.Point(85, 34);
            this.nudMi.Margin = new System.Windows.Forms.Padding(4);
            this.nudMi.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMi.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudMi.Name = "nudMi";
            this.nudMi.Size = new System.Drawing.Size(160, 22);
            this.nudMi.TabIndex = 5;
            // 
            // nudMa
            // 
            this.nudMa.DecimalPlaces = 4;
            this.nudMa.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudMa.Location = new System.Drawing.Point(472, 34);
            this.nudMa.Margin = new System.Windows.Forms.Padding(4);
            this.nudMa.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMa.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudMa.Name = "nudMa";
            this.nudMa.Size = new System.Drawing.Size(160, 22);
            this.nudMa.TabIndex = 6;
            this.nudMa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Minimum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Maksimum";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudMi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudMa);
            this.groupBox1.Location = new System.Drawing.Point(20, 199);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(640, 89);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Normalizacja";
            // 
            // clbAtrybutyDoPominiecia
            // 
            this.clbAtrybutyDoPominiecia.FormattingEnabled = true;
            this.clbAtrybutyDoPominiecia.Location = new System.Drawing.Point(139, 82);
            this.clbAtrybutyDoPominiecia.Margin = new System.Windows.Forms.Padding(4);
            this.clbAtrybutyDoPominiecia.Name = "clbAtrybutyDoPominiecia";
            this.clbAtrybutyDoPominiecia.Size = new System.Drawing.Size(512, 106);
            this.clbAtrybutyDoPominiecia.TabIndex = 10;
            // 
            // tbSciezkaPlikuProbki
            // 
            this.tbSciezkaPlikuProbki.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaPlikuProbki.Location = new System.Drawing.Point(139, 344);
            this.tbSciezkaPlikuProbki.Margin = new System.Windows.Forms.Padding(4);
            this.tbSciezkaPlikuProbki.Name = "tbSciezkaPlikuProbki";
            this.tbSciezkaPlikuProbki.ReadOnly = true;
            this.tbSciezkaPlikuProbki.Size = new System.Drawing.Size(520, 22);
            this.tbSciezkaPlikuProbki.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 347);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Plik próbki";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbMetryka
            // 
            this.cbMetryka.FormattingEnabled = true;
            this.cbMetryka.Location = new System.Drawing.Point(139, 374);
            this.cbMetryka.Margin = new System.Windows.Forms.Padding(4);
            this.cbMetryka.Name = "cbMetryka";
            this.cbMetryka.Size = new System.Drawing.Size(520, 24);
            this.cbMetryka.TabIndex = 13;
            this.cbMetryka.SelectedIndexChanged += new System.EventHandler(this.cbMetryka_SelectedIndexChanged);
            // 
            // btnWybierzProbke
            // 
            this.btnWybierzProbke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzProbke.Location = new System.Drawing.Point(667, 341);
            this.btnWybierzProbke.Margin = new System.Windows.Forms.Padding(4);
            this.btnWybierzProbke.Name = "btnWybierzProbke";
            this.btnWybierzProbke.Size = new System.Drawing.Size(48, 28);
            this.btnWybierzProbke.TabIndex = 14;
            this.btnWybierzProbke.Text = "...";
            this.btnWybierzProbke.UseVisualStyleBackColor = true;
            this.btnWybierzProbke.Click += new System.EventHandler(this.btnWybierzProbke_Click);
            // 
            // btnKnn2
            // 
            this.btnKnn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnn2.Enabled = false;
            this.btnKnn2.Location = new System.Drawing.Point(422, 442);
            this.btnKnn2.Margin = new System.Windows.Forms.Padding(4);
            this.btnKnn2.Name = "btnKnn2";
            this.btnKnn2.Size = new System.Drawing.Size(238, 28);
            this.btnKnn2.TabIndex = 15;
            this.btnKnn2.Text = "KNNver2";
            this.btnKnn2.UseVisualStyleBackColor = true;
            this.btnKnn2.Click += new System.EventHandler(this.btnKnn2_Click);
            // 
            // nudK
            // 
            this.nudK.Location = new System.Drawing.Point(559, 405);
            this.nudK.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudK.Name = "nudK";
            this.nudK.Size = new System.Drawing.Size(100, 22);
            this.nudK.TabIndex = 16;
            this.nudK.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudK.ValueChanged += new System.EventHandler(this.nudK_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 407);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "K";
            // 
            // btnKnn1
            // 
            this.btnKnn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnn1.Enabled = false;
            this.btnKnn1.Location = new System.Drawing.Point(139, 442);
            this.btnKnn1.Margin = new System.Windows.Forms.Padding(4);
            this.btnKnn1.Name = "btnKnn1";
            this.btnKnn1.Size = new System.Drawing.Size(238, 28);
            this.btnKnn1.TabIndex = 18;
            this.btnKnn1.Text = "KNNver1";
            this.btnKnn1.UseVisualStyleBackColor = true;
            this.btnKnn1.Click += new System.EventHandler(this.btnKnn1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 381);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Metryka";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Metoda wczytania";
            // 
            // btn1vReszta1
            // 
            this.btn1vReszta1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1vReszta1.Location = new System.Drawing.Point(139, 478);
            this.btn1vReszta1.Margin = new System.Windows.Forms.Padding(4);
            this.btn1vReszta1.Name = "btn1vReszta1";
            this.btn1vReszta1.Size = new System.Drawing.Size(238, 28);
            this.btn1vReszta1.TabIndex = 21;
            this.btn1vReszta1.Text = "1vsResztaver1";
            this.btn1vReszta1.UseVisualStyleBackColor = true;
            this.btn1vReszta1.Click += new System.EventHandler(this.btn1vReszta1_Click);
            // 
            // btn1vReszta2
            // 
            this.btn1vReszta2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1vReszta2.Location = new System.Drawing.Point(422, 478);
            this.btn1vReszta2.Margin = new System.Windows.Forms.Padding(4);
            this.btn1vReszta2.Name = "btn1vReszta2";
            this.btn1vReszta2.Size = new System.Drawing.Size(238, 28);
            this.btn1vReszta2.TabIndex = 22;
            this.btn1vReszta2.Text = "1vsResztaver2";
            this.btn1vReszta2.UseVisualStyleBackColor = true;
            this.btn1vReszta2.Click += new System.EventHandler(this.btn1vReszta2_Click);
            // 
            // tbPokrycie
            // 
            this.tbPokrycie.Enabled = false;
            this.tbPokrycie.Location = new System.Drawing.Point(205, 513);
            this.tbPokrycie.Name = "tbPokrycie";
            this.tbPokrycie.Size = new System.Drawing.Size(78, 22);
            this.tbPokrycie.TabIndex = 23;
            // 
            // tbTrafnosc
            // 
            this.tbTrafnosc.Enabled = false;
            this.tbTrafnosc.Location = new System.Drawing.Point(492, 513);
            this.tbTrafnosc.Name = "tbTrafnosc";
            this.tbTrafnosc.Size = new System.Drawing.Size(78, 22);
            this.tbTrafnosc.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 518);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Pokrycie";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 516);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Trafność";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 571);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTrafnosc);
            this.Controls.Add(this.tbPokrycie);
            this.Controls.Add(this.btn1vReszta2);
            this.Controls.Add(this.btn1vReszta1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnKnn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudK);
            this.Controls.Add(this.btnKnn2);
            this.Controls.Add(this.btnWybierzProbke);
            this.Controls.Add(this.cbMetryka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSciezkaPlikuProbki);
            this.Controls.Add(this.clbAtrybutyDoPominiecia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbMetodaWczytania);
            this.Controls.Add(this.btnAnaliza);
            this.Controls.Add(this.btnWybierzPlik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSciezkaPlikuRepozytorium);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(590, 329);
            this.Name = "Form1";
            this.Text = "Przygotwanie danych";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSciezkaPlikuRepozytorium;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWybierzPlik;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnAnaliza;
        private System.Windows.Forms.ComboBox cbMetodaWczytania;
        private System.Windows.Forms.NumericUpDown nudMi;
        private System.Windows.Forms.NumericUpDown nudMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbAtrybutyDoPominiecia;
        private System.Windows.Forms.TextBox tbSciezkaPlikuProbki;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMetryka;
        private System.Windows.Forms.Button btnWybierzProbke;
        private System.Windows.Forms.Button btnKnn2;
        private System.Windows.Forms.NumericUpDown nudK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnKnn1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn1vReszta1;
        private System.Windows.Forms.Button btn1vReszta2;
        private System.Windows.Forms.TextBox tbPokrycie;
        private System.Windows.Forms.TextBox tbTrafnosc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

