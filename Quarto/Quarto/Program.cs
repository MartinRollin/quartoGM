using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Program
    {
        //public static void AfficherVide(int[] tab)

        //public static void Afficher
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Euh.... Does it work?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What about now?");
            Console.ReadLine();
            Console.WriteLine("vive les chameaux chalumeaux");

            char[,][] tab = new char [2,1] [];
            tab[0, 0] = new char [] { 'l', 'a' };
            tab[1, 0] = new char[] { 'r', 'e' };
            foreach (char [] e in tab) 
                foreach (char j in e)
                {
                    Console.Write(j);
                }

        }
    }
}
