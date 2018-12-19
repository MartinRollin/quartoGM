using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class General
    {



        public static void PlacerPiece (int numeroPiece, int lignePiece, int colonnePiece,string[] tableauPieceCaracteristique, string[][] tableauPieceGraphique,string[][][] tableauPlateauGraphique,int[][] tableauPlateauCaracteristique,int[]tableauPiecesDisponible)
        {
            // On insère une piece qui occupe la position numeroPiece dans tableauPieceGraphique à la ligne lignePiece et la colonne colonnePiece dans tous les tableaux considérés

            tableauPlateauGraphique[lignePiece][colonnePiece] = tableauPieceGraphique[numeroPiece];
            tableauPlateauCaracteristique[lignePiece][colonnePiece] = numeroPiece;
            tableauPiecesDisponible[numeroPiece-1] = 0;
        }

        // =========================================================================================

        //On verifie que la position où veut jouer le joueur est disponible
        public static bool VerifierPlaceVide(int ligne, int colonne, int[][] tab)
        {
            if (tab[ligne][colonne] == 0)
                return (true);
            else
                return (false);
        }

        // =========================================================================================

        //on vérifie si la pièce est diponible
        public static bool VerifierpieceDisponible(int piece, int[] tab)
        {
            if (tab[piece] == 0)
                return (false);
            else
                return (true);
        }

        // =========================================================================================

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

        // =========================================================================================

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

        // =========================================================================================

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
                for (int i = 0; i < 4; i++)
                    if (tab[i][3 - i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
        }

        // =========================================================================================

        //on teste si 4 pièces (représentées pas des entiers distincts compris entre 1 et 16) contienne 1 caractère commun
        public static bool Tester4Pieces(int Piece1, int Piece2, int Piece3, int Piece4, string[][] tab)
        {
            bool sortie = false;
            int k = 0;
            //les caractères sont représentés par une chaine de 4 caractères. Si les 4 pièces ont un des caractères commun (au même emplacement) on renvoie true
            while ((!sortie) && (k < 4))
                if ((tab[Piece1 - 1][k] == tab[Piece2 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece3 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece4 - 1][k]))
                    sortie = true;
                else
                    k++;
            return (sortie);
        }

        // =========================================================================================

        public static int ChoisirPieceAleatoire(int[] piecesdispo)
        {
            Random rand = new Random();
            int sortie = rand.Next(1,17);
            while (piecesdispo[sortie-1] == 0)
                sortie = rand.Next(1,17);
            return (sortie);
        }

        // =========================================================================================

        public static void JouerPieceAleatoire (int NumeroPiece, out int Ligne, out int Colonne, int[][] TableauPlateauCaracteristique, string [][][] TableauPlateauGraphique, string [][] TableauPieceGraphique, string[] tableauPieceCaracteristique, int[]tableauPiecesDisponible)
        {
            // Fonction appelee lorsque l'ordinateur veut placer une piece
            // on compte le nombre de cases vides

            int nbCasesVides = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                        nbCasesVides++;
                }
            }

            // casedispo est un tabeau qui stocke des tableaux d'entiers de la forme [ligne,colonne] tels que ligne et colonne sont les indices de ligne et colonne des cases vides du plateau
            int[][] casedispo = new int[nbCasesVides][];
            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                    {
                        casedispo[index] = new int [] { i , j };
                        index++; 
                    }
                }
            }

            // On choisit une case vide aleatoire, on actualise la derniere Ligne et la derniere Colonne jouees et on remplit le tableau caracteristique et le 
            Random R = new Random();
            int a = R.Next(nbCasesVides);
            Ligne = casedispo[a][0];
            Colonne = casedispo[a][1];
            PlacerPiece(NumeroPiece, Ligne, Colonne, tableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, tableauPiecesDisponible);
        }


        

    }
}
