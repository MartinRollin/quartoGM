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

    //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut en prendre une
    public static void AfficherPieceDisponible(char[][,] graph, int[] dispo)
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tab =
            {
                {1,2,3},
                {4,5,6}
            };
            Console.Write(tab[1,2]);
            Console.ReadLine();
            ;

        }
    }
}
