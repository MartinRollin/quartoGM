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

        public static void PlacerPiece (int numeroPiece, int lignePiece, int colonnePiece,string[][] tableauPieceCaracteristique, string[][] tableauPieceGraphique,string[][] tableauPlateauGraphique,int[][]tableauPlateauCaracteristique,int[]tableauPiecesDisponibles)
        {
            tableauPieceGraphique[lignePiece][colonnePiece] = CreerTableauPieceGraphique()[numeroPiece];    // depend un peu, c'est numeroPiece ou numeroPiece-1
            tableauPieceCarcteristiques[lignePiece][colonnePiece] = CreerTableauPieceCaracteristique()[numeroPiece];

        }



        static void Main(string[] args)
        {
            // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (c)reu/(p)lein "
            string[] tableauPieceCaracteristique = ["pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp"];

        }
    }
}
