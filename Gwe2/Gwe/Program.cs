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
            int j;
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 8; l++) //on parcours les lignes des pieces graphiques 1 par 1
                {
                    j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                    while (j < 4)
                    {
                        if (tab[i][j][l][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=blanc, v=vert)
                            Console.Write(tab[i][j][l].Substring(1));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(tab[i][j][l].Substring(1));
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

        //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut la prendre une
        // on n'affiche que les pièces disponibles, dans les cellules contenant un entier naturel non nul
        public static void AfficherPieceDisponible(string[][] graph, int[] dispo)
        {
            int j;

//on affiche par 2 lignes de 8 pièces (en mettant du vide si la pièce n'est plus disponible)
// ligne 1:
            for (int i = 0; i < 8; i++) 
            {
                j = 0;
                while (j < 8)
                {
                    if (graph[dispo[i] - 1][j][0] == 'b') // la pièce dispo va contenir l'entier correspondant à la pièce à présenter (peut valoir 17, ce qui oriente vers la pièce vide dans notre graph en place 16)
                        Console.Write(graph[dispo[i - 1] - 1][j].Substring(1));
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(graph[dispo[i] - 1][j].Substring(1));
                    }
                    Console.Write("  ");
                    j++;
                }
                Console.WriteLine();
            }
                for (int i = 0; i < 8; i++) //on veut placer le numéro associé à la pièce 
                    Console.Write("     {0}       ", i+1);


//ligne 2:
            for (int i = 8; i < 16; i++) 
            {
                j = 8;
                while (j < 16)
                {
                    if (graph[dispo[i - 1] - 1][j][0] == 'b') // la pièce dispo va contenir l'entier correspondant à la pièce à présenter (peut valoir 17, ce qui oriente vers la pièce vide dans notre graph en place 16)
                        Console.Write(graph[dispo[i] - 1][j].Substring(1));
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(graph[dispo[i] - 1][j].Substring(1));
                    }
                    Console.Write("  ");
                    j++;
                }
                Console.WriteLine();
            }
            for (int i = 8; i < 16; i++) //on veut placer le numéro associé à la pièce 
                Console.Write("     {0}       ", i + 1);

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

        public static bool Tester4Pieces(int Piece1, int Piece2, int Piece3, int Piece4, string[][] tab)
        {
            bool sortie = false;
            int k = 0;
            while ((!sortie) && (k < 4))
                if ((tab[Piece1 - 1][k] == tab[Piece2 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece3 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece4 - 1][k]))
                    sortie = true;
                else
                    k++;
            

        }
        static void Main(string[] args)
        {
            string[] tab1 = { "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789", "d0123456789" };

            int[] Piecedispo = new int[16];
            for (int i = 0; i < 16; i++)
                Piecedispo[i] = 17;
            Piecedispo[3] = 4;

            string[][] graph = new string[17][];
            for (int i = 0; i < 17; i++)
            {
                graph[i] = new string[8];
                for (int k = 0; k < 8; k++)
                    graph[i][k] = "           ";
            }


            graph[3] = tab1;
            AfficherPieceDisponible(graph, Piecedispo);          
            Console.ReadLine();
            ;

        }
    }
}
