using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{

    //On affiche le plateau mis à jour
    public static void AfficherPlateau(char[][][,] tab)
    {
        int k;
        int j;
        for (int i = 0; i < 4; i++)
        {
            for (int l = 0; l < tab[0][0].Length; l++) //on parcours les lignes des pieces graphiques 1 par 1
            {
                j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                while (j < 4)
                {
                    k = 0;
                    while (k < tab[i][j].Length)
                    {
                        Console.Write(tab[i][j][k, l]);
                        k++;
                    }
                    Console.Write("|"); // Choix de cette séparation
                    j++;
                }
                Console.WriteLine();
            }
            for (int l = 0; l < tab[0][0].Length; l++)
                Console.Write("_");
        }
    } 

    //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut en prendre une (lesunes au dessus des autres)
    public static void AfficherPieceDisponible(char[][,] graph, int[] dispo)
    {
        for (int i=0; i<16;i++) //on parcours le tableau nous indiquant les pièces disponibles (de taille 16)
            if (dispo[i]!=0) // on n'afiche que les pièces disponibles
            {
                for (int k = 0; k < graph[0].Length; k++)
                {
                    for (int l = 0; l < graph[0].Length; l++)
                        Console.Write(graph[i][k, l]);
                    Console.WriteLine();
                }
                for (int j = 0; j < (graph[0].Length / 2); j++) //on veut placer le numéro associé à la pièce 
                    Console.Write(" ");
                Console.Write(i + 1);
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tab1 =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            char[][][,] tab = new char[1][][,];
            tab[0] = new char[1][,] ;
            tab[0][0] = tab1;          
            Console.ReadLine();
            ;

        }
    }
}
