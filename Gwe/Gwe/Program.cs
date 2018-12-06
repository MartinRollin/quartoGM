using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{

    //On affiche le plateau mis à jour
    public static void AfficherPlateau(char[][][,] tab)
    {
        int k;
        int j;
        for (int i = 0; i < 4; i++)
        {
            for (int l = 0; l < tab[0][0].Length; l++) //on parcours les lignes des pieces graphiques 1 par 1
            {
                j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                while (j < 4)
                {
                    k = 0;
                    while (k < tab[i][j].Length)
                    {
                        Console.Write(tab[i][j][k, l]);
                        k++;
                    }
                    Console.Write("|"); // Choix de cette séparation
                    j++;
                }
                Console.WriteLine();
            }
            for (int l = 0; l < tab[0][0].Length; l++)
                Console.Write("_");
        }
    } 

    //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut en prendre une (lesunes au dessus des autres)
    public static void AfficherPieceDisponible(char[][,] graph, int[] dispo)
    {
        for (int i=0; i<16;i++) //on parcours le tableau nous indiquant les pièces disponibles (de taille 16)
            if (dispo[i]!=0) // on n'afiche que les pièces disponibles
            {
                for (int k = 0; k < graph[0].Length; k++)
                {
                    for (int l = 0; l < graph[0].Length; l++)
                        Console.Write(graph[i][k, l]);
                    Console.WriteLine();
                }
                for (int j = 0; j < (graph[0].Length / 2); j++) //on veut placer le numéro associé à la pièce 
                    Console.Write(" ");
                Console.Write(i + 1);
            }
    }

    //On verifie que la position où veut jouer le joueur est disponible
    public static bool VerifierPlaceVide(int ligne, int colonne, int[][] tab)
    {
        if (tab[ligne][colonne] == 0)
            return (true);
        else
            return (false);
    }

    //on vérifie si la pièce est diponible
    public static bool VerifierpieceDisponible(int piece, int[] tab)
    {
        if (tab[piece - 1] == 0)
            return (false);
        else
            return (true);
    }

    // Afin de permettre à l'ordinateur de vérifier le Quarto, il doit d'abord checker si il y a 4 pièces alignées
    
    // Commençons par les colonnes
    public static bool VerifierColonneVide(int colonne,int[][] tab) //on parcours la colonne en comptant le nombre de pièce, si il vaut 4, alors la colonne est pleine
    {
        int NbPiece = 0;
        for (int i = 0; i < 4; i++)
            if (tab[i][colonne] != 0)
                NbPiece++;
        if (NbPiece == 4)
            return (true);
        else
            return (false);
    }

    //Nous faisons de même pour les lignes
    public static bool VerifierColonneVide(int ligne, int[][] tab)
    {
        int NbPiece = 0;
        for (int j = 0; j < 4; j++)
            if (tab[ligne][j] != 0)
                NbPiece++;
        if (NbPiece == 4)
            return (true);
        else
            return (false);
    }

    //pour les diagonales (on rentrera celle que l'on veut (1 ou 2))
    public static bool VerifierDiagonale(int laquelle, int[][] tab)
    {
        int NbPiece = 0;
        if (laquelle == 1)
        {
            for (int i = 0; i < 4; i++)
                if (tab[i][i] != 0)
                    NbPiece++;
            if (NbPiece == 4)
                return (true);
            else
                return (false);
        }
        else
        {
            for (int i = 3; i <= 0 ; i--)
                if (tab[i][i] != 0)
                    NbPiece++;
            if (NbPiece == 4)
                return (true);
            else
                return (false);
        }
    }

    //
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tab1 =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            char[][][,] tab = new char[1][][,];
            tab[0] = new char[1][,] ;
            tab[0][0] = tab1;          
            Console.ReadLine();
            ;

        }
    }
}
