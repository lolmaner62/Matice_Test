using System;
using System.Collections.Generic;
using System.Text;

namespace Matice_Test.Classes
{
     class Matice
    {
        // jenom pro ukládání starých matic
        public int[,] matice;
        public string operace;
        public Matice(int[,] puvodni, string Operace)
        {
            matice = puvodni;
            operace = Operace;
        }

    }
}
