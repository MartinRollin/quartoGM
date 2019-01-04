using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class CreerTableaux
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
            string[][] tableauPieceGraphique = new string[17][]; // La premiere piece est la piece vide

            // On remplit la derniere piece comme une piece vide
            tableauPieceGraphique[0] = new string[8];
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[0][i] = "b            ";
            }

            // les chaines de caracteres suivantes correspondent chacunes à une piece. Le premier caractere de chaque ligne de chaque piece (ici "b") code la couleur de la piece (ici bleu)
            tab[0] = "b            b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[1] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[2] = "b            b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[3] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[4] = "b            b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[5] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[6] = "b            b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[7] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";

            //generation des 8 pieces blanches *on decoupe chaque piece en 8 lignes de 13 caracteres*
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[i + 1] = GenererPiece(tab[i]);
            }

            // generation des 8 pieces noires, on prend les pieces precedentes et on remplace le b par un v a chaque debut de ligne. v qui code la couleur verte
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[9 + i] = new string[8];
                for (int j = 0; j < 8; j++)
                {

                    tableauPieceGraphique[9 + i][j] = "v" + tableauPieceGraphique[i + 1][j].Substring(1, 12);
                }
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
                    tableauPlateauGraphique[i][j] = pieceVide[0];
                }
            }
            return tableauPlateauGraphique;
        }
    }
}
