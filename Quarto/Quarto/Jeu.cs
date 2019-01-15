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
            
            // On redimensionne la fenêtre à une taille suffisante pour obtenir un bon affichage
            int MaxHauteur = Console.LargestWindowHeight;
            int MaxLargeur = Console.LargestWindowWidth;
            if (MaxLargeur > 110)
                MaxLargeur = 110;
            if (MaxHauteur > 84)
                MaxHauteur = 84;
            Console.SetWindowSize(MaxLargeur, MaxHauteur);
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            string Jouer;

            //On donne au joueur la possibilité de voir les règles au début
            do
            {
                Console.Write(" Voulez vous un rappel des regles du jeu? (O/N) : ");
                string Regles = Console.ReadLine();
                if (Regles == "O")
                    Affiche.AfficherRegles();
                Console.Write(" Voulez vous commencer une partie? (O/N) : ");
                Jouer = Console.ReadLine();
                if (Jouer == "N")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t\t      Merci d'être venu !       \t\t");
                    Console.ReadLine();
                }
                else
                {
                    
                    
                    // initialisation de TableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (C)reu/(P)lein "
                    string[] TableauPieceCaracteristique = { "pbrC", "gbrC", "pbrP", "gbrP", "pbcC", "gbcC", "pbcP", "gbcP", "pvrC", "gvrC", "pvrP", "gvrP", "pvcC", "gvcC", "pvcP", "gvcP" };

                    // initialisation tableau qui contiendra les quarto pouvant être énoncés
                    string[] QuartoPossible = { "vide", "vide", "vide" };

                    // initialisation des plateaux et des tableaux stockant les pièces disponibles
                    string[][] TableauPieceGraphique = CreerTableaux.CreerTableauPieceGraphique();
                    string[][][] TableauPlateauGraphique = CreerTableaux.InitialiserTableauPlateauGraphique(TableauPieceGraphique);
                    int[] PieceDispo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                    int[][] TableauPlateauCaracteristique = new int[4][];
                    for (int i = 0; i < 4; i++)
                    {
                        TableauPlateauCaracteristique[i] = new int[] { 0, 0, 0, 0 };
                    }
                    
                    int Colonne = 0;
                    int Ligne = 0;
                    string Reponse = "O";
                    int Tour = 1;
                    bool Quarto = false;
                    int NumeroPiece;
                    int Verifal;
                    int Seuil; // variable qui définit si l'ordinateur détecte le quarto à tous les coups (seuil = 0) ou avec 3 chances sur 5 (seuil = 2)

                    string Niveau;
                    do
                    {
                        Console.Write(" Choisissez le niveau de difficulté (facile/difficile) : ");
                        Niveau = Console.ReadLine();
                        if (Niveau != "facile" && Niveau != "difficile")
                            Console.WriteLine("     Erreur, commande inconnue.\n");
                    }
                    while (Niveau != "facile" && Niveau != "difficile");
                    
                    if (Niveau == "difficile")
                        Seuil = 0;
                    else
                        Seuil = 2;

                    Console.Clear();
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
                    Console.ForegroundColor = ConsoleColor.White;

                    Random Rand = new Random();
                    int Joueur = Rand.Next(2); // On determine quel joueur va commencer, 0 -> l'ordi est en train de jouer, 1 -> le joueur est en train de jouer


                    if (Joueur == 0)  // L'ordinateur commence a jouer
                    {
                        Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                        Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                        Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                        Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                        Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.ReadLine();
                        Console.WriteLine("\n Voici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(TableauPieceGraphique, PieceDispo);
                        Console.ReadLine();
                        NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                        Joueur = 1;  // le prochain à jouer sera le joueur
                    }

                    else  // le joueur commence à jouer
                    {
                        Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("\t\t              ▄▄▄     ▄   ▄  ▄▄▄  ▄   ▄  ▄▄▄");
                        Console.WriteLine("\t\t             █   █    █   █ █   █ █   █ ▀▄▄ ");
                        Console.WriteLine("\t\t             █▀▀▀█     █ █  █   █ █   █    █ ");
                        Console.WriteLine("\t\t             ▀   ▀      ▀    ▀▀▀   ▀▀▀  ▀▀▀");
                        Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.WriteLine();
                        Console.ReadLine();

                        Console.WriteLine("\n Voici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(TableauPieceGraphique, PieceDispo);
                        Console.Write(" Quelle piece voulez-vous donner à l'ordinateur? : ");
                        NumeroPiece = int.Parse(Console.ReadLine());
                        Joueur = 0;  // le prochain à jouer sera l'ordinateur
                    }

                    while (Tour < 16 && !Quarto)        // On effectue tous les tours sauf le dernier (comme le dernier joueur ne peut pas donner de piece a l'autre)
                    {

                        // Deroulement du tour du joueur humain
                        if (Joueur == 1)
                        {
                            Console.Clear();
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

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t              ▄▄▄     ▄   ▄  ▄▄▄  ▄   ▄  ▄▄▄");
                            Console.WriteLine("\t\t             █   █    █   █ █   █ █   █ ▀▄▄ ");
                            Console.WriteLine("\t\t             █▀▀▀█     █ █  █   █ █   █    █ ");
                            Console.WriteLine("\t\t             ▀   ▀      ▀    ▀▀▀   ▀▀▀  ▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.WriteLine(" L'ordinateur a choisi cette pièce :");
                            Affiche.AfficherPiece(NumeroPiece, TableauPieceGraphique);

                            // c'est à ce moment la qu'on peut dire Quarto
                            Console.ForegroundColor = ConsoleColor.White;
                            Reponse = Console.ReadLine();
                            Reponse = Reponse.ToLower();
                            if (Reponse == "quarto")
                            {
                                do                              // on laisse la possibilité au joueur de donner plusieurs endroits où il pense qu'il y a quarto
                                {
                                    Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ?\n < ecrire par exemple : ligne 2, colonne 3, diagonale 1 > : ");
                                    string Endroit = Console.ReadLine();
                                    Quarto = Test.VerifierQuarto(Endroit, QuartoPossible);
                                    if (Quarto == true)
                                    {
                                        Console.WriteLine("\n Bravo vous avez gagné !");
                                    }
                                    else
                                    {
                                        Console.Write(" Il n'y a pas de quarto sur la {0}\n (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", Endroit);
                                        Reponse = Console.ReadLine();

                                    }
                                }
                                while (Quarto == false && Reponse == "O");

                            }

                            if (Quarto == false)
                            {

                                // On demande au joueur de placer dans le plateau la piece chosie par l'ordi
                                bool PlaceVide;
                                do
                                {
                                    PlaceVide = false;
                                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.Write(" A quelle ligne voulez-vous placer la piece? <donnez le numéro de ligne> : ");
                                        Ligne = int.Parse(Console.ReadLine());
                                        if (Ligne > 4)
                                            Console.WriteLine(" Donnez un numéro compris entre 1 et 4");
                                        Console.WriteLine();
                                    }
                                    while (Ligne > 4);
                                    do
                                    {
                                        Console.Write(" A quelle colonne voulez-vous placer la piece? <donnez le numéro de colonne> : ");
                                        Colonne = int.Parse(Console.ReadLine());
                                        if (Colonne > 4)
                                            Console.WriteLine(" Donnez un numéro compris entre 1 et 4");
                                    }
                                    while (Colonne > 4);
                                    PlaceVide = Test.VerifierPlaceVide(Ligne - 1, Colonne - 1, TableauPlateauCaracteristique);
                                    if (!PlaceVide)
                                        Console.WriteLine("\n La place n'est pas disponible.\n");
                                }
                                while (!PlaceVide);
                                
                                
                                Console.Clear();
                                General.PlacerPiece(NumeroPiece, Ligne - 1, Colonne - 1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, PieceDispo);
                                Test.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, TableauPlateauCaracteristique, TableauPieceCaracteristique);
                                Affiche.AfficherPlateau(TableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                // c'est à ce moment la qu'on peut dire quarto
                                Reponse = Console.ReadLine();
                                Reponse = Reponse.ToLower();
                                if (Reponse == "quarto")
                                {
                                    do                              // on laisse la possibilité au joueur de donner plusieurs endroits ou il pense qu'il y a quarto
                                    {
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        Quarto = Test.VerifierQuarto(endroit, QuartoPossible);
                                        if (Quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                            Reponse = Console.ReadLine();

                                        }
                                    }
                                    while (Quarto == false && Reponse == "O");

                                }
                                if (Quarto == false)
                                {
                                    bool Disponible = false;
                                    do                         // On fait en sorte que le joueur choisisse une pièce qui soit disponible
                                    {

                                        Console.WriteLine(" Voici les pièces disponibles :\n");
                                        Affiche.AfficherPieceDisponible(TableauPieceGraphique, PieceDispo);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("\n Quelle pièce donner à l'ordinateur ? :");
                                        NumeroPiece = int.Parse(Console.ReadLine());
                                        int VerifDispo = 0;
                                        while (VerifDispo < PieceDispo.Length && Disponible == false)
                                        {
                                            if (PieceDispo[VerifDispo] == NumeroPiece)
                                                Disponible = true;
                                            VerifDispo++;
                                        }

                                        if (Disponible == false)
                                        {
                                            Console.WriteLine(" Cette pièce n'est pas disponible.\n");
                                            Console.ReadLine();
                                        }
                                    }
                                    while (Disponible == false);
                                    Joueur = 0;

                                }

                            }
                            Tour++;
                        }

                        else if (Joueur == 0)
                        {
                            Console.Clear();
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
                            Console.ForegroundColor = ConsoleColor.White;
                            
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                            Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                            Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                            Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.ReadLine();

                            // On verifie le quarto de l'ordinateur
                            Verifal = Rand.Next(1, 6);
                            // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                            if (Verifal > Seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                            {
                                Quarto = true;
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
                                
                                if (Niveau == "difficile")
                                {
                                    intelligent.PlacerQuarto(NumeroPiece, intelligent.VerifierUnePlace(TableauPlateauCaracteristique), TableauPlateauCaracteristique, TableauPieceCaracteristique, out Ligne, out Colonne, TableauPlateauGraphique, TableauPieceGraphique, PieceDispo,out Quarto);
                                }
                                else
                                {
                                    General.JouerPieceAleatoire(NumeroPiece, out Ligne, out Colonne, TableauPlateauCaracteristique, TableauPlateauGraphique, TableauPieceGraphique, TableauPieceCaracteristique, PieceDispo);
                                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                                }
                               
                                Test.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, TableauPlateauCaracteristique, TableauPieceCaracteristique);
                                Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                // On verifie une deuxieme fois s'il y a quarto
                                Verifal = Rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                                if (Verifal > Seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide") && !Quarto /*on ne vérifie donc pas le quarto ici si il a été fait dans une partie "difficile"*/ )  // ici on ne sait pas où est le quarto
                                {
                                    Quarto = true;
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
                                if (Quarto == false)
                                {
                                    Console.WriteLine("\n Voici les pièces disponibles :\n");
                                    Affiche.AfficherPieceDisponible(TableauPieceGraphique, PieceDispo);
                                    Console.ReadLine();
                                    if (Niveau == "difficile")
                                    {
                                        NumeroPiece = intelligent.ChoisirQuarto( TableauPlateauCaracteristique, TableauPieceCaracteristique, PieceDispo);
                                    }
                                    else
                                        NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);                                   
                                }

                                Joueur = 1;
                            }
                            Tour++;
                        }
                    }


                    if (Tour == 16)        // On traite le cas du dernier tour
                    {
                        if (Joueur == 0)   // Si l'ordinateur est le dernier à jouer
                        {
                            Console.Clear();
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
                            
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                            Console.WriteLine("\t\t   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                            Console.WriteLine("\t\t   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                            Console.WriteLine("\t\t   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.ReadLine();

                            // On verifie le quarto de l'ordinateur
                            Verifal = Rand.Next(1, 6);
                            // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                            if (Verifal > Seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                            {
                                Quarto = true;
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
                                if (Niveau == "difficile")
                                {
                                    intelligent.PlacerQuarto(NumeroPiece, intelligent.VerifierUnePlace(TableauPlateauCaracteristique), TableauPlateauCaracteristique, TableauPieceCaracteristique, out Ligne, out Colonne, TableauPlateauGraphique, TableauPieceGraphique, PieceDispo, out Quarto);
                                }
                                else
                                {
                                    General.JouerPieceAleatoire(NumeroPiece, out Ligne, out Colonne, TableauPlateauCaracteristique, TableauPlateauGraphique, TableauPieceGraphique, TableauPieceCaracteristique, PieceDispo);
                                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                                }

                                Test.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, TableauPlateauCaracteristique, TableauPieceCaracteristique);
                                Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                // On verifie une deuxieme fois s'il y a quarto
                                Verifal = Rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici (si niveau difficile, seuil = 0 si niveau facile seuil = 2)

                                if (Verifal > Seuil && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide") && !Quarto)  // ici on ne sait pas où est le quarto
                                {
                                    Quarto = true;
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
                            Console.Clear();
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
                            
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\t\t▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                            Console.WriteLine("\t\t              ▄▄▄     ▄   ▄  ▄▄▄  ▄   ▄  ▄▄▄");
                            Console.WriteLine("\t\t             █   █    █   █ █   █ █   █ ▀▄▄ ");
                            Console.WriteLine("\t\t             █▀▀▀█     █ █  █   █ █   █    █ ");
                            Console.WriteLine("\t\t             ▀   ▀      ▀    ▀▀▀   ▀▀▀  ▀▀▀");
                            Console.WriteLine("\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                            Console.WriteLine();

                            // c'est à ce moment là qu'on peut dire Quarto
                            Reponse = Console.ReadLine();
                            Reponse = Reponse.ToLower();
                            if (Reponse == "quarto") // si le joueur pense qu'il y a quarto
                            {
                                do // on laisse la possibilité au joueur de donner plusieurs endroits où il pense qu'il y a quarto
                                {
                                    Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                    string endroit = Console.ReadLine();
                                    Quarto = Test.VerifierQuarto(endroit, QuartoPossible);
                                    if (Quarto == true)
                                    {
                                        Console.WriteLine("\n Bravo vous avez gagné !");
                                    }
                                    else
                                    {
                                        Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                        Reponse = Console.ReadLine();

                                    }
                                }
                                while (Quarto == false && Reponse == "O");

                            }
                            
                            if (Quarto == false) // Si le joueur n'a pas gagné
                            {
                                Console.WriteLine(" L'ordinateur a choisi cette pièce :");
                                Affiche.AfficherPiece(NumeroPiece, TableauPieceGraphique);
                                // On demande au joueur de placer dans le plateau la piece chosie par l'ordi
                                bool PlaceVide;
                                do
                                {
                                    PlaceVide = false;
                                    Affiche.AfficherPlateau(TableauPlateauGraphique);
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    do
                                    {
                                        Console.Write(" A quelle ligne voulez-vous placer la piece? <donnez le numéro de ligne> : ");
                                        Ligne = int.Parse(Console.ReadLine());
                                        if (Ligne > 4)
                                            Console.WriteLine(" Donnez un numéro compris entre 1 et 4");
                                        Console.WriteLine();
                                    }
                                    while (Ligne > 4);
                                    do
                                    {
                                        Console.Write(" A quelle colonne voulez-vous placer la piece? <donnez le numéro de colonne> : ");
                                        Colonne = int.Parse(Console.ReadLine());
                                        if (Colonne > 4)
                                            Console.WriteLine(" Donnez un numéro compris entre 1 et 4");
                                    }
                                    while (Colonne > 4);
                                    PlaceVide = Test.VerifierPlaceVide(Ligne - 1, Colonne - 1, TableauPlateauCaracteristique);
                                    if (!PlaceVide)
                                        Console.WriteLine("\n La place n'est pas disponible.\n");
                                }
                                while (!PlaceVide);

                                General.PlacerPiece(NumeroPiece, Ligne - 1, Colonne - 1, TableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, PieceDispo);
                                Test.Scanner(Ligne - 1, Colonne - 1, QuartoPossible, TableauPlateauCaracteristique, TableauPieceCaracteristique);
                                Affiche.AfficherPlateau(TableauPlateauGraphique);
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                // c'est à ce moment la qu'on peut dire Quarto 
                                Reponse = Console.ReadLine();
                                Reponse = Reponse.ToLower();
                                if (Reponse == "quarto")
                                {
                                    do // on laisse la possibilité au joueur de donner plusieurs endroits ou il pense qu'il y a quarto
                                    {
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        Quarto = Test.VerifierQuarto(endroit, QuartoPossible);
                                        if (Quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Il n'y a pas de quarto sur la {0} (il est peut être présent depuis plusieurs tours et est donc invalide).\n Voulez-vous retenter ? (O/N) : ", endroit);
                                            Reponse = Console.ReadLine();

                                        }
                                    }
                                    while (Quarto == false && Reponse == "O");

                                }
                            }
                        }
                        if (Quarto == false)
                        {
                            Console.WriteLine("\n    Egalité !   ");
                        }
                    }
                    Console.WriteLine("\n█████████████████████████████████████████████████████████████████████████████████████████████████████\n");
                    

                    Console.ReadLine();
                    Console.Clear();
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

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (Jouer == "O");            
        }
    }
}
