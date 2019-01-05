﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
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
            else
                retour[2][0] = -1;

            return (retour);
        }

        //Maintenant on regarde si il y a un quarto possible, sinon on place la pièce de manière aléatoire.

        public static void PlacerQuarto(int Piece, int[][] PlaceVide, int[][] plateau, string[] caracteristiques, out int ligne, out int colonne, string[][][] PlateauGraphique, string[][] PieceGraphique, int[] PieceDispo)
        {
            int i = 0;
            bool sortie = false; //nous permettra de sortir de la boucle while si on a un Quarto
            int[] PieceATester = new int[3]; // contiendra les 3 pièces à tester avec celle donnée par le joueur

            //On commence par les lignes
            while ((i < 4) && (!sortie))
            {
                //on commence par chercher si il y a une ligne avec une place disponible pour tenter le quarto
                if (PlaceVide[0][i] == -1) 
                    i++;

                // si il y a, on cherche à tester si un quarto est possible avec la pièce qui nous a été confiée.
                else 
                {
                    //On commence par remplir le tableau des pièces à tester avec les pièces non nulles de la ligne.
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if ((plateau[i][j] != 0) && (k < 3))
                        {
                            PieceATester[k] = plateau[i][j];
                            k++;
                        }
                    if (General.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, caracteristiques))
                    {
                        ligne = i;
                        colonne = PlaceVide[0][i];
                        General.PlacerPiece(Piece, ligne, colonne, caracteristiques, PieceGraphique, PlateauGraphique, plateau, PieceDispo);
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
                        if ((plateau[j][i] != 0)&&(k<3))
                        {
                            PieceATester[k] = plateau[j][i];
                            k++;
                        }
                    if (General.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, caracteristiques))
                    {
                        ligne = PlaceVide[1][i];
                        colonne = i;
                        General.PlacerPiece(Piece, ligne, colonne, caracteristiques, PieceGraphique, PlateauGraphique, plateau, PieceDispo);
                        sortie = true;
                        Console.WriteLine("Quarto sur la ligne {0}", i+1);
                    }
                }
            }

            //Au tour des diagonales
            //diagonale 1
            if ((PlaceVide[2][0] == -1) && (!sortie))
            {
                int k = 0;
                for (int j=0;j<4;j++)
                    if ((plateau[j][j]!=0)&&(k<3))
                    {
                        PieceATester[k] = plateau[j][j];
                        k++;
                    }
                if (General.Tester4Pieces(PieceATester[0],PieceATester[1],PieceATester[2],Piece,caracteristiques))
                {
                    ligne = PlaceVide[2][0];
                    General.PlacerPiece(Piece, ligne, ligne, caracteristiques, PieceGraphique, PlateauGraphique, plateau, PieceDispo);
                    sortie = true;
                    Console.WriteLine("Quarto sur la diagonale 1");
                }
            }

            //diagonale 2
            if ((PlaceVide[2][1] == -1) && (!sortie))
            {
                int k = 0;
                for (int j = 0; j < 4; j++)
                    if ((plateau[j][3-j] != 0) && (k < 3))
                    {
                        PieceATester[k] = plateau[j][3-j];
                        k++;
                    }
                if (General.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, caracteristiques))
                {
                    ligne = PlaceVide[2][1];
                    colonne = 3 - ligne;
                    General.PlacerPiece(Piece, ligne, colonne, caracteristiques, PieceGraphique, PlateauGraphique, plateau, PieceDispo);
                    Console.WriteLine("Quarto sur la diagonale 2");
                }
            }

            //on conclue en cas d'absence de quarto
            if (!sortie)
                General.JouerPieceAleatoire(Piece, out ligne, out colonne, plateau, PlateauGraphique, PieceGraphique,caracteristiques, PieceDispo);
        }


        //Maintenant on regarde si il y a des pieces qui pourraient potentiellement faire un quarto si bien placées, sinon on place la pièce de manière aléatoire.
        // Cette fonction renvoie un numero de piece qui empeche le joueur de gagner au tour suivant si c'est possible
        public static int ChoisirQuarto(int[][] PlaceVide, int[][] plateau, string[] caracteristiques, int[] PieceDispo)
        {
            // on parcourt la liste des pieces disponibles, on verifie si chacunes de ces pieces pourrait faire un quarto en parcourant toutes les places disponibles
            
            int[][] QuartoPossible = VerifierUnePlace(plateau);
            int somme = 0;
            for (int i = 0;i<3;i++)
            {
                foreach (int e in QuartoPossible[i])
                    somme+=e;
            }
            if (somme == -10) // cela veut dire que chaque colonne/ligne/diagonale possède strictement moins que 3 éléments et donc que peu importe la pièce choisie impossible qu'il y ait quarto au tour du joueur
                return General.ChoisirPieceAleatoire(PieceDispo);
            else
            {
                bool Gagne = true;
                int index = 0;
                while (Gagne == true && index < 16)
                {
                    if (PieceDispo[index] != 0) // Si la piece est disponible
                    {

                    }
                    index++;
                }
            }
            
        }

        public static string ElementCommun (int[][] plateau, string[] caracteristiques,int[][] QuartoPossible)
        {
            string Element = "";
            /*
            for (int type=0;type<2;type++)
            {
                for (int numero = 0; numero < 4; numero++)
                {
                    if (QuartoPossible[type][numero]!=-1)
                    {

                    }
                }
            }
            */
            for (int numero = 0; numero < 4; numero++) // if(element[
        }
    }
}
