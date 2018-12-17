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
            tableauPiecesDisponible[numeroPiece] = 0;
        }

        // =========================================================================================

        
        /*
        static void Main(string[] args)
        {

            
            // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (c)reu/(p)lein "
            string [] tableauPieceCaracteristique = { "pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp" };


            //test de PlacerPiece
            string [][] tableauPieceGraphique = CreerTableauPieceGraphique();
            string [][][] tableauPlateauGraphique = InitialiserTableauPlateauGraphique();
            int [] tableauPieceDisponible = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[][] tableauPlateauCaracteristique = new int[4][];
            for (int i = 0; i<4;i++)
            {
                tableauPlateauCaracteristique[i] = new int[4];
                for (int j = 0; j < 4; j++)
                    tableauPlateauCaracteristique[i][j] = 0;
            }
            AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDisponible);
            Console.ReadLine();
            PlacerPiece(2, 1, 1, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, tableauPieceDisponible);
            AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDisponible);
            Console.ReadLine();
            

        }
    */
    }
}
