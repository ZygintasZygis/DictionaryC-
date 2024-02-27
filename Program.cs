using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dictionary
{
    class Preke
    {
        public string pav { get; set; }
        public int kiekis { get; set; }

        public Preke(string p, int k)
        {
            pav = p;
            kiekis = k;
        }
    }
    public class Asmuo : IComparable<Asmuo>
    {
        public string vardas { get; set; }
        public int amžius { get; set; }
        public Asmuo(string vardas, int amžius) // Konstruktorius
        {
            this.vardas = vardas;
            this.amžius = amžius;
        }
        public override string ToString()
        {
            return this.vardas + " " + this.amžius;
        }
        public override bool Equals(object objektas)
        {
            Asmuo stud = objektas as Asmuo;
            return stud.vardas == vardas && stud.amžius == amžius;
        }
        // Užklotas metodas GetHashCode()
        public override int GetHashCode() { return base.GetHashCode(); }

        public int CompareTo(Asmuo other)
        {
            int poz = String.Compare(this.vardas, other.vardas, StringComparison.CurrentCulture);
            if (poz > 0)
                return 1;
            if (poz < 0)
                return -1;
            else
                if (this.amžius > other.amžius) return 1;
            else if (this.amžius < other.amžius) return -1;
            else
                return 0;
        }

    }

    public class IComparer : IComparer<Asmuo>, IEqualityComparer<Asmuo>
    {
        public int Compare(Asmuo x, Asmuo y)
        {
            if (x.amžius > y.amžius)
                return 1;
            if (y.amžius > x.amžius)
                return -1;
            else
                return 0;
        }

        public bool Equals(Asmuo x, Asmuo y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Asmuo obj)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> pirmas = new Dictionary<string, int>();
            pirmas.Add("Vienas", 1);
            pirmas.Add("Du", 2);
            pirmas.Add("Trys", 3);
            pirmas.Add("Keturi", 4);
            pirmas.Add("Penki", 5);
            Console.WriteLine("Pirmas zodynas.");
            Spausdinti(pirmas);
            int[] nmas = new int[5];
            int j = 0;
            foreach(KeyValuePair<string,int>a in pirmas)
            {
                nmas[j] = a.Value;
                j++;
            }
            int e = 0;
            for (int i = 0; i < nmas.Count(); i++)
            {
                Console.WriteLine("reiksme - {0}", nmas[e].ToString());
                e++;
            }
            Console.WriteLine();

            Dictionary<string, int> antras = new Dictionary<string, int>(pirmas);
            antras.Add("Sesi", 6);
            Console.WriteLine("Antras zodynas.");
            Spausdinti(antras);
            string[] nnmas = new string[7];
            int ee = 0;
            foreach(KeyValuePair<string,int>b in antras)
            {
                string c = b.Key;
                nnmas[ee] = c;
                ee++;
            }
            for (int i = 0; i < nnmas.Count(); i++)
                Console.WriteLine("raktai - {0}", nnmas[i]);
            Console.WriteLine();

            Asmuo stud = new Asmuo("Jonas", 25);
            Asmuo stud1 = new Asmuo("Petras", 26);
            Asmuo stud2 = new Asmuo("Juozas", 38);
            Dictionary<string, Asmuo> trecias = new Dictionary<string, Asmuo>();
            trecias.Add("Vienas", stud);
            trecias.Add("Du", stud1);
            trecias.Add("Trecias", stud2);
            Console.WriteLine("Trecias zodynas.");
            Spausdinti1(trecias);
            ICollection raktai = trecias.Keys;
            Console.WriteLine();

            //ContainsKey()
            string raktas = "Vienas";
            if (trecias.ContainsKey(raktas))
                Console.WriteLine("Zodynas turi rakta: {0}", raktas);
            else
                Console.WriteLine("ERROR.");

            //ContainsValue()
            Asmuo stud3 = new Asmuo("Juozas", 55);
            if (trecias.ContainsValue(stud3))
                Console.WriteLine("rasta reiksme: {0} {1}", stud3.vardas, stud3.amžius);
            else
                Console.WriteLine("Nerasta reiksme: {0} {1}", stud3.vardas, stud3.amžius);
            if (trecias.ContainsValue(stud2))
                Console.WriteLine("rado reikšmę: {0} {1}", stud2.vardas,
                stud2.amžius);
            else Console.WriteLine("nerado reikšmės: {0} {1}",
            stud2.vardas, stud2.amžius);
            Console.WriteLine();

            Asmuo stud4 = new Asmuo("Rimas", 25);
            Asmuo stud5 = new Asmuo("Azuolas", 30);
            Asmuo stud6 = new Asmuo("Benas", 16);
            Asmuo stud7 = new Asmuo("Zygintas", 10);
            IComparer kitas = new IComparer();
            Dictionary<Asmuo, string> naujas6 =
            new Dictionary<Asmuo, string>();
            naujas6.Add(stud4, "penki");
            // naujas6.Add(stud, "du"); // Būtų klaida
            naujas6.Add(stud5, "trys");
            naujas6.Add(stud7, "vienas");
            naujas6.Add(stud6, "du");
            Console.WriteLine(" Žodynas naujas6");
            Console.WriteLine("Žodyno narių kiekis: {0}", naujas6.Count);
            Console.WriteLine(" Reikšmės:");
            Spausdinti2(naujas6);
            Console.WriteLine();

            var enumerator = naujas6.GetEnumerator();
            Console.WriteLine("Enumeratoriaus pavyzdys");
            Console.WriteLine(" Žodynas naujas6 ");
            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                Console.WriteLine(" {0}", item);
            }
            Console.WriteLine();

            SortedDictionary<string, int> SortedDictionary = new SortedDictionary<string, int>();
            SortedDictionary.Add("vienas", 1);
            SortedDictionary.Add("du", 2);
            SortedDictionary.Add("trys", 3);
            SortedDictionary.Add("keturi", 4);
            SortedDictionary.Add("penki", 5);
            Console.WriteLine("Naujas Rikiuotas zodynas SortedList:");
            SpausdintiRikiuotaZodyna(SortedDictionary);
            Console.WriteLine();

            IComparer x = new IComparer();
            SortedDictionary<Asmuo, string> SortedDictionary2 = new SortedDictionary<Asmuo, string>(x);
            SortedDictionary2.Add(stud7, "vienas");
            SortedDictionary2.Add(stud4, "du");
            SortedDictionary2.Add(stud5, "trys");
            SortedDictionary2.Add(stud6, "keturi");
            Console.WriteLine("NAUJAS SORTED LIST rikiuojamas pagal rakta.");
            SpausdintiRikiuotaZodyna2(SortedDictionary2);
            Console.WriteLine();

            SortedList<Asmuo,string> SortedList = new SortedList<Asmuo,string>();
            Asmuo a1 = new Asmuo("Zygintas", 10);
            Asmuo a2 = new Asmuo("Zigmantas", 10);
            Asmuo a3 = new Asmuo("Benas", 15);
            Asmuo a4 = new Asmuo("aZUOLAS", 20);
            SortedList.Add(a1, "vienas");
            SortedList.Add(a2, "du");
            SortedList.Add(a3, "trys");
            SortedList.Add(a4, "keturi");
            Console.WriteLine("Naujas Sorted List sarasas:");
            SpausdintiSortedList(SortedList);
            Console.WriteLine();

            Console.WriteLine("Deklas Stack");
            Stack deklas = new Stack();
            deklas.Push(1);
            deklas.Push(2);
            deklas.Push(3);
            deklas.Push(4);
            var d = deklas.GetEnumerator();
            while(d.MoveNext())
            {
                object obj = d.Current;
                Console.WriteLine(obj.ToString());
            }
            object[] mas = new object[4];
            int[] mas2 = new int[4];
            mas = deklas.ToArray();
            Console.WriteLine("sveiku sk masyvas");
            for (int i = 0; i < deklas.Count;i++)
            {
                mas2[i] = (int)mas[i];
                Console.WriteLine(mas2[i].ToString());
            }
            int[] mmm = new int[4];
            mas.CopyTo(mmm,0);
            Console.WriteLine("aaaaaaaaaaaaaaaaaa");
            for(int i = 0; i < mmm.Length; i++)
            {
                Console.WriteLine("{0}",mmm[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Skaiciu aibe");
            HashSet<int> Aibe = new HashSet<int>();
            Aibe.Add(1);
            Aibe.Add(2);
            Aibe.Add(3);
            Aibe.Add(4);
            Aibe.Add(5);
            Aibe.Add(6);
            var dddddddd = Aibe.GetEnumerator();
            int[] objobj = new int[6];
            while(dddddddd.MoveNext())
            {
                object obj = dddddddd.Current;
                Console.WriteLine("{0}", obj.ToString());
            }
            objobj = Aibe.ToArray();
            Console.WriteLine("skaiciu masyvas is aibes");
            for (int i = 0; i < objobj.Length; i++)
                Console.WriteLine("{0}", objobj[i]);


            Console.WriteLine();
            Console.WriteLine("eile.");
            Queue eile = new Queue();
            eile.Enqueue(1);
            eile.Enqueue(2);
            eile.Enqueue(3);
            eile.Enqueue(4);
            int[] newint = new int[4];
            eile.CopyTo(newint, 0);
            for (int i = 0; i < newint.Length; i++)
                Console.WriteLine("" + newint[i]);

            Console.WriteLine();
            Console.WriteLine("sarasas be pasikartojimu");
            List<int> sksk = new List<int>();
            sksk.Add(1);
            sksk.Add(1);
            sksk.Add(1);
            sksk.Add(2);
            sksk.Add(3);
            sksk.Add(3);
            sksk.Add(4);
            sksk.Add(4);
            sksk.Add(4);
            for (int i = 0; i < sksk.Count; i++)
                Console.WriteLine("" + sksk[i].ToString());
            List<int> newlist = new List<int>();
            for(int i = 0; i < sksk.Count;i++)
            {
                if (!newlist.Contains(sksk[i]))
                    newlist.Add(sksk[i]);
            }
            Console.WriteLine("Sarasas be pasikartojimu");
            for (int i = 0; i < newlist.Count; i++)
                Console.WriteLine("" + newlist[i].ToString());

            Console.WriteLine();
            Console.WriteLine("Prekes");
            Preke pr1 = new Preke("Bananas", 5);
            Preke pr2 = new Preke("Bananas", 10);
            Preke pr3 = new Preke("Ananasas", 10);
            Preke pr4 = new Preke("Kriause", 10);
            Preke pr5 = new Preke("Kriause", 10);
            Preke pr6 = new Preke("Kokosas", 5);
            Preke pr7 = new Preke("Kokosas", 20);
            List<Preke> PrekiuList = new List<Preke>();
            PrekiuList.Add(pr1);
            PrekiuList.Add(pr2);
            PrekiuList.Add(pr3);
            PrekiuList.Add(pr4);
            PrekiuList.Add(pr5);
            PrekiuList.Add(pr6);
            PrekiuList.Add(pr7);
            List<Preke> BePasikartojimu = new List<Preke>();
            for (int i = 0; i < PrekiuList.Count; i++)
                Console.WriteLine("{0} {1}", PrekiuList[i].pav, PrekiuList[i].kiekis);

            for (int jj = 0; jj < PrekiuList.Count; jj++)
            {
                Preke preke = PrekiuList[jj];
                for (int i = 1; i < PrekiuList.Count; i++)
                {
                    if (preke.pav == PrekiuList[i].pav)
                    {
                        preke.kiekis = preke.kiekis + PrekiuList[i].kiekis;
                        PrekiuList.Remove(PrekiuList[i]);
                        i--;
                    }

                }
                BePasikartojimu.Add(preke);
                PrekiuList.Remove(preke);
                jj--;
            }
            
            Console.WriteLine();
            Console.WriteLine("Prekiu sarasas be pasikartojimu");
            for(int i = 0; i < BePasikartojimu.Count;i++)
                Console.WriteLine("{0} {1}", BePasikartojimu[i].pav,BePasikartojimu[i].kiekis);

        }
        public static void Spausdinti(Dictionary<string, int> zodynas)
        {
            foreach (KeyValuePair<string, int> pora in zodynas)
            {
                Console.WriteLine(" {0,-10} - {1}",
                pora.Key.ToString(), pora.Value.ToString());
            }
            Console.WriteLine();
        }
        public static void Spausdinti1(Dictionary<string, Asmuo> zodynas)
        {
            foreach (KeyValuePair<string, Asmuo> pora in zodynas)
            {
                Console.WriteLine(" {0,-10} - {1}",
                pora.Key.ToString(), pora.Value.ToString());
            }
            Console.WriteLine();
        }
        // spausdina žodyno <Asmuo, string> reikšmes.
        // Savybės Key ir Value
        public static void Spausdinti2(Dictionary<Asmuo, string> zodynas)
        {
            foreach (KeyValuePair<Asmuo, string> pora in zodynas)
            {
                Console.WriteLine(" {0,-10} - {1}",
                pora.Key.ToString(), pora.Value.ToString());
            }
            Console.WriteLine();
        }
        static void SpausdintiRikiuotaZodyna(SortedDictionary<string,int>A)
        {
            foreach(KeyValuePair<string,int> B in A)
            {
                Console.WriteLine("{0} - {1}", B.Key.ToString(), B.Value.ToString());
            }
        }
        static void SpausdintiRikiuotaZodyna2(SortedDictionary<Asmuo, string> A)
        {
            foreach (KeyValuePair<Asmuo, string> B in A)
            {
                Console.WriteLine("{0} - {1}", B.Key.ToString(), B.Value.ToString());
            }
        }
        public static void SpausdintiSortedList(SortedList<Asmuo,string> listas)
        {
            foreach (KeyValuePair<Asmuo,string> pora in listas)
            {
                Console.WriteLine(" {0,-10} - {1}",
                pora.Key.ToString(), pora.Value.ToString());
            }
            Console.WriteLine();
        }
    }
}
