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
            
            Console.SetWindowSize(60, 44);
            Affiche.AfficherRegles();
            char jouer;
            do
            {
                Console.Write(" Voulez vous commencer une partie? (O/N) : ");
                jouer = char.Parse(Console.ReadLine());
                if (jouer == 'N')
                {
                    Console.WriteLine("\n Merci d'avoir participé ! ");
                    Console.ReadLine();
                }
                else
                {
                    // initialisation de tableauPieceCaracteristique " taille: (p)etit/(g)rand + couleur : (v)ert/(b)leu + forme : (c)arre/(r)ond + remplissage : (c)reu/(p)lein "
                    string[] tableauPieceCaracteristique = { "pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp" };

                    // initialisation tableau qui contiendra les quarto pouvant être énoncés
                    string[] QuartoPossible = { "vide", "vide", "vide" };


                    //test de PlacerPiece
                    string[][] tableauPieceGraphique = CreerTableaux.CreerTableauPieceGraphique();
                    string[][][] tableauPlateauGraphique = CreerTableaux.InitialiserTableauPlateauGraphique();
                    int[] PieceDispo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                    int[][] tableauPlateauCaracteristique = new int[4][];
                    int Colonne = 0;
                    int Ligne = 0;
                    string reponse = "O";
                    int tour = 1;
                    bool quarto = false;

                    for (int i = 0; i < 4; i++)
                    {
                        tableauPlateauCaracteristique[i] = new int[] { 0, 0, 0, 0 };
                    }
                    Random rand = new Random();
                    int joueur = rand.Next(2);            // On determine quel joueur va commencer, 0 -> l'ordi commence, 1 -> le joueur commence

                    // L'ordinateur commence a jouer
                    if (joueur == 0)
                    {
                        Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                        Console.WriteLine("   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                        Console.WriteLine("   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                        Console.WriteLine("   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀");
                        Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.ReadLine();
                        Console.WriteLine("\n Voici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                        Console.ReadLine();
                        int NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                        joueur = 1;
                        while (tour < 16 && !quarto)        // On effectue tous les tours sauf le dernier (comme le dernier joueur ne peut pas donner de piece a l'autre)
                        {

                            // Deroulement du tour du joueur humain
                            if (joueur == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                                Console.WriteLine("                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                                Console.WriteLine("                █   █     █   █   █   █ ");
                                Console.WriteLine("                █▀▀▀█     █   █   █   █ ");
                                Console.WriteLine("                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                                Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
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
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                        if (quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Le quarto n'est pas exact, il a été créé il y a plusieurs tours et n'est donc pas valide.\n Voulez-vous retenter ? (O/N) : ");
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
                                        do
                                        {
                                            Console.Write("A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                            string endroit = Console.ReadLine();
                                            quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                            if (quarto == false)
                                            {
                                                Console.Write("Le quarto n'est pas exact, il a été créé il y a plusieurs tours et n'est donc pas valide.\n Voulez-vous retenter ? (O/N) : ");
                                                reponse = Console.ReadLine();
                                                Console.WriteLine();

                                            }
                                        }
                                        while (quarto == false && reponse == "O");

                                    }
                                    if (quarto == false)
                                    {
                                        bool disponible = false;
                                        do                         // On fait en sorte que le joueur choisisse une pièce qui soit disponible
                                        {

                                            Console.WriteLine("Voici les pièces disponibles :\n");
                                            Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("\n   Quelle piece donner à l'ordinateur ? :");
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
                            }

                            else if (joueur == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                                Console.WriteLine("   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                                Console.WriteLine("   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                                Console.WriteLine("   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                                Console.WriteLine("   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀ ");
                                Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                                Console.ReadLine();

                                // On verifie le quarto de l'ordinateur
                                int verifal = rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici

                                if (verifal > 3 && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                {
                                    quarto = true;
                                    if (QuartoPossible[0] != "vide")
                                        Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                    else
                                    {
                                        if (QuartoPossible[1] != "vide")
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                        else
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
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
                                    // niveau de difficulté de l'ordi ici

                                    if (verifal > 3 && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                    {
                                        quarto = true;
                                        if (QuartoPossible[0] != "vide")
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                        else
                                        {
                                            if (QuartoPossible[1] != "vide")
                                                Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                            else
                                                Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nVoici les pièces disponibles :\n");
                                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                        Console.ReadLine();
                                        NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                                    }

                                    joueur = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.WriteLine("                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                        Console.WriteLine("                █   █     █   █   █   █ ");
                        Console.WriteLine("                █▀▀▀█     █   █   █   █ ");
                        Console.WriteLine("                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                        Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.WriteLine();
                        Console.ReadLine();

                        Console.WriteLine("\nVoici les pièces disponibles :\n");
                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                        Console.Write("Quelle piece veux tu donner à l'ordinateur? : ");
                        int NumeroPiece = int.Parse(Console.ReadLine());
                        joueur = 0;
                        while (tour < 16 && !quarto)        // On effectue tous les tours sauf le dernier (comme le dernier joueur ne peut pas donner de piece a l'autre)
                        {

                            // Deroulement du tour du joueur humain
                            if (joueur == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                                Console.WriteLine("                 ▄▄▄    ▄▄▄▄▄  ▄▄▄   ▄▄▄");
                                Console.WriteLine("                █   █     █   █   █   █ ");
                                Console.WriteLine("                █▀▀▀█     █   █   █   █ ");
                                Console.WriteLine("                ▀   ▀     ▀    ▀▀▀   ▀▀▀");
                                Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
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
                                        Console.Write(" A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                        string endroit = Console.ReadLine();
                                        quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                        if (quarto == true)
                                        {
                                            Console.WriteLine("\n Bravo vous avez gagné !");
                                        }
                                        else
                                        {
                                            Console.Write(" Le quarto n'est pas exact, il a été créé il y a plusieurs tours et n'est donc pas valide.\n Voulez-vous retenter ? (O/N) : ");
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
                                        do
                                        {
                                            Console.Write("A quelle ligne/colonne/diagonale y a t-il quarto ? < ecrire par exemple : ligne 2, diagonale 1 > : ");
                                            string endroit = Console.ReadLine();
                                            quarto = General.VerifierQuarto(endroit, QuartoPossible);
                                            if (quarto == false)
                                            {
                                                Console.Write("Le quarto n'est pas exact, il a été créé il y a plusieurs tours et n'est donc pas valide.\n Voulez-vous retenter ? (O/N) : ");
                                                reponse = Console.ReadLine();
                                                Console.WriteLine();

                                            }
                                        }
                                        while (quarto == false && reponse == "O");

                                    }
                                    if (quarto == false)
                                    {
                                        bool disponible = false;
                                        do                         // On fait en sorte que le joueur choisisse une pièce qui soit disponible
                                        {

                                            Console.WriteLine("Voici les pièces disponibles :\n");
                                            Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write("\n   Quelle piece donner à l'ordinateur ? :");
                                            NumeroPiece = int.Parse(Console.ReadLine());
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
                            }

                            else if (joueur == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                                Console.WriteLine("   ▄   ▄   ▄▄▄  ▄▄▄▄  ▄▄▄▄  ▄▄▄     ▄▄▄  ▄▄▄   ▄   ▄ ▄▄▄▄");
                                Console.WriteLine("   █   ▀  █   █ █   █ █   █  █       █  █   █  █   █ █▄  ");
                                Console.WriteLine("   █      █   █ █▀▀▀▄ █   █  █    █  █  █   █  █   █ █   ");
                                Console.WriteLine("   ▀▀▀     ▀▀▀  ▀   ▀ ▀▀▀▀  ▀▀▀    ▀▀    ▀▀▀    ▀▀▀  ▀▀▀▀ ");
                                Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                                Console.ReadLine();

                                // On verifie le quarto de l'ordinateur
                                int verifal = rand.Next(1, 6);
                                // niveau de difficulté de l'ordi ici

                                if (verifal > 3 && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                {
                                    quarto = true;
                                    if (QuartoPossible[0] != "vide")
                                        Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                    else
                                    {
                                        if (QuartoPossible[1] != "vide")
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                        else
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
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
                                    // niveau de difficulté de l'ordi ici

                                    if (verifal > 3 && (QuartoPossible[0] != "vide" || QuartoPossible[1] != "vide" || QuartoPossible[2] != "vide"))  // ici on ne sait pas où est le quarto
                                    {
                                        quarto = true;
                                        if (QuartoPossible[0] != "vide")
                                            Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[0]);
                                        else
                                        {
                                            if (QuartoPossible[1] != "vide")
                                                Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[1]);
                                            else
                                                Console.WriteLine("L'ordinateur gagne la partie ! Il y a un quarto à la " + QuartoPossible[2]);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nVoici les pièces disponibles :\n");
                                        Affiche.AfficherPieceDisponible(tableauPieceGraphique, PieceDispo);
                                        Console.ReadLine();
                                        NumeroPiece = General.ChoisirPieceAleatoire(PieceDispo);
                                    }

                                    joueur = 1;
                                }
                            }
                        }
                    }
                    Console.WriteLine("\n▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀\n");
                    
                    Console.ReadLine();
                }
            }
            while (jouer == 'O');            
        }
    }
}
