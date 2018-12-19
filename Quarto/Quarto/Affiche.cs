using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Affiche
    {
        public static void AfficherRegles()
        {
            Console.WriteLine("============================================================");
        }


        // =========================================================================================

        //On affiche le plateau mis à jour
        public static void AfficherPlateau(string[][][] tab)
        {
            int j;
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 8; l++) //on parcours les lignes des pieces graphiques 1 par 1
                {
                    j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                    while (j < 4)
                    {
                        if (tab[i][j][l][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=blanc, v=vert)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(tab[i][j][l].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(tab[i][j][l].Substring(1));
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█"); // Choix de cette séparation
                        if ((l == 3) && (j == 3))
                            Console.Write("  {0}", i + 1);
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int l = 0; l < 4; l++)
                    Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄ ");
                Console.WriteLine();
            }
            for (int i = 0; i < 4; i++)
                Console.Write("      {0}      ", i + 1);
            Console.WriteLine();
        }

        // =========================================================================================

        //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut la prendre une
        // on n'affiche que les pièces disponibles, dans les cellules contenant un entier naturel non nul
        public static void AfficherPieceDisponible(string[][] graph, int[] dispo)
        {
            int j;

            //on affiche par 4 lignes de 4 pièces (en mettant du vide si la pièce n'est plus disponible)
            // ligne 1:
            for (int k = 0; k < 4; k++)
            {
                for (int i = 1; i < 8; i++) // on affiche ligne par ligne les pièces
                {
                    j = 4 * k;
                    while (j < 4 * (k + 1))
                    {
                        if (graph[dispo[j]][i][0] == 'b') // la pièce dispo va contenir l'entier correspondant à la pièce à présenter (peut valoir 17, ce qui oriente vers la pièce vide dans notre graph en place 16)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(graph[dispo[j]][i].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(graph[dispo[j]][i].Substring(1));
                        }
                        Console.Write("  ");
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 4 * k; i < 4 * (k + 1); i++) //on veut placer le numéro associé à la pièce 
                    if (i < 9)
                        Console.Write("      {0}       ", i + 1);
                    else
                        Console.Write("     {0}       ", i + 1);
                Console.WriteLine();
            }

        }
    }
}
