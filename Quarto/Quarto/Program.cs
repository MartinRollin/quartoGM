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
        {

            string[] tabPiece = new string[10];

            for (int i = 0; i < 8; i++)
            {
                tabPiece[i] = strPiece.Substring(i * 13, 13);
            }

            return tabPiece;
        }

        public static string[][] CreerTableauPieceGraphique()  //renvoie un tableau qui comprend le graphisme de chaque piece par ligne en chaine de caractere. la piece vide est la piece 17
        {
            string[] tab = new string[8];
            string[][] tableauPieceGraphique = new string[16][];
            // les chaines de caracteres suivantes correspondent chacune à une piece. Le premier caractere de la ligne (ici "b") code la couleur de la piece
            tab[0] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[1] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[2] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[3] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[4] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[5] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[6] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[7] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";


            //generation des pieces blanches
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[i] = GenererPiece(tab[i]);
            }


            // generation des pieces noires
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[7 + i] = new string[8];
                for (int j = 0; i < 8; j++)
                {
                    tableauPieceGraphique[7 + i][j] = "v" + tableauPieceGraphique[i][j].Substring(1, 12);
                }

            }
            return tableauPieceGraphique;
        }

        static void Main(string[] args)
        {

        }
    }
}
