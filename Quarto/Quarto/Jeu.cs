using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Jeu
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 84);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t\t ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄                 ");
            Console.WriteLine("\t\t█                                                                █                ");
            Console.WriteLine("\t\t█               ▄▄▄  ▄   ▄  ▄▄▄  ▄▄▄▄  ▄▄▄▄▄  ▄▄▄                █                ");
            Console.WriteLine("\t\t█              █   █ █   █ █   █ █   █   █   █   █               █                ");
            Console.WriteLine("\t\t█              █ ▀▄█ █   █ █▀▀▀█ █▀▀▀▄   █   █   █               █                ");
            Console.WriteLine("\t\t█               ▀▀ ▀▄ ▀▀▀  ▀   ▀ ▀   ▀   ▀    ▀▀▀                █                ");
            Console.WriteLine("\t\t█                                                                █                ");
            Console.WriteLine("\t\t ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀                 \n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
            string jouer;
            do
            {
                Console.Write(" Voulez vous un rappel des regles du jeu? (O/N) : ");
                string regles = Console.ReadLine();
                if (regles == "O")
                    Affiche.AfficherRegles();
                Console.Write(" Voulez vous commencer une partie? (O/N) : ");
                jouer = Console.ReadLine();
                if (jouer == "N")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t\t      Merci d'avoir participé !       \t\t");
                    Console.ReadLine();
                }
                else
                {
                    // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (C)reu/(P)lein "
                    string[] tableauPieceCaracteristique = { "pbrC", "gbrC", "pbrP", "gbrP", "pbcC", "gbcC", "pbcP", "gbcP", "pvrC", "gvrC", "pvrP", "gvrP", "pvcC", "gvcC", "pvcP", "gvcP" };

                    // initialisation tableau qui contiendra les quarto pouvant être énoncés
                    string[] QuartoPossible = { "vide", "vide", "vide" };


                    // initialisation des plateaux et des tableaux stockant les pièces disponibles
                    string[][] tableauPieceGraphique = CreerTableaux.CreerTableauPieceGraphique();
                    string[][][] tableauPlateauGraphique = CreerTableaux.InitialiserTableauPlateauGraphique();
                    int[] PieceDispo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                    int[][] tableauPlateauCaracteristique = new int[4][];
                    for (int i = 0; i < 4; i++)
                    {
                        tableauPlateauCaracteristique[i] = new int[] { 0, 0, 0, 0 };
                    }

                    int Colonne = 0;
                    int Ligne = 0;
                    string reponse = "O";
                    int tour = 1;
                    bool quarto = false;
                    int NumeroPiece;
                    int verifal;
                    int seuil; // variable qui définit si l'ordinateur détecte le quarto à tous les coups (seuil = 0) ou avec 3 chances sur 5 (seuil = 2)


                    Console.Write(" Choisissez le niveau de difficulté (facile/difficile) : ");
                    string niveau = Console.ReadLine();
                    if (niveau == "difficile")
                        seuil = 0;
                    else
                        seuil = 2;

                    Random rand = new Random();
                    int joueur = rand.Next(2);            // On determine quel joueur va commencer, 0 -> l'ordi est en train de jouer, 1 -> le joueur est en train de jouer


                    if (joueur == 0)  // L'ordinateur commence a jouer
                    {
                        Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                        Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                        Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                        Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                        Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.ReadLine();
                        Console.WriteLine("\n Voici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                        Console.ReadLine();
                        NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                        joueur = 1;  // le prochain à jouer sera le joueur
                    }

                    else  // le joueur commence à jouer
                    {
                        Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("\t\t                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                        Console.WriteLine("\t\t                █   █     █   █   █   █ ");
                        Console.WriteLine("\t\t                █▀▀▀█     █   █   █   █ ");
                        Console.WriteLine("\t\t                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                        Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.WriteLine();
                        Console.ReadLine();

                        Console.WriteLine("\n Voici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                        Console.Write(" Quelle piece veux tu donner à l'ordinateur? : ");
                        NumeroPiece = int.Parse(Console.ReadLine());
                        joueur = 0;  // le prochain à jouer sera l'ordinateur
                    }

                    while (tour < 16 && !quarto)        // On effectue tous les tours sauf le dernier (comme le dernier joueur ne peut pas donner de piece a l'autre)
                    {

                        // Deroulement du tour du joueur humain
                        if (joueur == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                            Console.WriteLine("\t\t                █   █     █   █   █   █ ");
                            Console.WriteLine("\t\t                █▀▀▀█     █   █   █   █ ");
                            Console.WriteLine("\t\t                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.WriteLine(" L'ordinateur a choisi cette pièce :");
                            Affiche.AfficherPiece(NumeroPiece, tableauPieceGraphique);

                            // c'est à ce moment la qu'on peut dire Quarto 
                            reponse = Console.ReadLine();
                            reponse = reponse.ToLower();
                            if (reponse == "quarto")
                            {
                                do                              // on laisse la possibilité au joueur de donner plusieurs endroits ou il pense qu'il y a quarto
                                {
                                    Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ?\n < ecrire par exemple : ligne 2, colonne 3, diagonale 1 > : ");
                                    string endroit = Console.ReadLine();
                                    quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                    if (quarto == true)
                                    {
                                        Console.WriteLine("\n Bravo vous avez gagné !");
                                    }
                                    else
                                    {
                                        Console.Write(" Il n'y a pas de quarto sur la {0}\n (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                        reponse = Console.ReadLine();

                                    }
                                }
                                while (quarto == false && reponse == "O");

                            }

                            if (quarto == false)
                            {

                                // On demande au joueur de placer dans le plateau la piece chosie par l'ordi
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(" A quelle ligne veux tu placer la piece? : ");
                                Ligne = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.Write(" A quelle Colonne veux tu placer la piece? : ");
                                Colonne = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                General.PlacerPiece(NumeroPiece, Ligne - 1, Colonne - 1, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, PieceDispo);
                                General.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, tableauPlateauCaracteristique, tableauPieceCaracteristique);
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Gray;

                                // c'est à ce moment la qu'on peut dire Quarto 
                                reponse = Console.ReadLine();
                                reponse = reponse.ToLower();
                                if (reponse == "quarto")
                                {
                                    do                              // on laisse la possibilité au joueur de donner plusieurs endroits ou il pense qu'il y a quarto
                                    {
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                        if (quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                            reponse = Console.ReadLine();

                                        }
                                    }
                                    while (quarto == false && reponse == "O");

                                }
                                if (quarto == false)
                                {
                                    bool disponible = false;
                                    do                         // On fait en sorte que le joueur choisisse une pièce qui soit disponible
                                    {

                                        Console.WriteLine(" Voici les pièces disponibles :\n");
                                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("\n Quelle piece donner à l'ordinateur ? :");
                                        NumeroPiece = int.Parse(Console.ReadLine());                            // faiblesse du code si on ne rentre pas un chiffre
                                        int verifdispo = 0;
                                        while (verifdispo < PieceDispo.Length && disponible == false)
                                        {
                                            if (PieceDispo[verifdispo] == NumeroPiece)
                                                disponible = true;
                                            verifdispo++;
                                        }

                                        if (disponible == false)
                                        {
                                            Console.WriteLine(" Cette pièce n'est pas disponible.\n");
                                            Console.ReadLine();
                                        }
                                    }
                                    while (disponible == false);
                                    joueur = 0;

                                }

                            }
                            tour++;
                        }

                        else if (joueur == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                            Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                            Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                            Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.ReadLine();

                            // On verifie le quarto de l'ordinateur
                            verifal = rand.Next(1, 6);
                            // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                            if (verifal > seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                            {
                                quarto = true;
                                if (QuartoPossible[0] != "vide")
                                    Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                else
                                {
                                    if (QuartoPossible[1] != "vide")
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                    else
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                }
                            }

                            else
                            {
                                /*
                                if (niveau == "difficile")
                                {
                                    intelligent.PlacerQuarto(NumeroPiece, intelligent.VerifierUnePlace(tableauPlateauCaracteristique), tableauPlateauCaracteristique, tableauPieceCaracteristique, out Ligne, out Colonne, tableauPlateauGraphique, tableauPieceGraphique, PieceDispo,out quarto);
                                }*/
                                General.JouerPieceAleatoire(NumeroPiece, out Ligne, out Colonne, tableauPlateauCaracteristique, tableauPlateauGraphique, tableauPieceGraphique, tableauPieceCaracteristique, PieceDispo);
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                General.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, tableauPlateauCaracteristique, tableauPieceCaracteristique);
                                Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Gray;

                                // On verifie une deuxieme fois s'il y a quarto
                                verifal = rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                                if (verifal > seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                {
                                    quarto = true;
                                    if (QuartoPossible[0] != "vide")
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                    else
                                    {
                                        if (QuartoPossible[1] != "vide")
                                            Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                        else
                                            Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                    }
                                }
                                if (quarto == false)
                                {
                                    Console.WriteLine("\n Voici les pièces disponibles :\n");
                                    Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                    Console.ReadLine();
                                    NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                                }

                                joueur = 1;
                            }
                            tour++;
                        }
                    }


                    if (tour == 16)        // On traite le cas du dernier tour
                    {
                        if (joueur == 0)   // Si l'ordinateur est le dernier à jouer
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                            Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                            Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                            Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.ReadLine();

                            // On verifie le quarto de l'ordinateur
                            verifal = rand.Next(1, 6);
                            // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                            if (verifal > seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                            {
                                quarto = true;
                                if (QuartoPossible[0] != "vide")
                                    Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                else
                                {
                                    if (QuartoPossible[1] != "vide")
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                    else
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                }
                            }

                            else
                            {
                                General.JouerPieceAleatoire(NumeroPiece, out Ligne, out Colonne, tableauPlateauCaracteristique, tableauPlateauGraphique, tableauPieceGraphique, tableauPieceCaracteristique, PieceDispo);
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                General.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, tableauPlateauCaracteristique, tableauPieceCaracteristique);
                                Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Gray;

                                // On verifie une deuxieme fois s'il y a quarto
                                verifal = rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                                if (verifal > seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                {
                                    quarto = true;
                                    if (QuartoPossible[0] != "vide")
                                        Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                    else
                                    {
                                        if (QuartoPossible[1] != "vide")
                                            Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                        else
                                            Console.WriteLine(" L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                    }
                                }
                            }
                        }

                        else      // C'est au joueur de faire le dernier tour
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                            Console.WriteLine("\t\t                █   █     █   █   █   █ ");
                            Console.WriteLine("\t\t                █▀▀▀█     █   █   █   █ ");
                            Console.WriteLine("\t\t                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.WriteLine();

                            // c'est à ce moment là qu'on peut dire Quarto 
                            reponse = Console.ReadLine();
                            reponse = reponse.ToLower();
                            if (reponse == "quarto") // si le joueur pense qu'il y a quarto
                            {
                                do // on laisse la possibilité au joueur de donner plusieurs endroits où il pense qu'il y a quarto
                                {
                                    Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                    string endroit = Console.ReadLine();
                                    quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                    if (quarto == true)
                                    {
                                        Console.WriteLine("\n Bravo vous avez gagné !");
                                    }
                                    else
                                    {
                                        Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                        reponse = Console.ReadLine();

                                    }
                                }
                                while (quarto == false && reponse == "O");

                            }
                            
                            if (quarto == false) // Si le joueur n'a pas gagné
                            {
                                Console.WriteLine(" L'ordinateur a choisi cette pièce :");
                                Affiche.AfficherPiece(NumeroPiece, tableauPieceGraphique);

                                // On demande au joueur de placer dans le plateau la piece chosie par l'ordi
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(" A quelle ligne veux tu placer la piece? : ");
                                Ligne = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.Write(" A quelle Colonne veux tu placer la piece? : ");
                                Colonne = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                General.PlacerPiece(NumeroPiece, Ligne - 1, Colonne - 1, tableauPieceCaracteristique, tableauPieceGraphique, tableauPlateauGraphique, tableauPlateauCaracteristique, PieceDispo);
                                General.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, tableauPlateauCaracteristique, tableauPieceCaracteristique);
                                Affiche.AfficherPlateau(tableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Gray;

                                // c'est à ce moment la qu'on peut dire Quarto 
                                reponse = Console.ReadLine();
                                reponse = reponse.ToLower();
                                if (reponse == "quarto")
                                {
                                    do // on laisse la possibilité au joueur de donner plusieurs endroits ou il pense qu'il y a quarto
                                    {
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                        if (quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                            reponse = Console.ReadLine();

                                        }
                                    }
                                    while (quarto == false && reponse == "O");

                                }
                            }
                        }
                        if (quarto == false)
                        {
                            Console.WriteLine("\n    Egalité !   ");
                        }
                    }
                    Console.WriteLine("\n█████████████████████████████████████████████████████████████████████████████████████████████████████\n");
                    

                    Console.ReadLine();
                }
            }
            while (jouer == "O");

        }
    }
}
