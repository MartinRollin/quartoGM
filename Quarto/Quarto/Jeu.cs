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
            int[] PieceDispo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[][] tableauPlateauCaracteristique = new int[4][];
            int Colonne = 0;
            int Ligne = 0;

            for (int i = 0; i < 4; i++)
            {
                tableauPlateauCaracteristique[i] = new int[] { 0, 0, 0, 0 };
            }

            Affiche.AfficherRegles();
            Console.Write("Voulez vous commencer une partie? (O/N) : ");
            Console.ReadLine();

           
            for (int i = 0;i<17;i++)
            {
                Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                Affiche.AfficherPlateau(tableauPlateauGraphique);
                Console.WriteLine("\n\n\n\n\n\n\n ▄▄▄▄▄  ▄▄▄  ▄   ▄ ▄▄▄▄     ▄▄▄  ▄▄▄▄  ▄▄▄▄   ▄▄▄  ");
                Console.WriteLine("   █   █   █ █   █ █   █   █   █ █   █ █   █   █   ");
                Console.WriteLine("   █   █   █ █   █ █▀▀▀▄   █   █ █▀▀▀▄ █   █   █   ");
                Console.WriteLine("   ▀    ▀▀▀   ▀▀▀  ▀   ▀    ▀▀▀  ▀   ▀ ▀▀▀▀   ▀▀▀        n°" + (i+1) + "\n\n");
                int NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                General.JouerPieceAleatoire(NumeroPiece, out Ligne, out Colonne, tableauPlateauCaracteristique, tableauPlateauGraphique, tableauPieceGraphique, tableauPieceCaracteristique, PieceDispo);
                Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                Affiche.AfficherPlateau(tableauPlateauGraphique);
                Console.ReadLine();
            }
            Console.ReadLine();

            Console.WriteLine("\n ▄▄▄▄▄  ▄▄▄  ▄   ▄ ▄▄▄▄     ▄▄▄  ▄▄▄▄  ▄▄▄▄   ▄▄▄  ");
            Console.WriteLine("   █   █   █ █   █ █   █   █   █ █   █ █   █   █   ");
            Console.WriteLine("   █   █   █ █   █ █▀▀▀▄   █   █ █▀▀▀▄ █   █   █   ");
            Console.WriteLine("   ▀    ▀▀▀   ▀▀▀  ▀   ▀    ▀▀▀  ▀   ▀ ▀▀▀▀   ▀▀▀\n\n");
            Affiche.AfficherPlateau(tableauPlateauGraphique);

            Console.WriteLine("\n              ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
            Console.WriteLine("             █   █     █   █   █   █ ");
            Console.WriteLine("             █▀▀▀█     █   █   █   █ ");
            Console.WriteLine("             ▀   ▀     ▀    ▀▀▀    ▀\n\n");
            Console.ReadLine();
        }
    }
}
