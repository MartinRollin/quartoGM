using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Test
    {
        /// <summary>
        /// Vérifie que la position où veut jouer le joueur est bien disponible
        /// </summary>
        /// <param name="Ligne"></param>
        /// <param name="Colonne"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <returns></returns>
        public static bool VerifierPlaceVide(int Ligne, int Colonne, int[][] TableauPlateauCaracteristique)
        {
            if (TableauPlateauCaracteristique[Ligne][Colonne] == 0)
                return (true);
            else
                return (false);
        }


        /// <summary>
        /// Vérifie si la pièce est disponible
        /// </summary>
        /// <param name="Piece"></param>
        /// <param name="TableauPieceDisponible"></param>
        /// <returns></returns>
        public static bool VerifierpieceDisponible(int Piece, int[] TableauPieceDisponible)
        {
            if (TableauPieceDisponible[Piece] == 0)
                return (false);
            else
                return (true);
        }


        // On cherche à vérifier si 4 pièces sont alignées

        /// <summary>
        /// Vérifie si une colonne comporte 4 pièces
        /// </summary>
        /// <param name="Colonne"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <returns></returns>
        public static bool VerifierColonneVide(int Colonne, int[][] TableauPlateauCaracteristique) //on parcourt la colonne en comptant le nombre de pièces, si il vaut 4, alors la colonne est pleine
        {
            int NbPiece = 0;
            for (int i = 0; i < 4; i++)
                if (TableauPlateauCaracteristique[i][Colonne] != 0)
                    NbPiece++;
            if (NbPiece != 4)
                return (true);
            else
                return (false);
        }


        /// <summary>
        /// Vérifie si une ligne comporte 4 pièces
        /// </summary>
        /// <param name="Ligne"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <returns>Renvoie true si une ligne comporte 4 pièces</returns>
        public static bool VerifierLigneVide(int Ligne, int[][] TableauPlateauCaracteristique)
        {
            int NbPiece = 0;
            for (int j = 0; j < 4; j++)
                if (TableauPlateauCaracteristique[Ligne][j] != 0)
                    NbPiece++;
            if (NbPiece != 4)
                return (true);
            else
                return (false);
        }


        /// <summary>
        /// Vérifie si une diagonale (1 ou 2) comporte 4 pièces
        /// </summary>
        /// <param name="Numero"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <returns>renvoie true si une diagonale (1 ou 2) comporte 4 pièces</returns>
        public static bool VerifierDiagonale(int Numero, int[][] TableauPlateauCaracteristique)
        {
            int NbPiece = 0;
            if (Numero == 1)
            {
                for (int i = 0; i < 4; i++)
                    if (TableauPlateauCaracteristique[i][i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    if (TableauPlateauCaracteristique[i][3 - i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
        }


        /// <summary>
        /// Teste si 4 pièces (représentées par des entiers distincts compris entre 1 et 16) contiennent 1 caractère commun
        /// </summary>
        /// <param name="Piece1">numéro de la première pièce</param>
        /// <param name="Piece2">numéro de la deuxième pièce</param>
        /// <param name="Piece3">numéro de la troisième pièce</param>
        /// <param name="Piece4">numéro de la quatrième pièce</param>
        /// <param name="TableauPieceCaracteristique"></param>
        /// <returns> true si les quatres pièces ont au moins un caractère en commun</returns>
        public static bool Tester4Pieces(int Piece1, int Piece2, int Piece3, int Piece4, string[] TableauPieceCaracteristique)
        {
            bool sortie = false;
            int k = 0;

            //les caractéristiques sont représentées par une chaîne de 4 caractères. Si les 4 pièces ont un des caractères commun (au même emplacement) on renvoie true
            if (Piece1 != 0 && Piece2 != 0 && Piece3 != 0 && Piece4 != 0)
                while ((!sortie) && (k < 4))
                    if ((TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece2 - 1][k]) && (TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece3 - 1][k]) && (TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece4 - 1][k]))
                        sortie = true;
                    else
                        k++;

            return (sortie);
        }


        /// <summary>
        /// Mise à jour de QuartoPossible
        /// </summary>
        /// <param name="Ligne"></param>
        /// <param name="Colonne"></param>
        /// <param name="QuartoPossible"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <param name="TableauPieceCaracteristique"></param>
        public static void Scanner(int Ligne, int Colonne, string[] QuartoPossible, int[][] TableauPlateauCaracteristique, string[] TableauPieceCaracteristique)
        {
            //Quarto possible est de taille 3 car on part du principe qu'en posant une nouvelle pièce il ne peut y avoir qu'au maximum 3 quarto, sur la ligne, sur la colonne ou sur la diagonale.

            if (Tester4Pieces(TableauPlateauCaracteristique[Ligne][0], TableauPlateauCaracteristique[Ligne][1], TableauPlateauCaracteristique[Ligne][2], TableauPlateauCaracteristique[Ligne][3], TableauPieceCaracteristique) && !VerifierLigneVide(Ligne, TableauPlateauCaracteristique))
                QuartoPossible[0] = "ligne " + (Ligne + 1);
            else
                QuartoPossible[0] = "vide";
            if (Tester4Pieces(TableauPlateauCaracteristique[0][Colonne], TableauPlateauCaracteristique[1][Colonne], TableauPlateauCaracteristique[2][Colonne], TableauPlateauCaracteristique[3][Colonne], TableauPieceCaracteristique) && !VerifierColonneVide(Colonne, TableauPlateauCaracteristique))
                QuartoPossible[1] = "colonne " + (Colonne + 1);
            else
                QuartoPossible[1] = "vide";
            if (Colonne == Ligne)
                if (Tester4Pieces(TableauPlateauCaracteristique[0][0], TableauPlateauCaracteristique[1][1], TableauPlateauCaracteristique[2][2], TableauPlateauCaracteristique[3][3], TableauPieceCaracteristique) && VerifierDiagonale(1, TableauPlateauCaracteristique))
                    QuartoPossible[2] = "diagonale 1";
                else
                    QuartoPossible[2] = "vide";
            else
                if ((Colonne == 3 - Ligne) && Tester4Pieces(TableauPlateauCaracteristique[0][3], TableauPlateauCaracteristique[1][2], TableauPlateauCaracteristique[2][1], TableauPlateauCaracteristique[3][0], TableauPieceCaracteristique) && VerifierDiagonale(2, TableauPlateauCaracteristique))
                QuartoPossible[2] = "diagonale 2";
            else
                QuartoPossible[2] = "vide";

        }


        /// <summary>
        /// Vérifie que le quarto annoncé par le joueur est valable
        /// </summary>
        /// <param name="EntreeJoueur"></param>
        /// <param name="QuartoPossible"></param>
        /// <returns></returns>
        public static bool VerifierQuarto(string EntreeJoueur, string[] QuartoPossible)
        {
            bool Sortie = false;
            int k = 0;
            while ((!Sortie) && (k < 3))
                if (QuartoPossible[k] == EntreeJoueur)
                    Sortie = true;
                else
                    k++;
            return (Sortie);
        }

    }
}
