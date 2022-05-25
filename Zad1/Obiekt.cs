using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Zad1
{




    enum MetodaWczytywaniaRepozytorium
    {
        KlasaDecyzyjnaNaKoncuSpacjaSeparator = 0,
        KlasaDecyzyjnaNaKoncuPrzecinekSeparator = 1,
        KlasaDecyzyjnaNaPoczątkuPrzecinekSeparatorUsunietyIndex = 2

    }

    enum Metryka
    {
        euklidesowa = 0,
        manhattan = 1,
        czebyszewa = 2,
        minakowskiego = 3,
        logarytmicza = 4,
    }

    internal class Obiekt
    {
        public static Config cnf;


        public string decyzja;
        public string index;
        public Dictionary<int, double> numeryczne;
        public Dictionary<int, double> numeryczneZamienione = new Dictionary<int, double>();

        public Dictionary<int, double> znormalizowane;

        public Dictionary<int, string> symboliczne = null;
        public Dictionary<int, string> Symboliczne
        {
            get
            {
                if(this.symboliczne == null)
                {
                    this.symboliczne = this.PobierzWartosciSymboliczne();
                }

                return this.symboliczne;
            }
        }

        public string[] wartosci;

        /// <summary>
        /// 1 22.08 11.46 2 4 4 1.585 0 0 0 1 2 100 1213 0
        /// </summary>
        /// <param name="linia"></param>
        public Obiekt(string linia, MetodaWczytywaniaRepozytorium metoda = MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaKoncuSpacjaSeparator)
        {
            switch(metoda)
            {
                case MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaKoncuSpacjaSeparator:
                    Metoda0(linia);
                    break;

                case MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaKoncuPrzecinekSeparator:
                    Metoda0(linia, ',');
                    break;
                case MetodaWczytywaniaRepozytorium.KlasaDecyzyjnaNaPoczątkuPrzecinekSeparatorUsunietyIndex:
                    Metoda1(linia, ',');
                    break;

                default:
                    throw new Exception("Nieobsługiwana metoda w Konstruktorze klasy Obiekt");
            }
            
        }

        Dictionary<int, string> PobierzWartosciSymboliczne()
        {
            Dictionary<int, string> wynik = new Dictionary<int, string>();

            for (int i = 0; i < this.wartosci.Length; i++)
            {
                if(!this.numeryczne.ContainsKey(i))
                {
                    wynik.Add(i, wartosci[i]);
                }
            }
            return wynik;
        }

        internal static void Normalizacja(Obiekt[] obiekty, double mi, double ma)
        {
            for (int i = 0; i < obiekty.Length; i++)
            {
                obiekty[i].Normalizuj(mi, ma);
            }

            Obiekt.cnf.Mi = mi;
            Obiekt.cnf.Ma = ma;
        }
        void Normalizuj(double mi, double ma)
        {
            this.znormalizowane = new Dictionary<int, double>();
            foreach (var item in this.numeryczne)
            {
                var numerAtrybutu = item.Key; // numer atrybutu
                if (Obiekt.cnf.AtrybutyPominiete.Contains(numerAtrybutu))
                    continue;
                if( item.Value > cnf.Max[numerAtrybutu])
                {
                    cnf.Max[numerAtrybutu] = item.Value;
                }
                if (item.Value < cnf.Min[numerAtrybutu])
                {
                    cnf.Min[numerAtrybutu] = item.Value;
                }


                var wynik = ZnormalizujWartosc(cnf.Min[numerAtrybutu], cnf.Max[numerAtrybutu], mi, ma, item.Value);
                this.znormalizowane.Add(item.Key, wynik);                
            }

            foreach (var item in this.numeryczneZamienione)
            {
                var numerAtrybutu = item.Key; // numer atrybutu
                if (Obiekt.cnf.AtrybutyPominiete.Contains(numerAtrybutu))
                    continue;

                var wynik = ZnormalizujWartosc(cnf.Min[numerAtrybutu], cnf.Max[numerAtrybutu], mi, ma, item.Value);
                this.znormalizowane.Add(item.Key, wynik);
            }
        }
        
        static double ZnormalizujWartosc(double min, double max, double mi, double ma, double wartosc)
        {
            return (wartosc - min) / (max - min) * (ma - mi) + mi;
        }

        void Metoda0(string linia, char separator = ' ')
        {
            var wartosci = linia.Split(new char[] { separator });
            this.decyzja = wartosci.Last();

            this.wartosci = new string[wartosci.Length - 1];
            this.numeryczne = new Dictionary<int, double>();

            for (int i = 0; i < wartosci.Length - 1; i++)
            {
                this.wartosci[i] = wartosci[i];
                try
                {
                    double? tmp = Parsuj(wartosci[i]);
                    if (tmp.HasValue)
                        this.numeryczne.Add(i, tmp.Value);
                }
                catch (Exception e) { }
            }
        }
        void Metoda1(string linia, char separator = ' ')
        {
            var wartosci = linia.Split(new char[] { separator });
            this.index = wartosci.First();
            wartosci = linia.Split(new char[] { separator }).Skip(1).ToArray();
            this.decyzja = wartosci.First();

            this.wartosci = new string[wartosci.Length - 1 ];
            this.numeryczne = new Dictionary<int, double>();

            for (int i = 0; i < wartosci.Length-1 ; i++)
            {
                this.wartosci[i] = wartosci[i+1];
                try
                {
                    double? tmp = Parsuj(wartosci[i+1]);
                    if (tmp.HasValue)
                        this.numeryczne.Add(i, tmp.Value);
                }
                catch (Exception e) { }
            }
        }

        double? Parsuj(string wartosc)
        {
            wartosc = wartosc.Trim();
            double wynik = 0;

            if (!double.TryParse(wartosc.Replace(",", "."), out wynik))
            {
                if (!double.TryParse(wartosc.Replace(".", ","), out wynik))
                    return null;
            }

            return wynik;
        }

        public override string ToString()
        {
            return $"Atrybuty[{this.wartosci.Length}] ({this.decyzja})";
        }

        public static Dictionary<string, int> CzestosciWartosci(Obiekt[] obiekty, int index)
        {
            Dictionary<string, int> czestosci = new Dictionary<string, int>();
            foreach (var ob in obiekty)
            {
                var symbol = ob.wartosci[index];

                if(czestosci.ContainsKey(symbol))
                {
                    czestosci[symbol]++;
                }
                else
                {
                    czestosci.Add(symbol, 1);
                }
            }

            return czestosci;
        }

        public static Dictionary<string, int> PrzypisywanieSymbolomNumerow(Dictionary<string, int> czestosci)
        {
            var wynik = czestosci.OrderBy(item => item.Value);

            Dictionary<string, int> przypisane = new Dictionary<string, int>();

            int i = 0;
            foreach (var item in wynik)
            {
                przypisane.Add(item.Key, i++);
            }

            return przypisane;
        }

        public void ZamienSymbolNaNumer(Dictionary<string, int> przypisane, int index)
        {
            if (!this.numeryczneZamienione.ContainsKey(index))
                this.numeryczneZamienione.Add(index, 0);

            var symbol = this.wartosci[index];

            var numer = przypisane[symbol];

            this.numeryczneZamienione[index] = numer;
        }

        public static void ZamienSymboliczneNaNumeryczne(Obiekt[] obiekty)
        {
            var symboliczne = obiekty.First().Symboliczne;

            foreach (var item in symboliczne)
            {
                var index = item.Key;

                var czestosci = Obiekt.CzestosciWartosci(obiekty, index);

                var przypisane = Obiekt.PrzypisywanieSymbolomNumerow(czestosci);

                Obiekt.cnf.Min.Add(index, przypisane.First().Value);
                Obiekt.cnf.Max.Add(index, przypisane.Last().Value);

                for (int i = 0; i < obiekty.Length; i++)
                //Parallel.For(0, obiekty.Length, i =>
                {
                    obiekty[i].ZamienSymbolNaNumer(przypisane, index);
                }
                //);
            }
        }
        public static void ZamienSymboliczneNaNumeryczneProbka(Obiekt[] obiekty, Obiekt[] probka)
        {
            var symboliczne = probka.First().Symboliczne;

            foreach (var item in symboliczne)
            {
                var index = item.Key;

                var czestosci = Obiekt.CzestosciWartosci(obiekty, index);

                var przypisane = Obiekt.PrzypisywanieSymbolomNumerow(czestosci);
                
                for (int i = 0; i < probka.Length; i++)
                //Parallel.For(0, obiekty.Length, i =>
                {
                    probka[i].ZamienSymbolNaNumer(przypisane, index);
                }
                //);
            }
        }



        public static void ZnajdzMinMaxWNumerycznych(Obiekt[] obiekty)
        {
            var numeryczne = obiekty.First().numeryczne;

            foreach (var item in numeryczne)
            {
                var index = item.Key;

                double min = obiekty[0].numeryczne[index];
                double max = obiekty[0].numeryczne[index];

                List<Obiekt> brakująceWartosci = new List<Obiekt>();
                for (int i = 1; i < obiekty.Length; i++)
                {
                    if (obiekty[i].numeryczne.ContainsKey(index))
                    {
                        if (obiekty[i].numeryczne[index] < min)
                            min = obiekty[i].numeryczne[index];

                        if (obiekty[i].numeryczne[index] > max)
                            max = obiekty[i].numeryczne[index];
                    }
                    else
                    {
                        brakująceWartosci.Add(obiekty[i]);
                    }
                }

                foreach (var ob in brakująceWartosci)
                {
                    ob.numeryczne.Add(index, min);
                    ob.Symboliczne.Remove(index);
                }

                Obiekt.cnf.Min.Add(index, min);
                Obiekt.cnf.Max.Add(index, max);
            }
        }
        public static void knnWersja2(Obiekt[] obiekty, Obiekt[] probka, Metryka metryka, decimal k)
        {
            int x = Decimal.ToInt32(k);
            for (int i =0; i<probka.Length;i++)
            {
                Dictionary<string, List<double>> decyzjeOdleglosci = new Dictionary<string, List<double>>();
                var odleglosciPosortowane = obliczOdleglosci(obiekty, probka[i], metryka, k).OrderBy(item => item.Value);
                var kOdleglosci = odleglosciPosortowane.Take(x);
                foreach ( var item in kOdleglosci)
                {
                    for(int j=0;j<obiekty.Length; j++)
                    {
                        if(item.Key == j)
                        {
                            if(!decyzjeOdleglosci.ContainsKey(obiekty[j].decyzja))
                            {
                                decyzjeOdleglosci.Add(obiekty[j].decyzja, new List<double>());
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }
                            else
                            {
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }
                            
                        }
                    }
                }
                Dictionary<string, int> klasyfikator = new Dictionary<string, int>();
                foreach( var item in decyzjeOdleglosci)
                {
                    klasyfikator.Add(item.Key, item.Value.Count);
                }
                int max = 0;
                string decyzja = "";
                foreach(var item in klasyfikator)
                {
                    if (item.Value == max)
                    {
                        decyzja = "?";
                    }
                    if (item.Value > max)
                    {
                        decyzja = item.Key;
                        max = item.Value;
                    }
                }
                probka[i].decyzja = decyzja;

            }
        }
        public static void knnWersja1(Obiekt[] obiekty, Obiekt[] probka, Metryka metryka, decimal k)
        {
            int x = Decimal.ToInt32(k);
            for (int i = 0; i < probka.Length; i++)
            {
                Dictionary<string, List<double>> decyzjeOdleglosci = new Dictionary<string, List<double>>();
                Dictionary<string, double> decyzjeSumaOdleglosci = new Dictionary<string, double>();
                var odleglosciPosortowane = obliczOdleglosci(obiekty, probka[i], metryka, k).OrderBy(item => item.Value);
                foreach (var item in odleglosciPosortowane)
                {
                    for (int j = 0; j < obiekty.Length; j++)
                    {
                        if (item.Key == j)
                        {
                            if (!decyzjeOdleglosci.ContainsKey(obiekty[j].decyzja))
                            {
                                decyzjeOdleglosci.Add(obiekty[j].decyzja, new List<double>());
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }
                            else if (decyzjeOdleglosci[obiekty[j].decyzja].Count < x)
                            {
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }

                        }
                    }
                }
                foreach (var dec in decyzjeOdleglosci)
                {
                    double suma = 0;
                    foreach (var value in dec.Value)
                    {
                        suma += value;
                    }
                    decyzjeSumaOdleglosci.Add(dec.Key, suma/dec.Value.Count);
                }
                double min = 99999;
                string decyzja = "";
                foreach (var item in decyzjeSumaOdleglosci)
                {
                    if (item.Value == min)
                    {
                        decyzja = "?";
                    }
                    if (item.Value < min)
                    {
                        decyzja = item.Key;
                        min = item.Value;
                    }
                }
                probka[i].decyzja = decyzja;

            }
        }
        public static double[] jedenVsReszta1(Obiekt[] obiekty, Obiekt[] probka, Metryka metryka, decimal k)
        {
            double procentPokrycia = 0;
            double procentTrafnosci = 0;
            double pokrycie = 0;
            double trafnosc = 0;
            int x = Decimal.ToInt32(k);
            for (int i = 0; i < probka.Length; i++)
            {
                Dictionary<string, List<double>> decyzjeOdleglosci = new Dictionary<string, List<double>>();
                Dictionary<string, double> decyzjeSumaOdleglosci = new Dictionary<string, double>();
                var odleglosciPosortowane = obliczOdleglosci1vR(obiekty, probka[i], metryka, k).OrderBy(item => item.Value);
                foreach (var item in odleglosciPosortowane)
                {
                    for (int j = 0; j < obiekty.Length; j++)
                    {
                        if (item.Key == j)
                        {
                            if (!decyzjeOdleglosci.ContainsKey(obiekty[j].decyzja))
                            {
                                decyzjeOdleglosci.Add(obiekty[j].decyzja, new List<double>());
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }
                            else if (decyzjeOdleglosci[obiekty[j].decyzja].Count < x)
                            {
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }

                        }
                    }
                }
                foreach (var dec in decyzjeOdleglosci)
                {
                    double suma = 0;
                    foreach (var value in dec.Value)
                    {
                        suma += value;
                    }
                    decyzjeSumaOdleglosci.Add(dec.Key, suma / dec.Value.Count);
                }
                double min = 99999;
                string decyzja = "";
                foreach (var item in decyzjeSumaOdleglosci)
                {
                    if (item.Value == min)
                    {
                        decyzja = "?";
                    }
                    if (item.Value < min)
                    {
                        decyzja = item.Key;
                        min = item.Value;
                    }
                }
                if(decyzja != "?")
                {
                    pokrycie += 1;
                }
                if(decyzja == probka[i].decyzja)
                {
                    trafnosc += 1;
                }

            }
            procentPokrycia = (pokrycie / probka.Length)*100;
            procentTrafnosci = (trafnosc / pokrycie)*100;
            procentPokrycia = Math.Round(procentPokrycia,2);
            procentTrafnosci = Math.Round(procentTrafnosci, 2);
            double[] wynik = new double[2];
            wynik[0] = procentPokrycia;
            wynik[1] = procentTrafnosci;
            return wynik;
        }
        public static double[] jedenVsReszta2(Obiekt[] obiekty, Obiekt[] probka, Metryka metryka, decimal k)
        {
            double procentPokrycia = 0;
            double procentTrafnosci = 0;
            double pokrycie = 0;
            double trafnosc = 0;
            int x = Decimal.ToInt32(k);
            for (int i = 0; i < probka.Length; i++)
            {
                Dictionary<string, List<double>> decyzjeOdleglosci = new Dictionary<string, List<double>>();
                var odleglosciPosortowane = obliczOdleglosci1vR(obiekty, probka[i], metryka, k).OrderBy(item => item.Value);
                var kOdleglosci = odleglosciPosortowane.Take(x);
                foreach (var item in kOdleglosci)
                {
                    for (int j = 0; j < obiekty.Length; j++)
                    {
                        if (item.Key == j)
                        {
                            if (!decyzjeOdleglosci.ContainsKey(obiekty[j].decyzja))
                            {
                                decyzjeOdleglosci.Add(obiekty[j].decyzja, new List<double>());
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }
                            else
                            {
                                decyzjeOdleglosci[obiekty[j].decyzja].Add(item.Value);
                            }

                        }
                    }
                }
                Dictionary<string, int> klasyfikator = new Dictionary<string, int>();
                foreach (var item in decyzjeOdleglosci)
                {
                    klasyfikator.Add(item.Key, item.Value.Count);
                }
                int max = 0;
                string decyzja = "";
                foreach (var item in klasyfikator)
                {
                    if (item.Value == max)
                    {
                        decyzja = "?";
                    }
                    if (item.Value > max)
                    {
                        decyzja = item.Key;
                        max = item.Value;
                    }
                }
                if (decyzja != "?")
                {
                    pokrycie += 1;
                }
                if (decyzja == probka[i].decyzja)
                {
                    trafnosc += 1;
                }

            }
            procentPokrycia = (pokrycie / probka.Length) * 100;
            procentTrafnosci = (trafnosc / pokrycie) * 100;
            procentPokrycia = Math.Round(procentPokrycia, 2);
            procentTrafnosci = Math.Round(procentTrafnosci, 2);
            double[] wynik = new double[2];
            wynik[0] = procentPokrycia;
            wynik[1] = procentTrafnosci;
            return wynik;
        }
        public static Dictionary<int,double>obliczOdleglosci (Obiekt[] obiekty, Obiekt probka, Metryka metryka, decimal k)
        {
            double wynik =0;
            Dictionary<int,double> odleglosci = new Dictionary<int, double>();
            for (int i=0; i<obiekty.Length; i++)
            {
                wynik = obliczOdleglosc(obiekty[i], probka, metryka, (double)k );
                odleglosci.Add(i, wynik);
                wynik = 0;
            }
            return odleglosci;
        }
        public static Dictionary<int, double> obliczOdleglosci1vR(Obiekt[] obiekty, Obiekt probka, Metryka metryka, decimal k)
        {
            double wynik = 0;
            Dictionary<int, double> odleglosci = new Dictionary<int, double>();
            for (int i = 0; i < obiekty.Length; i++)
            {
                if(obiekty[i].wartosci == probka.wartosci)
                {
                    continue;
                }
                else
                {
                    wynik = obliczOdleglosc(obiekty[i], probka, metryka, (double)k);
                    odleglosci.Add(i, wynik);
                    wynik = 0;
                }
            }
            return odleglosci;
        }
        public static double obliczOdleglosc(Obiekt obiekt, Obiekt probka, Metryka metryka, double k)
        {
            bool minakowskiego = false;
            double odleglosc =0;
            switch (metryka)
            {
                case Metryka.manhattan:
                    foreach( var item in obiekt.znormalizowane)
                    {
                        foreach(var ajtem in probka.znormalizowane)
                        {
                            if (item.Key == ajtem.Key)
                            {
                                odleglosc += Math.Abs(item.Value - ajtem.Value);
                            }
                        }
                    }
                    break;
                case Metryka.euklidesowa:
                    foreach (var item in obiekt.znormalizowane)
                    {
                        foreach (var ajtem in probka.znormalizowane)
                        {
                            if (item.Key == ajtem.Key)
                            {
                                odleglosc += Math.Pow((item.Value - ajtem.Value), 2);
                            }
                        }
                        
                    }
                    break;
                case Metryka.czebyszewa:
                    foreach (var item in obiekt.znormalizowane)
                    {
                        foreach (var ajtem in probka.znormalizowane)
                        {
                            if (item.Key == ajtem.Key)
                            {
                                if (odleglosc < Math.Abs(item.Value - ajtem.Value))
                                {
                                    odleglosc = Math.Abs(item.Value - ajtem.Value);
                                }
                            }
                        }
                        
                       
                    }
                    break;
                case Metryka.minakowskiego:
                    minakowskiego = true;
                    foreach (var item in obiekt.znormalizowane)
                    {
                        foreach (var ajtem in probka.znormalizowane)
                        {
                            if (item.Key == ajtem.Key)
                            {
                                odleglosc += Math.Pow((item.Value - ajtem.Value), k);
                            }
                        }
                    }
                    break;
                case Metryka.logarytmicza:
                    foreach (var item in obiekt.znormalizowane)
                    {
                        foreach (var ajtem in probka.znormalizowane)
                        {
                            if (item.Key == ajtem.Key)
                            {
                                odleglosc += Math.Abs(Math.Log10(item.Value) - Math.Log10(ajtem.Value));
                            }
                        }
                    }
                    break;

            }
            if( minakowskiego == true)
            {
                return Math.Pow(odleglosc, 1 / k);
            }
            else
            {
                return odleglosc;
            }
        }
    }
    
}