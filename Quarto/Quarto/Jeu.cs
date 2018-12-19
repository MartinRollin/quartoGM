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
            char jouer = char.Parse(Console.ReadLine());
            if (jouer == 'N')
            {
                Console.WriteLine("merci d'avoir participé ! ");
                Console.ReadLine();
            }
            else
            {
                Random rand = new Random();
                int joueur = rand.Next(2);
                if (joueur==0)
                {
                    Console.WriteLine("               L'ordinateur commence !");
                    int NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                    joueur = 1;
                    for (int tour = 2;tour<16;tour++)
                    {
                        if (joueur == 1)
                        {
                            Console.WriteLine("\n              ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                            Console.WriteLine("             █   █     █   █   █   █ ");
                            Console.WriteLine("             █▀▀▀█     █   █   █   █ ");
                            Console.WriteLine("             ▀   ▀     ▀    ▀▀▀    ▀\n             Appuies sur entrée pour commencer.\n");
                            Console.ReadLine();
                            Console.WriteLine("L'ordinateur a choisit cette piece :");
                            Affiche.AfficherPiece(NumeroPiece, tableauPieceGraphique);
                            Console.ReadLine();
                            Affiche.AfficherPlateau(tableauPlateauGraphique);
                            Console.Write("A quelle ligne veux tu placer la piece? : ");
                            Ligne = int.Parse(Console.ReadLine());
                            Console.Write("A quelle Colonne veux tu placer la piece? : ");
                            Colonne = int.Parse(Console.ReadLine());
                            General.PlacerPiece(NumeroPiece, Ligne, Colonne, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, PieceDispo);
                            Affiche.AfficherPlateau(tableauPlateauGraphique);
                            Affiche.AfficherPieceDisponible( tableauPieceGraphique, PieceDispo);
                            Console.WriteLine("\n   Quelle piece donner à l'ordinateur ? :");
                            NumeroPiece = int.Parse(Console.ReadLine());
                        }
                    }
                }

            }
                

            /*
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
            */
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
