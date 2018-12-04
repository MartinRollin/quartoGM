using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][][,] tab = new char[4][][,];
            for (int k = 0; k < 4; k++)
                tab[k] = new char[4][,];
            char[,] tab2 = new char[10, 10];
            tab[0][0] = tab2;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tab[0][0][i, j] = 'a';
                    Console.Write(tab[0][0][i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
