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

            int[] legkisebb_sorozat = new int[5];
            int[] masodik_legkisebb_sorozat = new int[5];
            int[] harmadik_legkisebb_sorozat = new int[5];

            int[] legkisebbek = new int[3];
            int[] sor = new int[db];
            int legkisebb = 8000;

            for (int j = 0; j < db; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    sor[j] += nyeroszamok[j, k];
                }
            }

            for (int i = 0; i < db; i++)
            {
                if (sor[i] < legkisebb)
                {
                    legkisebb = sor[i];
                }
            }

            legkisebbek[0] = legkisebb;
            legkisebb = 8000;
            for (int i = 0; i < db; i++)
            {
                if (sor[i] < legkisebb && sor[i] != legkisebbek[0])
                {
                    legkisebb = sor[i];
                }
            }

            legkisebbek[1] = legkisebb;
            legkisebb = 8000;
            for (int i = 0; i < db; i++)
            {
                if (sor[i] < legkisebb && sor[i] != legkisebbek[0] && sor[i] != legkisebbek[1])
                {
                    legkisebb = sor[i];
                }
            }

            legkisebbek[2] = legkisebb;
            for (int i = 0; i < db; i++)
            {
                if (legkisebbek[0] == sor[i])
                {
                    for (int k = 0; k < 5; k++)
                    {
                        legkisebb_sorozat[k] = nyeroszamok[i, k];
                    }
                }
            }

            for (int i = 0; i < db; i++)
            {
                if (legkisebbek[1] == sor[i])
                {
                    for (int k = 0; k < 5; k++)
                    {
                        masodik_legkisebb_sorozat[k] = nyeroszamok[i, k];
                    }
                }
            }

            for (int i = 0; i < db; i++)
            {
                if (legkisebbek[2] == sor[i])
                {
                    for (int k = 0; k < 5; k++)
                    {
                        harmadik_legkisebb_sorozat[k] = nyeroszamok[i, k];
                    }
                }
            }


            Console.Write($"Első legkisebb összeg: {legkisebbek[0]}, nyerőszámok: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{legkisebb_sorozat[i]} ");
            }
            Console.WriteLine();

            Console.Write($"Második legkisebb összeg: {legkisebbek[1]}, nyerőszámok: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{masodik_legkisebb_sorozat[i]} ");
            }
            Console.WriteLine();

            Console.Write($"Harmadik legkisebb összeg: {legkisebbek[2]}, nyerőszámok: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{harmadik_legkisebb_sorozat[i]} ");
            }
            Console.WriteLine();
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
