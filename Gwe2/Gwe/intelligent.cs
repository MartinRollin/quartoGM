using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{
    class intelligent
    {

    // L'ordi repère les quartos qu'il pourrait faire avec la pièce qu'on lui a donné à jouer

     // On commence par chercher les lignes/colonnes/diagonales où il ne reste qu'une place
        
        public static int[][] VerifierUnePlace( int[][] Plateau)
        {
            int[][] retour = new int[3][];
            int compteur;
            int donnee;
            //on commence par regarder les lignes du tableau
            retour[0] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                donnee = 0;
                compteur = 0;
                for (int j = 0; j < 4; j++)
                    if (Plateau[i][j] != 0)
                        compteur++;
                    else
                        donnee = j;

                if (compteur == 3)
                    retour[0][i] = donnee;
                else
                    retour[0][i] = -1;
            }

            //les colonnes maintenant
            retour[1] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                donnee = 0;
                compteur = 0;
                for (int j = 0; j < 4; j++)
                    if (Plateau[j][i] != 0)
                        compteur++;
                    else
                        donnee = j;

                if (compteur == 3)
                    retour[1][i] = donnee;
                else
                    retour[1][i] = -1;
            }

            //au tour des diagonales
            retour[2] = new int[2]; // il n'existe que deux diagonales.

            //penchons nous sur la diagonale 1
            donnee = 0;
            compteur = 0;
            for (int i=0; i<4; i++)
            {
                if (Plateau[i][i] != 0)
                    compteur++;
                else
                    donnee = i;
            }
            if (compteur == 3)
                retour[2][0] = donnee;
            else
                retour[2][0] = -1;

            //la diagonale 2 maintenant
            donnee = 0;
            compteur = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Plateau[i][3-i] != 0)
                    compteur++;
                else
                    donnee = i;
            }
            if (compteur == 3)
                retour[2][1] = donnee;

            return (retour);
        }

        //Maintenant on regarde si il y a un quarto possible, sinon on place la pièce de manière aléatoire.

        public static void PlacerQuarto(int Piece, int[][] PlaceVide, int[][] plateau, string[] caracteristiques)
        {
            int i = 0;
            bool sortie = false; //nous permettra de sortir de la boucle while si on a un Quarto
            int[] PieceATester = new int[3];

            //On commence par les lignes
            while ((i < 4) && (!sortie))
            {

                if (PlaceVide[0][i] == -1)
                    i++;
                else
                {
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if ((plateau[i][j] != -1)&&(k<3))
                        {
                            PieceATester[k] = plateau[i][j];
                            k++;
                        }
                    if (aléatoire.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, caracteristiques))
                    {
                        plateau[i][PlaceVide[0][i]] = Piece;
                        sortie = true;
                        Console.WriteLine("Quarto sur la ligne {0}", i+1);
                    }
                }
            }

            //On enchaîne sur les colonnes
            i = 0;
            while ((i < 4) && (!sortie))
            {
                if (PlaceVide[1][i] == -1)
                    i++;
                else
                {
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if ((plateau[j][i] != -1)&&(k<3))
                        {
                            PieceATester[k] = plateau[j][i];
                            k++;
                        }
                    if (aléatoire.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, caracteristiques))
                    {
                        plateau[i][PlaceVide[1][i]] = Piece;
                        sortie = true;
                        Console.WriteLine("Quarto sur la ligne {0}", i+1);
                    }
                }
            }
        }
    }
}
