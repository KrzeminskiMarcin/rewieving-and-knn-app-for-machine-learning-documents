using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Zad1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbMetodaWczytania.DataSource = Enum.GetValues(typeof(MetodaWczytywaniaRepozytorium));

            cbMetryka.DataSource = Enum.GetValues(typeof(Metryka));

        }


        string sciezkaDoPliku;
        string sciezkaDoProbki;
        public string SciezkaDoPliku
        {
            get
            {
                return this.sciezkaDoPliku;
            }

            set
            {
                if (!System.IO.File.Exists(value))
                {
                    this.sciezkaDoPliku = "";
                    this.btnAnaliza.Enabled = false;
                    this.tbSciezkaPlikuRepozytorium.Text = "";

                    return;
                }

                this.sciezkaDoPliku = value;
                btnAnaliza.Enabled = true;
                tbSciezkaPlikuRepozytorium.Text = value;
            }
        }

        public string SciezkaDoProbki
        {
            get
            {
                return this.sciezkaDoProbki;
            }

            set
            {
                if (!System.IO.File.Exists(value))
                {
                    this.sciezkaDoProbki = "";
                    this.btnKnn2.Enabled = false;
                    this.btnKnn1.Enabled = false;
                    this.tbSciezkaPlikuProbki.Text = "";

                    return;
                }

                this.sciezkaDoProbki = value;
                btnKnn2.Enabled = true;
                btnKnn1.Enabled = true;
                tbSciezkaPlikuProbki.Text = value;
            }
        }

        private void btnWybierzPlik_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            this.SciezkaDoPliku = ofd.FileName;

            Obiekt.cnf = new Config();

            var tmp = System.IO.File.ReadAllLines(ofd.FileName);
            var ob = new Obiekt(tmp.First(), (MetodaWczytywaniaRepozytorium)Enum.Parse(typeof(MetodaWczytywaniaRepozytorium), cbMetodaWczytania.SelectedValue.ToString()));

            for (int i = 0; i < ob.wartosci.Length; i++)
            {
                clbAtrybutyDoPominiecia.Items.Add(
                    new KeyValuePair<string, int>($"Atrybut [{i}] = {ob.wartosci[i]}" , i)
                );
                clbAtrybutyDoPominiecia.DisplayMember = "Key";
            }
            
        }

        private void btnWybierzProbke_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            this.SciezkaDoProbki = ofd.FileName;
            
            var tmp = System.IO.File.ReadAllLines(ofd.FileName);
            var pr = new Obiekt(tmp.First(), (MetodaWczytywaniaRepozytorium)Enum.Parse(typeof(MetodaWczytywaniaRepozytorium), cbMetodaWczytania.SelectedValue.ToString()));

            for (int i = 0; i < pr.wartosci.Length; i++)
            {
                clbAtrybutyDoPominiecia.Items.Add(
                    new KeyValuePair<string, int>($"Atrybut [{i}] = {pr.wartosci[i]}", i)
                );
                clbAtrybutyDoPominiecia.DisplayMember = "Key";
            }

        }


        Obiekt[] obiekty;
        private void btnAnaliza_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAtrybutyDoPominiecia.CheckedItems.Count; i++)
            {
                var tmp = (KeyValuePair<string, int>)clbAtrybutyDoPominiecia.CheckedItems[i];
                Obiekt.cnf.AtrybutyPominiete.Add(tmp.Value);
            }           

            var linie = System.IO.File.ReadAllLines(this.SciezkaDoPliku);

            this.obiekty = new Obiekt[linie.Length];
                        
            MetodaWczytywaniaRepozytorium metoda = (MetodaWczytywaniaRepozytorium)Enum.Parse(typeof(MetodaWczytywaniaRepozytorium), cbMetodaWczytania.SelectedValue.ToString());
            
            for (int i = 0; i < linie.Length; i++)
            {
                this.obiekty[i] = new Obiekt(linie[i], metoda);
            }

            Obiekt.ZamienSymboliczneNaNumeryczne(this.obiekty);
            Obiekt.ZnajdzMinMaxWNumerycznych(this.obiekty);

            Obiekt.Normalizacja(this.obiekty, (double)nudMi.Value, (double)nudMa.Value);

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(Obiekt.cnf);

            System.IO.File.WriteAllText(this.SciezkaDoPliku + ".json", str);

            this.btnAnaliza.Enabled = false;

            nudK.Maximum = this.obiekty.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbMetryka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Obiekt[] probka;
        private void btnKnn2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAtrybutyDoPominiecia.CheckedItems.Count; i++)
            {
                var tmp = (KeyValuePair<string, int>)clbAtrybutyDoPominiecia.CheckedItems[i];
            }
            var linie = System.IO.File.ReadAllLines(this.SciezkaDoProbki);
            this.probka = new Obiekt[linie.Length];
            MetodaWczytywaniaRepozytorium metoda = (MetodaWczytywaniaRepozytorium)Enum.Parse(typeof(MetodaWczytywaniaRepozytorium), cbMetodaWczytania.SelectedValue.ToString());
            Metryka metryka = (Metryka)Enum.Parse(typeof(Metryka), cbMetryka.SelectedValue.ToString());
            for (int i = 0; i < linie.Length; i++)
            {
                this.probka[i] = new Obiekt(linie[i], metoda);
            } 
            Obiekt.ZamienSymboliczneNaNumeryczneProbka(this.obiekty, this.probka);
            Obiekt.Normalizacja(this.probka, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.Normalizacja(this.probka, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.Normalizacja(this.obiekty, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.knnWersja2(this.obiekty,this.probka, metryka, nudK.Value);
            string sciezka = sciezkaDoProbki.Substring(0, this.sciezkaDoProbki.LastIndexOf("."));
            StreamWriter file = new StreamWriter(sciezka + "-sklasyfikowane" + ".json");
            if (metoda == MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaPoczątkuPrzecinekSeparatorUsunietyIndex)
            {
                foreach (var o in probka)
                {
                    file.Write(o.index);
                    file.Write(';');
                    file.Write(o.decyzja);
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(';');
                        file.Write(wartosc);
                    }
                    file.WriteLine();
                }
                file.Close();
            }
            else if( metoda == MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaKoncuSpacjaSeparator)
            {
                foreach (var o in probka)
                {
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(wartosc);
                        file.Write(' ');
                    }
                    file.Write(o.decyzja);
                    file.WriteLine();
                }
                file.Close();
            }
            else
            {
                foreach (var o in probka)
                {
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(wartosc);
                        file.Write(';');
                    }
                    file.Write(o.decyzja);
                    file.WriteLine();
                }
                file.Close();
            }
        }

        private void nudK_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKnn1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAtrybutyDoPominiecia.CheckedItems.Count; i++)
            {
                var tmp = (KeyValuePair<string, int>)clbAtrybutyDoPominiecia.CheckedItems[i];
            }

            var linie = System.IO.File.ReadAllLines(this.SciezkaDoProbki);

            this.probka = new Obiekt[linie.Length];

            MetodaWczytywaniaRepozytorium metoda = (MetodaWczytywaniaRepozytorium)Enum.Parse(typeof(MetodaWczytywaniaRepozytorium), cbMetodaWczytania.SelectedValue.ToString());
            Metryka metryka = (Metryka)Enum.Parse(typeof(Metryka), cbMetryka.SelectedValue.ToString());
            for (int i = 0; i < linie.Length; i++)
            {
                this.probka[i] = new Obiekt(linie[i], metoda);
            }

            Obiekt.ZamienSymboliczneNaNumeryczneProbka(this.obiekty, this.probka);
            Obiekt.Normalizacja(this.probka, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.Normalizacja(this.probka, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.Normalizacja(this.obiekty, (double)nudMi.Value, (double)nudMa.Value);
            Obiekt.knnWersja1(this.obiekty, this.probka, metryka, nudK.Value);
            string sciezka = sciezkaDoProbki.Substring(0, this.sciezkaDoProbki.LastIndexOf("."));
            StreamWriter file = new StreamWriter(sciezka + "-sklasyfikowane" + ".json");
            if (metoda == MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaPoczątkuPrzecinekSeparatorUsunietyIndex)
            {
                foreach (var o in probka)
                {
                    file.Write(o.index);
                    file.Write(';');
                    file.Write(o.decyzja);
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(';');
                        file.Write(wartosc);
                    }
                    file.WriteLine();
                }
                file.Close();
            }
            else if (metoda == MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaKoncuSpacjaSeparator)
            {
                foreach (var o in probka)
                {
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(wartosc);
                        file.Write(' ');
                    }
                    file.Write(o.decyzja);
                    file.WriteLine();
                }
                file.Close();
            }
            else
            {
                foreach (var o in probka)
                {
                    foreach (var wartosc in o.wartosci)
                    {
                        file.Write(wartosc);
                        file.Write(';');
                    }
                    file.Write(o.decyzja);
                    file.WriteLine();
                }
                file.Close();
            }
        }

        private void btn1vReszta1_Click(object sender, EventArgs e)
        {
            Metryka metryka = (Metryka)Enum.Parse(typeof(Metryka), cbMetryka.SelectedValue.ToString());
            double[] procenty = Obiekt.jedenVsReszta1(this.obiekty, this.obiekty, metryka, nudK.Value);
            tbPokrycie.Text = procenty[0].ToString() + "%";
            tbTrafnosc.Text = procenty[1].ToString() + "%";
        }

        private void btn1vReszta2_Click(object sender, EventArgs e)
        {
            Metryka metryka = (Metryka)Enum.Parse(typeof(Metryka), cbMetryka.SelectedValue.ToString());
            double[] procenty = Obiekt.jedenVsReszta2(this.obiekty, this.obiekty, metryka, nudK.Value);
            tbPokrycie.Text = procenty[0].ToString() + "%";
            tbTrafnosc.Text = procenty[1].ToString() + "%";
        }
    }
}
