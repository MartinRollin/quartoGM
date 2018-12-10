using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{

    class Program
    {
        //On affiche le plateau mis à jour
        public static void AfficherPlateau(string[][][] tab)
        {
            int k;
            int j;
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 8; l++) //on parcours les lignes des pieces graphiques 1 par 1
                {
                    j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                    while (j < 4)
                    {
                        if (tab[i][j][l][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=blanc, v=vert)
                            Console.Write((tab[i][j][l].Substring(1)));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write((tab[i][j][l].Substring(1)));
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█"); // Choix de cette séparation        
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int l = 0; l < 4; l++)
                    Console.Write("▄▄▄▄▄▄▄▄▄▄ ");
                Console.WriteLine();
            }
        }

        //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut en prendre une (les unes au dessus des autres)
        public static void AfficherPieceDisponible(string[][] graph, int[] dispo)
        {
            for (int i = 0; i < 16; i++) //on parcours le tableau nous indiquant les pièces disponibles (de taille 16)
                if (dispo[i] != 0) // on n'affiche que les pièces disponibles, dans les cellules contenant un entier naturel non nul
                {
                    for (int k = 0; k < 8 ; k++)
                    {
                        if (graph[i][k][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=blanc, v=vert)
                            Console.Write((graph[i][k].Substring(1)));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write((graph[i][k].Substring(1)));
                        }
                        Console.WriteLine();
                    }
                    for (int j = 0; j < 4; j++) //on veut placer le numéro associé à la pièce 
                        Console.Write(" ");
                    Console.Write(i + 1);
                }
        }

        //On verifie que la position où veut jouer le joueur est disponible
        public static bool VerifierPlaceVide(int ligne, int colonne, int[][] tab)
        {
            if (tab[ligne][colonne] == 0)
                return (true);
            else
                return (false);
        }

        //on vérifie si la pièce est diponible
        public static bool VerifierpieceDisponible(int piece, int[] tab)
        {
            if (tab[piece - 1] == 0)
                return (false);
            else
                return (true);
        }

        // Afin de permettre à l'ordinateur de vérifier le Quarto, il doit d'abord checker si il y a 4 pièces alignées

        // Commençons par les colonnes
        public static bool VerifierColonneVide(int colonne, int[][] tab) //on parcours la colonne en comptant le nombre de pièce, si il vaut 4, alors la colonne est pleine
        {
            int NbPiece = 0;
            for (int i = 0; i < 4; i++)
                if (tab[i][colonne] != 0)
                    NbPiece++;
            if (NbPiece != 4)
                return (true);
            else
                return (false);
        }

        //Nous faisons de même pour les lignes
        public static bool VerifierLigneVide(int ligne, int[][] tab)
        {
            int NbPiece = 0;
            for (int j = 0; j < 4; j++)
                if (tab[ligne][j] != 0)
                    NbPiece++;
            if (NbPiece != 4)
                return (true);
            else
                return (false);
        }

        //pour les diagonales (on rentrera celle que l'on veut (1 ou 2))
        public static bool VerifierDiagonale(int laquelle, int[][] tab)
        {
            int NbPiece = 0;
            if (laquelle == 1)
            {
                for (int i = 0; i < 4; i++)
                    if (tab[i][i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
            else
            {
                for (int i = 0; i <4; i++)
                    if (tab[i][3-i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
        }
        static void Main(string[] args)
        {
            string[] tab1 = { "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789" };

            int[] Piecedispo = new int[16];
            for (int i = 0; i < 16; i++)
                Piecedispo[i] = 0;
            Piecedispo[3] = 4;

            string[][] graph = new string[16][];
            for (int i = 0; i < 16; i++)
                graph[i] = new string[8];

            graph[3] = tab1;
            AfficherPieceDisponible(graph, Piecedispo);          
            Console.ReadLine();
            ;

        }
    }
}
