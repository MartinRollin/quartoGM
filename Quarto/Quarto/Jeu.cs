using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Jeu
    {
        static void Main (string [] args)
        {
            // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (c)reu/(p)lein "
            string[] tableauPieceCaracteristique = { "pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp" };


            //test de PlacerPiece
            string[][] tableauPieceGraphique = CreerTableaux.CreerTableauPieceGraphique();
            string[][][] tableauPlateauGraphique = CreerTableaux.InitialiserTableauPlateauGraphique();
            int[] tableauPieceDisponible = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[][] tableauPlateauCaracteristique = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                tableauPlateauCaracteristique[i] = new int[4];
                for (int j = 0; j < 4; j++)
                    tableauPlateauCaracteristique[i][j] = 0;
            }

            Affiche.AfficherRegles();
            Console.Write("Voulez vous commencer une partie? (O/N) : ");
            Console.ReadLine();

            Affiche.AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            Affiche.AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDisponible);
            Console.ReadLine();
            General.PlacerPiece(2, 1, 1, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, tableauPieceDisponible);
            Affiche.AfficherPlateau(tableauPlateauGraphique);
            Console.ReadLine();
            Affiche.AfficherPieceDisponible(tableauPieceGraphique, tableauPieceDisponible);
            Console.ReadLine();
        }
    }
}
