using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Matice_Test.Classes;
namespace Matice_Test
{
    class Program
    {
        static List<Matice> Stare = new List<Matice>();
        static int[,] NasobeniMatic(int[,] matrixA, int[,] matrixB) 
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);
            int[,] resultMatrix = new int[rowsA, colsB];
            
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return resultMatrix;
        }
        static bool OverNasobeni(int[,] skibidi, int[,] skibidi2)
        {
            if (skibidi.GetLength(1) == skibidi2.GetLength(0))
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Počet sloupců první matice musí být roven počtu řádků druhé matice");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
        }
        static int[,] Transponuj(int[,] input)
        {
            int[,] output = new int[input.GetLength(1), input.GetLength(0)];
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    output[i, j] = input[j, i];
                }
            }
            return output;
        }
        static int[,] NasobJednimCislem(int[,] input, int nasobitel)
        {
            int[,] output = new int[input.GetLength(0), input.GetLength(1)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    output[i,j] = input[j, i] * nasobitel;
                }
            }
            return output;
        }
        static int[,] secti_nebo_odecti_pole(int[,] skibidi, int[,] skibidi2, bool soucet, bool prohozeni = false)
        {

            
            int[,] vysledek = new int[skibidi.GetLength(0), skibidi.GetLength(1)];
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
            else if(prohozeni == false)
            {
                for (int i = 0; i < vysledek.GetLength(0); i++)
                {
                    for (int j = 0; j < vysledek.GetLength(1); j++)
                    {
                        vysledek[i, j] = skibidi[i, j] - skibidi2[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < vysledek.GetLength(0); i++)
                {
                    for (int j = 0; j < vysledek.GetLength(1); j++)
                    {
                        vysledek[i, j] = skibidi2[i, j] - skibidi[i, j];
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Pocet sloupcu a radku musí být v obou maticich stejný, zadejte znovu matice:");
            Console.ForegroundColor = ConsoleColor.White;
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
        static void VypisStare()
        {
            if (Stare.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zatím žádné uložené výsledky");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Zmackni cokoliv pro pokracovani");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Vypsaní starých výsledků \nzmackni cokoliv pro pokracovani");
            Console.ReadKey();
            for (int i = 0; i < Stare.Count; i++)
            {
                var item = Stare[i];
                Console.WriteLine($"{i + 1}: {item.operace}: ");
                vypis(item.matice);
                Console.WriteLine("_______________________________________________________________");
            }
            Console.WriteLine("zmackni cokoliv pro pokracovani");
            Console.ReadKey();
        }
        static int Nabidka()
        {
            Console.WriteLine("Vyber operaci: \n 0 - Opustit \n 1 - Suma \n 2 - Rozdíl \n 3 - Transponace \n 4 - Vynásobení jedním číslem \n 5 - Násobení matic \n 6 - Vypsání doposud vypočítaných matic");
            int navratova = Convert.ToInt32(Console.ReadLine());
            return navratova;
        }
        static void Vypnout()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vypínání");
            Console.ForegroundColor = ConsoleColor.White;
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
        static void Transponace()
        {
            Console.WriteLine("Transponace \nZmáčkni cokoliv pro pokračování ");
            Console.ReadKey();
            int[,] matice = NactiCisly();
            Console.WriteLine("Matice:");
            vypis(matice);
            Console.WriteLine("Zmáčkni cokoliv pro pokračování ");
            Console.ReadKey();
            Console.WriteLine("Výsledek: \n ___________________________________________");
            int[,] matice_vysledek = Transponuj(matice);
            Stare.Add(new Matice(matice_vysledek, "Transponace"));
            vypis(matice_vysledek);
            Console.WriteLine("Zmáčkni cokoliv pro pokračování ");
            Console.ReadKey();
            Console.WriteLine("___________________________________________________________________ \n \n");
        }
        static void Soucet()
        {
            bool opakovani;
            int[,] matice_vysledek;
            int[,] matice;
            int[,] matice2;
            Console.WriteLine("Součet \nZmáčkni cokoliv pro pokračování");
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
            Stare.Add(new Matice(matice_vysledek, "Soucet"));
            Console.WriteLine("Vysledek je:\n______________________________________________________");
            vypis(matice_vysledek);
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            Console.WriteLine("___________________________________________________________________ \n \n");

        }
        static void Nasobeni()
        {
            int[,] matice;
            Console.WriteLine("Nasobení jedním číslem \nZmáčkni cokoliv pro pokračování");
            Console.ReadKey();
            matice = NactiCisly();
            Console.WriteLine("Cislo kterym chcete nasobit:");
            int nasobitel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("______________________________");
            vypis(matice);
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"Nasobitel je: {nasobitel}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Zmáčkni cokoliv pro pokračování\n");
            Console.ReadKey();
            int[,] matice_vysledek = NasobJednimCislem(matice, nasobitel);
            Stare.Add(new Matice(matice_vysledek, "Nasobeni jedním číslem"));
            Console.WriteLine("Výsledek: \n ___________________________");
            vypis(matice_vysledek);
            Console.WriteLine("Zmáčkni cokoliv pro pokračování\n");
            Console.ReadKey();
            Console.WriteLine("___________________________");



        }
        static void Rozdil()
        {
            bool opakovani;
            int[,] matice_vysledek;
            int[,] matice;
            int[,] matice2;
            bool prohozeni;
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
            Console.WriteLine("Zvolte: \n 1 - matice1 - matice2 \n2 - matice2 - matice1");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                prohozeni = false;
            }
            else
            {
                prohozeni = true;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("První matice:");
            vypis(matice);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Druhá matice:");
            vypis(matice2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            matice_vysledek = secti_nebo_odecti_pole(matice, matice2,false, prohozeni);
            Stare.Add(new Matice(matice_vysledek, "Rozdíl"));
            Console.WriteLine("Vysledek je:\n______________________________________________________");
            vypis(matice_vysledek);
            Console.WriteLine("Stiskni pro pokracovani");
            Console.ReadKey();
            Console.WriteLine("___________________________________________________________________ \n \n");

        }
        static void NasobitMatky()
        {
            bool opakovani;
            int[,] matice_vysledek;
            int[,] matice;
            int[,] matice2;
            Console.WriteLine("Nasobení dvou matic \n Zmáčkni cokoliv pro pokračování");
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
                opakovani = OverNasobeni(matice, matice2);
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
            matice_vysledek = NasobeniMatic(matice, matice2);
            Stare.Add(new Matice(matice_vysledek, "Nasobení"));
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
                try
                {
                    operace = Nabidka();
                    switch (operace)
                    {
                        case 0:
                            Vypnout();
                            break;
                        case 1:
                            Soucet();
                            break;
                        case 2:
                            Rozdil();
                            break;
                        case 3:
                            Transponace();
                            break;
                        case 4:
                            Nasobeni();
                            break;
                        case 5:
                            NasobitMatky();
                            break;
                        case 6:
                            VypisStare();
                            break;
                        default:
                            Console.WriteLine("Asi si zmackl neco co si nemel, dej si to znova :)");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Něco se nepovedlo nebo invalidní input");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                


            }


        }
    }
}
