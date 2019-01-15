using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class General
    {
        /// <summary>
        /// Insère une pièce dans le plateau et met tous les tableaux du plateau et le tableau PieceDisponible à jour
        /// </summary>
        /// <param name="Piece"></param>
        /// <param name="Ligne"></param>
        /// <param name="Colonne"></param>
        /// <param name="TableauPieceCaracteristique"></param>
        /// <param name="TableauPieceGraphique"></param>
        /// <param name="TableauPlateauGraphique"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <param name="TableauPiecesDisponible"></param>
        public static void PlacerPiece (int Piece, int Ligne, int Colonne,string[] TableauPieceCaracteristique, string[][] TableauPieceGraphique,string[][][] TableauPlateauGraphique,int[][] TableauPlateauCaracteristique,int[] TableauPiecesDisponible)
        {
            TableauPlateauGraphique[Ligne][Colonne] = TableauPieceGraphique[Piece];
            TableauPlateauCaracteristique[Ligne][Colonne] = Piece;
            TableauPiecesDisponible[Piece - 1] = 0;
        }


        /// <summary>
        /// Choisit aléatoirement une pièce et l'enlève du tableau PieceDisponible
        /// </summary>
        /// <param name="TableauPieceDisponible"></param>
        /// <returns></returns>
        public static int ChoisirPieceAleatoire(int[] TableauPieceDisponible)
        {
            Random rand = new Random();
            int Sortie = rand.Next(1,17);

            while (TableauPieceDisponible[Sortie-1] == 0)
                Sortie = rand.Next(1,17);
            TableauPieceDisponible[Sortie - 1] = 0;
            return (Sortie);
        }


        /// <summary>
        /// Joue une pièce aléatoirement (pour l'ordinateur)
        /// </summary>
        /// <param name="Piece"></param>
        /// <param name="Ligne"></param>
        /// <param name="Colonne"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <param name="TableauPlateauGraphique"></param>
        /// <param name="TableauPieceGraphique"></param>
        /// <param name="tableauPieceCaracteristique"></param>
        /// <param name="tableauPiecesDisponible"></param>
        public static void JouerPieceAleatoire (int Piece, out int Ligne, out int Colonne, int[][] TableauPlateauCaracteristique, string [][][] TableauPlateauGraphique, string [][] TableauPieceGraphique, string[] tableauPieceCaracteristique, int[]tableauPiecesDisponible)
        {
            // on compte le nombre de cases vides
            int NbCasesVides = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Test.VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                        NbCasesVides++;
                }
            }

            // CaseDispo est un tabeau qui stocke des tableaux d'entiers de la forme [ligne,colonne] tels que ligne et colonne sont les indices de ligne et colonne des cases vides du plateau
            int[][] CaseDispo = new int[NbCasesVides][];
            int Index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Test.VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                    {
                        CaseDispo[Index] = new int [] { i+1 , j+1 };
                        Index++; 
                    }
                }
            }

            // On choisit une case vide aleatoire, on actualise la derniere Ligne et la derniere Colonne jouees et on remplit le tableau caracteristique et le 
            Random R = new Random();
            int a = R.Next(NbCasesVides);
            Ligne = CaseDispo[a][0];
            Colonne = CaseDispo[a][1];
            PlacerPiece(Piece, Ligne-1, Colonne-1, tableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, tableauPiecesDisponible);
        }

      

    }
}
