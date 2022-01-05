using System;
using System.IO;
using System.Linq;

namespace beolvas
{
    class Program
    {
        public static int[] ev = new int[3500];
        public static int[] het = new int[3500];
        public static string[] datum = new string[3500];
        public static int[] otos_talalatok = new int[3500];
        public static string[] otos_nyer = new string[3500];
        public static int[] negyes_talalatok = new int[3500];
        public static string[] negyes_nyer = new string[3500];
        public static int[] harmas_talalatok = new int[3500];
        public static string[] harmas_nyer = new string[3500];
        public static int[] kettes_talalatok = new int[3500];
        public static string[] kettes_nyer = new string[3500];
        public static int[,] nyeroszamok = new int[3500, 3500];
        public static int db = 0;
        static void Main(string[] args)
        {
            beolvas();
            legkisebb_osszeg();
            //leggyakoribb();
            Console.ReadKey();
        }

        private static void leggyakoribb()
        {
            
        }

        private static void legkisebb_osszeg()
        {
            int[] osszegek = new int[db];
            for (int i = 0; i < db; i++)
            {
                osszegek[i] = (nyeroszamok[i, 0] + nyeroszamok[i, 1] + nyeroszamok[i, 2] + nyeroszamok[i, 3] + nyeroszamok[i, 4]);
            }

            int[] hasznalhato = new int[db];

            for (int i = 0; i < osszegek.Length; i++)
            {
                if (osszegek[i] > 0)
                {
                    hasznalhato[i] = osszegek[i];
                }
            }

            int legkisebb = hasznalhato[0];
            int[] tomb_legkisebb = new int[db];
            int indeksz = 0;
            for (int i = 0; i < hasznalhato.Length; i++)
            {
                if (hasznalhato[i] < legkisebb && hasznalhato[i] > 0)
                {
                    legkisebb = hasznalhato[i];
                    tomb_legkisebb[indeksz] = legkisebb;
                    indeksz++;
                }
            }

            foreach (int value in tomb_legkisebb)
            {
                Console.Write(value + " ");
            }

            Array.Sort<int>(tomb_legkisebb);
            Array.Reverse(tomb_legkisebb);

            foreach (int value in tomb_legkisebb)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine($"Legkisebb összeg: {tomb_legkisebb[0]}, {tomb_legkisebb[1]}, {tomb_legkisebb[2]}");

            /*
            int[] tomb_legkisebb_rendez = new int[3500];
            int indeksz_2 = 0;
            for (int i = 0; i < tomb_legkisebb.Length; i++)
            {
                if (tomb_legkisebb[i] != 0)
                {
                    tomb_legkisebb_rendez[indeksz_2] = tomb_legkisebb[i];
                    indeksz_2++;
                }
            }

            Console.WriteLine();*/
        }

        private static void beolvas()
        {
            try
            {
                StreamReader be = new StreamReader("a.txt");
                string[] darab = new string[3500];
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    string egysor = be.ReadLine();
                    darab = egysor.Split(';');

                    ev[db] = Convert.ToInt32(darab[0]);
                    het[db] = Convert.ToInt32(darab[1]);
                    datum[db] = darab[2];
                    otos_talalatok[db] = Convert.ToInt32(darab[3]);
                    otos_nyer[db] = darab[4];
                    negyes_talalatok[db] = Convert.ToInt32(darab[5]);
                    negyes_nyer[db] = darab[6];
                    harmas_talalatok[db] = Convert.ToInt32(darab[7]);
                    harmas_nyer[db] = darab[8];
                    kettes_talalatok[db] = Convert.ToInt32(darab[9]);
                    kettes_nyer[db] = darab[10];
                    nyeroszamok[db, 0] = Convert.ToInt32(darab[11]);
                    nyeroszamok[db, 1] = Convert.ToInt32(darab[12]);
                    nyeroszamok[db, 2] = Convert.ToInt32(darab[13]);
                    nyeroszamok[db, 3] = Convert.ToInt32(darab[14]);
                    nyeroszamok[db, 4] = Convert.ToInt32(darab[15]);

                    db++;
                }
                be.Close();
                Console.WriteLine($"Előző heti nyerőszámok {nyeroszamok[0, 0]}, {nyeroszamok[0, 1]}, {nyeroszamok[0, 2]}, {nyeroszamok[0, 3]}, {nyeroszamok[0, 4]}");
                Console.WriteLine($"Múlt heti nyerőszámok {nyeroszamok[1, 0]}, {nyeroszamok[1, 1]}, {nyeroszamok[1, 2]}, {nyeroszamok[1, 3]}, {nyeroszamok[1, 4]}");
            }
            catch (IOException)
            {
                Console.WriteLine("rossz");
            }
        }
    }
}
