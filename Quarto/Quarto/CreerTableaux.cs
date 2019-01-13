using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class CreerTableaux
    {

        // =========================================================================================

        /// <summary>
        /// Renvoie la chaine de caractères correspondant à une pièce graphique, utilisée dans CreerTableauPieceGraphique uniquement
        /// </summary>
        public static string[] GenererPiece(string StringPiece)
        {
            string[] TabPiece = new string[10];

            for (int i = 0; i < 8; i++)
            {
                TabPiece[i] = StringPiece.Substring(i * 13, 13);
            }
            return TabPiece;
        }


        // =========================================================================================
        //
        /// <summary>
        /// Renvoie un tableau qui comprend le graphisme de chaque pièce par ligne en chaîne de caractère. la piece vide est la pièce 0 
        /// </summary>
        /// <returns></returns>
        public static string[][] CreerTableauPieceGraphique()
        {
            string[] Tab = new string[8];
            string[][] TableauPieceGraphique = new string[17][];

            // On remplit la première pièce comme une pièce vide
            TableauPieceGraphique[0] = new string[8];
            for (int i = 0; i < 8; i++)
            {
                TableauPieceGraphique[0][i] = "b            ";
            }


            // les chaines de caractères suivantes correspondent chacunes à une pièce. Le premier caractère de chaque ligne de chaque piece (ici "b") code la couleur de la pièce (ici bleu)
            Tab[0] = "b            b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b   ▀▄▄▄▄▀   b            ";
            Tab[1] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            Tab[2] = "b            b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b   ▀▄▄▄▄▀   b            ";
            Tab[3] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            Tab[4] = "b            b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            Tab[5] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            Tab[6] = "b            b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            Tab[7] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";

            //génération des 8 pièces bleues *on découpe chaque pièce en 8 lignes de 9 caractères*
            for (int i = 0; i < 8; i++)
            {
                TableauPieceGraphique[i + 1] = GenererPiece(Tab[i]);
            }

            // génération des 8 pièces vertes, on prend les pièces précédentes et on remplace le b par un v a chaque début de ligne. v qui code la couleur verte
            for (int i = 0; i < 8; i++)
            {
                TableauPieceGraphique[9 + i] = new string[8];
                for (int j = 0; j < 8; j++)
                {

                    TableauPieceGraphique[9 + i][j] = "v" + TableauPieceGraphique[i + 1][j].Substring(1, 12);
                }
            }



            return TableauPieceGraphique;
        }


        // =========================================================================================

        /// <summary>
        /// Initialise le plateau, c'est à dire créé et retourne le tableau ne contenant que des pièces vides
        /// </summary>
        /// <returns>retourne le tableau ne contenant que des pièces vides</returns>
        public static string[][][] InitialiserTableauPlateauGraphique(string[][] TableauPieceGraphique)
        {
            string[][][] TableauPlateauGraphique = new string[4][][];
            for (int i = 0; i < 4; i++)
            {
                TableauPlateauGraphique[i] = new string[4][];
                for (int j = 0; j < 4; j++)
                {
                    TableauPlateauGraphique[i][j] = new string[8];
                    TableauPlateauGraphique[i][j] = TableauPieceGraphique[0]; // la pièce stockée à la 1ère position de TableauPieceGraphique (donc en 0) est la pièce vide
                }
            }
            return TableauPlateauGraphique;
        }
    }
}
