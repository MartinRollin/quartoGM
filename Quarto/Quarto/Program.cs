using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Program
    {



        public static string[] GenererPiece(string strPiece)
        // fonction qui renvoie la chaine de caractere correspondant à une piece graphique
        {
            string[] tabPiece = new string[10];

            for (int i = 0; i < 8; i++)
            {
                tabPiece[i] = strPiece.Substring(i * 13, 13);
            }
            return tabPiece;
        }


        // =========================================================================================

        public static string[][] CreerTableauPieceGraphique()
        //renvoie un tableau qui comprend le graphisme de chaque piece par ligne en chaine de caractere. la piece vide est la piece 17
        {
            string[] tab = new string[8];
            string[][] tableauPieceGraphique = new string[17][]; // La 17 eme piece est la piece vide

            // les chaines de caracteres suivantes correspondent chacune à une piece. Le premier caractere de chaque ligne de chaque piece (ici "b") code la couleur de la piece (ici bleu)
            tab[0] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[1] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[2] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[3] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[4] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[5] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[6] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[7] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";

            //generation des pieces blanches *on decoupe chaque piece en 8 lignes de 13 caracteres*
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[i] = GenererPiece(tab[i]);
            }

            // generation des pieces noires, on prend les pieces precedentes et on remplace le b par un v a chaque debut de ligne. v qui code la couleur verte
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[8 + i] = new string[8];
                for (int j = 0; j < 8; j++)
                {

                    tableauPieceGraphique[8 + i][j] = "v" + tableauPieceGraphique[i][j].Substring(1, 12);
                }
            }

            // On remplit la derniere piece comme une piece vide
            tableauPieceGraphique[16] = new string[8];
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[16][i] = "b            ";
            }

            return tableauPieceGraphique;
        }

        // =========================================================================================


        public static string[][][] InitialiserTableauPlateauGraphique()
        // cette fonction renvoie le tableau initialise, c'est à dire ne contenant que des pieces vides
        {
            string[][][] tableauPlateauGraphique = new string[4][][];
            string[][] pieceVide = CreerTableauPieceGraphique();        // la piece stockée à la 16 eme position de pieceVide est la pièce vide
            for (int i = 0; i < 4; i++)
            {
                tableauPlateauGraphique[i] = new string[4][];
                for (int j = 0; j < 4; j++)
                {
                    tableauPlateauGraphique[i][j] = new string[8];
                    tableauPlateauGraphique[i][j] = pieceVide[16];
                }
            }
            return tableauPlateauGraphique;
        }

        // =========================================================================================

        public static void PlacerPiece (int numeroPiece, int lignePiece, int colonnePiece,string[][] tableauPieceCaracteristique, string[][] tableauPieceGraphique,string[][] tableauPlateauGraphique,int[][]tableauPlateauCaracteristique,int[]tableauPiecesDisponible)
        {
            // On insère une piece qui occupe la position numeroPiece dans tableauPieceGraphique à la ligne lignePiece et la colonne colonnePiece dans tous les tableaux considérés

            tableauPlateauGraphique[lignePiece][colonnePiece] = tableauPieceGraphique[numeroPiece-1];               // depend un peu, c'est numeroPiece ou numeroPiece-1
            tableauPlateauCaracteristique[lignePiece][colonnePiece] = numeroPiece; // comme au dessus
            tableauPiecesDisponible[NumeroPiece] = 0;
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

        // =========================================================================================

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
                Console.Write("     {0}       ", i + 1);


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

        static void Main(string[] args)
        {
            // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (c)reu/(p)lein "
            string [] tableauPieceCaracteristique = { "pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp" };


            //test de PlacerPiece
            string [][] tableauPieceGraphique = CreerTableauPieceGraphique();
            string [][][] tableauPlateauGraphique = InitialiserTableauPlateauGraphique();
            int [] tableauPieceDispo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDispo);
            Console.ReadLine();
            PlacerPiece(2, 1, 1, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, tableauPiecesDisponible);
            AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDispo);
            Console.ReadLine();
        }
    }
}
