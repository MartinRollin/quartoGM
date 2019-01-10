using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class General
    {

        // =========================================================================================
        // On insère une piece dans le plateau (ce qui sous-entend mettre tout les tableaux du plateau et le tableau PieceDisponible à jour)

        public static void PlacerPiece (int Piece, int Ligne, int Colonne,string[] TableauPieceCaracteristique, string[][] TableauPieceGraphique,string[][][] TableauPlateauGraphique,int[][] TableauPlateauCaracteristique,int[] TableauPiecesDisponible)
        {
            TableauPlateauGraphique[Ligne][Colonne] = TableauPieceGraphique[Piece];
            TableauPlateauCaracteristique[Ligne][Colonne] = Piece;
            TableauPiecesDisponible[Piece - 1] = 0;
        }

   
        // =========================================================================================
        //On verifie que la position où veut jouer le joueur est bien disponible

        public static bool VerifierPlaceVide(int Ligne, int Colonne, int[][] TableauPlateauCaracteristique)
        {
            if (TableauPlateauCaracteristique[Ligne][Colonne] == 0)
                return (true);
            else
                return (false);
        }


        // =========================================================================================
        //on vérifie si la pièce est diponible

        public static bool VerifierpieceDisponible(int Piece, int[] TableauPieceDisponible)
        {
            if (TableauPieceDisponible[Piece] == 0)
                return (false);
            else
                return (true);
        }




        // =========================================================================================
        // On cherche à verifier si 4 pièces sont alignées

        // Commençons par les colonnes
        public static bool VerifierColonneVide(int Colonne, int[][] TableauPlateauCaracteristique) //on parcours la colonne en comptant le nombre de pièce, si il vaut 4, alors la colonne est pleine
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

        //Nous faisons de même pour les lignes
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


        //pour les diagonales (on rentrera celle que l'on veut (1 ou 2))
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


        // =========================================================================================
        //on teste si 4 pièces (représentées pas des entiers distincts compris entre 1 et 16) contiennent 1 caractère commun

        public static bool Tester4Pieces(int Piece1, int Piece2, int Piece3, int Piece4, string[] TableauPieceCaracteristique)
        {
            bool sortie = false;
            int k = 0;

            //les caractères sont représentés par une chaine de 4 caractères. Si les 4 pièces ont un des caractères commun (au même emplacement) on renvoie true
            if (Piece1!=0 && Piece2!=0 && Piece3!=0 && Piece4!=0)
                while ((!sortie) && (k < 4))
                   if ((TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece2 - 1][k]) && (TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece3 - 1][k]) && (TableauPieceCaracteristique[Piece1 - 1][k] == TableauPieceCaracteristique[Piece4 - 1][k]))
                       sortie = true;
                   else
                      k++;

            return (sortie);
        }


        // =========================================================================================
        //On choisit aléatoirement une pièce et on met à jour notre tableau PiecDispo

        public static int ChoisirPieceAleatoire(int[] TableauPieceDispo)
        {
            Random rand = new Random();
            int Sortie = rand.Next(1,17);

            while (TableauPieceDispo[Sortie-1] == 0)
                Sortie = rand.Next(1,17);
            TableauPieceDispo[Sortie - 1] = 0;
            return (Sortie);
        }


        // =========================================================================================
        // Fonction appelee lorsque l'ordinateur veut placer une piece
        
        public static void JouerPieceAleatoire (int Piece, out int Ligne, out int Colonne, int[][] TableauPlateauCaracteristique, string [][][] TableauPlateauGraphique, string [][] TableauPieceGraphique, string[] tableauPieceCaracteristique, int[]tableauPiecesDisponible)
        {
            // on compte le nombre de cases vides
            int NbCasesVides = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
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
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
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



        // =========================================================================================
        //On met à jour le tableau contenant les quartos possibles du tour en partant du principe qu'en posant une nouvelle pièce il ne peut y avoir qu'au maximum 3 quarto, sur la ligne, sur la colonne ou sur la diagonale.

        public static void Scanner(int Ligne, int Colonne, string[] QuartoPossible, int[][] TableauPlateauCaracteristique, string[] TableauPieceCaracteristique)
        {


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



        //=========================================================================================
        //On vérifie si le quarto annoncé par le joueur est possible

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
