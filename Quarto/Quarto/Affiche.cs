﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Affiche
    {
        /// <summary>
        /// Affichage des règles
        /// </summary>
        public static void AfficherRegles() // regles du quarto adaptées a notre algorithme
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  ▄▄▄▄█████████████████████████████████████████████████████████████████████████████████████████▄▄▄▄");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("\n\tPRESENTATION ET PREPARATION\n");
            Console.WriteLine(" - Un plateau de 16 cases");
            Console.WriteLine(" - 16 pièces différentes ayant chacune 4 caractères :");
            Console.WriteLine(" claire ou foncée, ronde ou carrée, haute ou basse, pleine ou creuse.");
            Console.ReadLine();
            Console.WriteLine("\tBUT DU JEU\n");
            Console.WriteLine(" Créer sur le plateau un alignement de 4 pièces ayant au moins un caractère commun.");
            Console.WriteLine(" Cet alignement peut - être horizontal, vertical ou diagonal.");
            Console.ReadLine();
            Console.WriteLine("\tDEROULEMENT D’UNE PARTIE\n");
            Console.WriteLine(" - Le premier joueur est tiré au sort.");
            Console.WriteLine(" - Il choisit une des 16 pièces et la donne à son adversaire.");
            Console.WriteLine(" - Celui - ci doit la placer sur une des cases du plateau et choisir ensuite une des 15 pièces");
            Console.WriteLine(" restantes pour la donner à son adversaire.");
            Console.WriteLine(" - A son tour, celui - ci la place sur une case libre et ainsi de suite...");
            Console.ReadLine();
            Console.WriteLine("\tGAIN DE LA PARTIE\n");
            Console.WriteLine(" La partie est gagnée par le premier joueur qui annonce “QUARTO”");
            Console.WriteLine(" 1 : Un joueur fait “QUARTO” et gagne la partie lorsque, en plaçant la pièce donnée:");
            Console.WriteLine(" -> Il crée une ligne de 4 claires ou 4 foncées ou 4 rondes ou 4 carrées ou 4 hautes ou 4");
            Console.WriteLine(" basses ou 4 pleines ou 4 creuses.");
            Console.WriteLine(" Plusieurs caractères peuvent se cumuler.");
            Console.WriteLine(" -> Il n’est pas obligé d’avoir lui même déposé les trois autres pièces.");
            Console.WriteLine(" -> Il doit alors écrire “Quarto“ juste après avoir posé la pièce.\n");
            Console.WriteLine(" 2 : Si ce joueur n’a pas vu l’alignement et donne une pièce à l’adversaire:");
            Console.WriteLine(" -> Ce dernier peut au début de son tour écrire “Quarto”, et montrer l’alignement: c’est lui");
            Console.WriteLine(" qui gagne la partie.\n");
            Console.WriteLine(" 3 : Si aucun des joueurs ne voit l’alignement durant le tour de jeu où il se crée, cet");
            Console.WriteLine(" alignement perd toute sa valeur et la partie suit son cours.");
            Console.ReadLine();
            Console.WriteLine("\tFIN DE LA PARTIE\n");
            Console.WriteLine(" - Victoire: un joueur annonce et montre un “QUARTO”.");
            Console.WriteLine(" - Egalité: toutes les pièces ont été posées sans vainqueur.");
            Console.ReadLine();
            Console.WriteLine("\tDUREE D’UNE PARTIE\n");
            Console.WriteLine(" - De 10 à 20 minutes.\n");
            Console.ReadLine();
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("  ▀▀▀▀█████████████████████████████████████████████████████████████████████████████████████████▀▀▀▀\n");


        }


        // =========================================================================================
        /// <summary>
        /// Affichage du plateau
        /// </summary>
        /// <param name="TableauPlateauGraphique"></param>
        public static void AfficherPlateau(string[][][] TableauPlateauGraphique)
        {
            int j;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ");
            for (int l = 0; l < 4; l++)
                Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄ ");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 8; l++) //on parcourt les lignes des pièces graphiques 1 par 1
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("█"); // Choix de cette séparation
                    j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                    while (j < 4)
                    {
                        if (TableauPlateauGraphique[i][j][l][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=bleu, v=vert), caratère qui ne sera pas affiché
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(TableauPlateauGraphique[i][j][l].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(TableauPlateauGraphique[i][j][l].Substring(1));
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█"); // Choix de cette séparation
                        if ((l == 3) && (j == 3))
                            Console.Write("  {0}", i + 1);
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                for (int l = 0; l < 4; l++)
                    Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄ ");
                Console.WriteLine();
            }
            for (int i = 0; i < 4; i++)
                Console.Write("      {0}      ", i + 1);
            Console.WriteLine();
        }

        // =========================================================================================
        /// <summary>
        /// Afficher graphiquement les pièces disponibles ainsi que le numéro à saisir pour les sélectionner
        /// </summary>
        /// <param name="TableauPieceGraphique"></param>
        /// <param name="TableauPieceDisponible"></param>

        // on n'affiche que les pièces disponibles, dans les cellules contenant un entier naturel non nul
        public static void AfficherPieceDisponible(string[][] TableauPieceGraphique, int[] TableauPieceDisponible)
        {
            int j;

            //on affiche par 4 lignes de 4 pièces (en mettant du vide si la pièce n'est plus disponible)
            for (int k = 0; k < 4; k++)
            {
                for (int i = 1; i < 8; i++) // on affiche ligne par ligne les pièces
                {
                    j = 4 * k;
                    while (j < 4 * (k + 1))
                    {
                        if (TableauPieceGraphique[TableauPieceDisponible[j]][i][0] == 'b') // TableauPieceDispo va contenir l'entier correspondant à la pièce à présenter (peut valoir 0, ce qui oriente vers la pièce vide dans notre TableauPieceGraphique en place 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(TableauPieceGraphique[TableauPieceDisponible[j]][i].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(TableauPieceGraphique[TableauPieceDisponible[j]][i].Substring(1));
                        }
                        Console.Write("  ");
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 4 * k; i < 4 * (k + 1); i++) //on place le numéro associé à la pièce 
                    if (i < 9)
                        Console.Write("      {0}       ", i + 1);
                    else
                        Console.Write("     {0}       ", i + 1);
                Console.WriteLine();
            }

        }

        // =========================================================================================
        /// <summary>
        /// On affiche graphiquement une pièce seule.
        /// </summary>
        /// <param name="NumeroPiece"></param>
        /// <param name="TableauPieceGraphique"></param>
        public static void AfficherPiece(int NumeroPiece, string[][] TableauPieceGraphique)
        {
            for (int i = 0; i < 8; i++)
            {
                if (TableauPieceGraphique[NumeroPiece][i][0] == 'b') 
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(TableauPieceGraphique[NumeroPiece][i].Substring(1));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(TableauPieceGraphique[NumeroPiece][i].Substring(1));
                }
            }
        }
    }
}
