using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class intelligent
    {
        // L'ordi repère les quartos qu'il pourrait faire avec la pièce qu'on lui a donné à jouer
 
        /// <summary>
        /// Cherche les lignes/colonnes/diagonales où il ne reste qu'une place
        /// </summary>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <returns></returns>
        public static int[][] VerifierUnePlace( int[][] TableauPlateauCaracteristique)
        {
            int[][] Retour = new int[3][];
            int Compteur;
            int Donnee;
            //on commence par regarder les lignes du tableau
            Retour[0] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Donnee = 0;
                Compteur = 0;
                for (int j = 0; j < 4; j++)
                    if (TableauPlateauCaracteristique[i][j] != 0)
                        Compteur++;
                    else
                        Donnee = j;

                if (Compteur == 3)
                    Retour[0][i] = Donnee;
                else
                    Retour[0][i] = -1;
            }

            //les colonnes maintenant
            Retour[1] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Donnee = 0;
                Compteur = 0;
                for (int j = 0; j < 4; j++)
                    if (TableauPlateauCaracteristique[j][i] != 0)
                        Compteur++;
                    else
                        Donnee = j;

                if (Compteur == 3)
                    Retour[1][i] = Donnee;
                else
                    Retour[1][i] = -1;
            }

            //au tour des diagonales
            Retour[2] = new int[2]; // il n'existe que deux diagonales.

            //penchons nous sur la diagonale 1
            Donnee = 0;
            Compteur = 0;
            for (int i=0; i<4; i++)
            {
                if (TableauPlateauCaracteristique[i][i] != 0)
                    Compteur++;
                else
                    Donnee = i;
            }
            if (Compteur == 3)
                Retour[2][0] = Donnee;
            else
                Retour[2][0] = -1;

            //la diagonale 2 maintenant
            Donnee = 0;
            Compteur = 0;
            for (int i = 0; i < 4; i++)
            {
                if (TableauPlateauCaracteristique[i][3-i] != 0)
                    Compteur++;
                else
                    Donnee = i;
            }
            if (Compteur == 3)
                Retour[2][1] = Donnee;
            else
                Retour[2][0] = -1;

            return (Retour);
        }
        

        /// <summary>
        /// Place un quarto, si possible, sinon place la pièce aléatoirement. Ensuite affiche le plateau
        /// </summary>
        /// <param name="Piece"></param>
        /// <param name="PlaceVide"></param>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <param name="TableauPieceCaracteristique"></param>
        /// <param name="Ligne"></param>
        /// <param name="Colonne"></param>
        /// <param name="TableauPlateauGraphique"></param>
        /// <param name="TableauPieceGraphique"></param>
        /// <param name="TableauPieceDisponible"></param>
        /// <param name="Quarto"></param>
        public static void PlacerQuarto(int Piece, int[][] PlaceVide, int[][] TableauPlateauCaracteristique, string[] TableauPieceCaracteristique, out int Ligne, out int Colonne, string[][][] TableauPlateauGraphique, string[][] TableauPieceGraphique, int[] TableauPieceDisponible, out bool Quarto)
        {
            Quarto = false;
            Ligne = 1;
            Colonne = 1;
            int i = 0;
            bool Sortie = false; //nous permettra de sortir de la boucle while si on a un Quarto
            int[] PieceATester = new int[3]; // contiendra les 3 pièces à tester en plus de la Piece donnée par le joueur qui est argument de la fonction

            //On commence par les lignes
            while ((i < 4) && (!Sortie))
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
                        if ((TableauPlateauCaracteristique[i][j] != 0) && (k < 3))
                        {
                            PieceATester[k] = TableauPlateauCaracteristique[i][j];
                            k++;
                        }
                    if (Test.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, TableauPieceCaracteristique))
                    {
                        Ligne = i+1;
                        Colonne = PlaceVide[0][i]+1;
                        General.PlacerPiece(Piece, Ligne-1, Colonne-1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, TableauPieceDisponible);
                        Sortie = true;
                        Quarto = true;
                        Affiche.AfficherPlateau(TableauPlateauGraphique);
                        Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la ligne {0}", i + 1);
                    }
                    i++;
                }
            }

            //On enchaîne sur les colonnes
            i = 0;
            while ((i < 4) && (!Sortie))
            {
                if (PlaceVide[1][i] == -1)
                    i++;
                else
                {
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if ((TableauPlateauCaracteristique[j][i] != 0) && (k < 3))
                        {
                            PieceATester[k] = TableauPlateauCaracteristique[j][i];
                            k++;
                        }
                    if (Test.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, TableauPieceCaracteristique))
                    {
                        Ligne = PlaceVide[1][i]+1;
                        Colonne = i+1;
                        General.PlacerPiece(Piece, Ligne-1, Colonne-1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, TableauPieceDisponible);
                        Sortie = true;
                        Quarto = true;
                        Affiche.AfficherPlateau(TableauPlateauGraphique);
                        Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la colonne {0}", i + 1);
                    }
                    i++;
                }
            }

            //Au tour des diagonales
            //diagonale 1
            if ((PlaceVide[2][0] != -1) && (!Sortie))
            {
                int k = 0;
                for (int j = 0; j < 4; j++)
                    if ((TableauPlateauCaracteristique[j][j] != 0) && (k < 3))
                    {
                        PieceATester[k] = TableauPlateauCaracteristique[j][j];
                        k++;
                    }
                if (Test.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, TableauPieceCaracteristique))
                {
                    Ligne = PlaceVide[2][0]+1;
                    Colonne = Ligne;
                    General.PlacerPiece(Piece, Ligne-1, Ligne-1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, TableauPieceDisponible);
                    Sortie = true;
                    Quarto = true;
                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                    Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la diagonale 1");
                }
            }

            //diagonale 2
            if ((PlaceVide[2][1] != -1) && (!Sortie))
            {
                int k = 0;
                for (int j = 0; j < 4; j++)
                    if ((TableauPlateauCaracteristique[j][3 - j] != 0) && (k < 3))
                    {
                        PieceATester[k] = TableauPlateauCaracteristique[j][3 - j];
                        k++;
                    }
                if (Test.Tester4Pieces(PieceATester[0], PieceATester[1], PieceATester[2], Piece, TableauPieceCaracteristique))
                {
                    Ligne = PlaceVide[2][1]+1;
                    Colonne = 3 - Ligne;
                    General.PlacerPiece(Piece, Ligne-1, Colonne-1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, TableauPieceDisponible);
                    Sortie = true;
                    Quarto = true;
                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                    Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la diagonale 2");
                }
            }

            //on conclue en cas d'absence de quarto
            if (!Sortie)
            {
                General.JouerPieceAleatoire(Piece, out Ligne, out Colonne, TableauPlateauCaracteristique, TableauPlateauGraphique, TableauPieceGraphique, TableauPieceCaracteristique, TableauPieceDisponible);
                Quarto = false;
                Affiche.AfficherPlateau(TableauPlateauGraphique);
            }
        }


        /// <summary>
        ///  renvoie true si le caractere Car est dans la chaine de caractere Str
        /// </summary>
        /// <param name="car"> un caractere</param>
        /// <param name="str">une chaine de caractere</param>
        /// <returns></returns>
        public static bool CaractereDansChaine(char Car, string Str)
        {
            bool Present = false;
            int Index = 0;
            while (Index < Str.Length && Present == false)
            {
                if (Car == Str[Index])
                    Present = true;
                Index++;
            }
            return Present;
        }


        /// <summary>
        ///  Renvoie, si possible, le numero d'une piece empechant le joueur de gagner au tour suivant
        /// </summary> 

        public static int ChoisirQuarto( int[][] TableauPlateauCaracteristique, string[] TableauPieceCaracteristique, int[] PieceDispo)
        {
            // on parcourt la liste des pièces disponibles, on vérifie si chacune de ces pièces pourraient faire un quarto en parcourant toutes les places disponibles
            
            int[][] QuartoPossible = VerifierUnePlace(TableauPlateauCaracteristique);
            int Somme = 0;
            for (int i = 0;i<3;i++)
            {
                foreach (int e in QuartoPossible[i])
                    Somme += e;
            }
            if (Somme == -10) // chaque colonne/ligne/diagonale possède strictement moins de 3 éléments et donc que peu importe la pièce choisie impossible qu'il y ait quarto au tour du joueur
                return General.ChoisirPieceAleatoire(PieceDispo);
            else
            {
                int NumPiece = -1;
                bool Gagne = true;
                int Index = 0;
                string Element = ElementCommun(TableauPlateauCaracteristique, TableauPieceCaracteristique);
                
                while (Gagne == true && Index < 16)
                {
                    NumPiece = PieceDispo[Index];
                    if (NumPiece != 0) // Si la piece est disponible
                    {
                        int i = 0;
                        Gagne = false;
                        while (i < 4 && Gagne == false)
                        {
                            if (CaractereDansChaine(TableauPieceCaracteristique[NumPiece-1][i], Element))
                                Gagne = true;
                            i++;
                        }
                    }
                    Index++;
                }
                if (Gagne == true)
                    return General.ChoisirPieceAleatoire(PieceDispo);
                else
                {
                    PieceDispo[NumPiece-1] = 0;
                    return NumPiece;
                }
            }     
        }


        /// <summary>
        /// Renvoie les caractèristiques communes des différents quartos possibles
        /// </summary>
        /// <param name="TableauPlateauCaracteristique"></param>
        /// <param name="TableauPieceCaracteristique"></param>
        /// <param name="QuartoPossible"></param>
        /// <returns></returns>
        public static string ElementCommun (int[][] TableauPlateauCaracteristique, string[] TableauPieceCaracteristique)
        {
            string Element = "";
            int[] Combin = new int[40];

            // On met toutes les combinaisons du plateau susceptibles de faire des quarto dans une liste
            for (int Ligne = 0; Ligne < 4; Ligne++) // On remplit combin avec les pieces de chaque ligne 
            {
                for(int Colonne = 0;Colonne<4;Colonne++)
                {
                    Combin[4 * Ligne + Colonne] = TableauPlateauCaracteristique[Ligne][Colonne];
                    Combin[16 + 4 * Ligne + Colonne] = TableauPlateauCaracteristique[Colonne][Ligne]; // On ajoute a Combin les pieces de chaque colonne (on se moque des redondances du plateau)
                }               
            }
            
            // On ajoute a Combin les pieces de chaque diagonale
            // diagonale 1
            Combin[32] = TableauPlateauCaracteristique[0][0];
            Combin[33] = TableauPlateauCaracteristique[1][1];
            Combin[34] = TableauPlateauCaracteristique[2][2];
            Combin[35] = TableauPlateauCaracteristique[3][3];
            // diagonale 2
            Combin[36] = TableauPlateauCaracteristique[3][0];
            Combin[37] = TableauPlateauCaracteristique[2][1];
            Combin[38] = TableauPlateauCaracteristique[1][2];
            Combin[39] = TableauPlateauCaracteristique[0][3];

            for (int i = 0; i < 10; i++) // On parcourt un a un chaque alignement où il pourrait y avoir quarto dans le plateau
            {
                int NbVide = 0;
                int NumVide = 0;
                for (int j = 0; j < 4; j++) // On verifie qu'il n'y a que 3 pieces placées dans l'alignement et on note l'emplacement de la pièce vide (numvide)
                {
                    if (Combin[i * 4 + j] == 0)
                    {
                        NbVide++;
                        NumVide = j;
                    }    
                }
                if (NbVide == 1) // Il y a exactement une pièce vide dans cet alignement
                {
                    int Index = 0;
                    int[] Tab = new int[3];
                    for (int j = 0; j < 4; j++) // On stocke les indices des pieces dans le tableau tab pour effectuer le test qui suit
                    {
                        if (j != NumVide)
                        {
                            Tab[Index] = j;
                            Index++;
                        }
                    }
                    for (int j = 0; j < 4; j++) // On verifie si les pieces de l'alignement possedent des caracteristiques en commun, on stocke alors ces caracteristiques dans Element en evitant les redondances
                    {
                        if (TableauPieceCaracteristique[Combin[i * 4 + Tab[0]]-1][j] == TableauPieceCaracteristique[Combin[i * 4 + Tab[1]]-1][j] && TableauPieceCaracteristique[Combin[i * 4 + Tab[1]]-1][j] == TableauPieceCaracteristique[Combin[i * 4 + Tab[2]]-1][j])
                        {
                            bool Present = false;
                            foreach (char e in Element) // On verifie que la caracteristique n'etait pas deja dans Element pour eviter les redondances
                                if (e == TableauPieceCaracteristique[Combin[i * 4 + Tab[0]]-1][j])
                                    Present = true;
                            if (Present == false)
                                Element = Element + TableauPieceCaracteristique[Combin[i * 4 + Tab[0]]-1][j];                                
                        }
                    }
                }
            }
            return Element;
        }
    }
}
