using System;

namespace Matice_Test
{
    class Program
    {
        static int[,] secti_nebo_odecti_pole(int[,] skibidi, int[,] skibidi2, bool soucet)
        {

            
            int[,] vysledek = new int[skibidi.GetLength(0), skibidi.GetLength(0)];
            if (soucet)
            {
                for (int i = 0; i < vysledek.GetLength(0); i++)
                {
                    for (int j = 0; j < vysledek.GetLength(1); j++)
                    {
                        vysledek[i, j] = skibidi[i, j] + skibidi2[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < vysledek.GetLength(0); i++)
                {
                    for (int j = 0; j < vysledek.GetLength(1); j++)
                    {
                        vysledek[i, j] = skibidi[i, j] - skibidi2[i, j];
                    }
                }
            }
            return vysledek;
        }
        static bool OvereniSuma(int[,] skibidi, int[,] skibidi2)
        {
            if (skibidi.GetLength(0) == skibidi2.GetLength(0) && skibidi.GetLength(1) == skibidi2.GetLength(1))
            {
                return false;
            }
            Console.WriteLine("Pocet sloupcu a radku musí být v obou maticich stejný, zadejte znovu matice:");
            return true;
        }
        static int[,] NactiCisly()
        {
            int sloupce;
            int radky;
            int min = 1;
            int max = 1000;
            while (true)
            {
                Console.WriteLine("Pocet radku:");
                radky = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pocet sloupcu:");
                sloupce = Convert.ToInt32(Console.ReadLine());
                if (radky > 10 || sloupce > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Max radku/sloupcu je 10");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else
                {
                    break;
                }
            }
            Random nahodna = new Random();
            int[,] skibidi = new int[radky, sloupce];
            for (int i = 0; i < skibidi.GetLength(0); i++)
            {
                for (int j = 0; j < skibidi.GetLength(1); j++)
                {
                    skibidi[i, j] = nahodna.Next(min, max);
                }
            }

            return skibidi;

        }
        static int Nabidka()
        {
            Console.WriteLine("Vyber operaci: \n 0 - Opustit \n 1 - Suma \n 2 - Rozdíl \n 3 - Transponace \n 4 - Vynásobení jedním číslem \n 5 - Násobení matic");
            int navratova = Convert.ToInt32(Console.ReadLine());
            return navratova;
        }
        static void Vypnout()
        {
            Console.WriteLine("Vypínání");
            Environment.Exit(0);
        }
        static void vypis(int[,] skibidi)
        {
            for (int i = 0; i < skibidi.GetLength(0); i++)
            {

                for (int j = 0; j < skibidi.GetLength(1); j++)
                {
                    Console.Write(skibidi[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Soucet()
        {
            bool opakovani;
            int[,] matice_vysledek;
            int[,] matice;
            int[,] matice2;
            Console.WriteLine("Součet \n Zmáčkni cokoliv pro pokračování");
            Console.ReadKey();
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("První matice:");
                Console.ForegroundColor = ConsoleColor.White;
                matice = NactiCisly();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("______________________________________________________\nDruhá matice:");
                Console.ForegroundColor = ConsoleColor.White;
                matice2 = NactiCisly();
                opakovani = OvereniSuma(matice, matice2);
            } while (opakovani);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("První matice:");
            vypis(matice);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Druhá matice:");
            vypis(matice2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            matice_vysledek = secti_nebo_odecti_pole(matice, matice2,true);
            Console.WriteLine("Vysledek je:\n______________________________________________________");
            vypis(matice_vysledek);
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            Console.WriteLine("___________________________________________________________________ \n \n");

        }
        static void Rozdil()
        {
            bool opakovani;
            int[,] matice_vysledek;
            int[,] matice;
            int[,] matice2;
            Console.WriteLine("Rozdíl \n Zmáčkni cokoliv pro pokračování");
            Console.ReadKey();
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("První matice:");
                Console.ForegroundColor = ConsoleColor.White;
                matice = NactiCisly();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("______________________________________________________\nDruhá matice:");
                Console.ForegroundColor = ConsoleColor.White;
                matice2 = NactiCisly();
                opakovani = OvereniSuma(matice, matice2);
            } while (opakovani);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("První matice:");
            vypis(matice);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Druhá matice:");
            vypis(matice2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            matice_vysledek = secti_nebo_odecti_pole(matice, matice2,false);
            Console.WriteLine("Vysledek je:\n______________________________________________________");
            vypis(matice_vysledek);
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            Console.WriteLine("___________________________________________________________________ \n \n");

        }
        static void Main(string[] args)
        {
            
            int operace;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Calculator matic 3000");
            while(true)
            {
                operace = Nabidka();
                switch (operace)
                {
                    case 0: Vypnout();
                        break;
                    case 1:
                        Soucet();
                        break;
                    case 2:
                        Rozdil();
                        break;

                    default:
                        Console.WriteLine("Asi si zmackl neco co si nemel, dej si to znova :)");
                        break;
                }


            }


        }
    }
}
