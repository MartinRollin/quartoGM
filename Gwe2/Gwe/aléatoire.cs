using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gwe
{

    class aléatoire
    {

        //Martin:
        public static void JouerPieceAleatoire(int NumeroPiece, out int Ligne, out int Colonne, int[][] TableauPlateauCaracteristique, string[][][] TableauPlateauGraphique, string[][] TableauPieceGraphique, string[] tableauPieceCaracteristique, int[] tableauPiecesDisponible)
        {
            // Fonction appelee lorsque l'ordinateur veut placer une piece
            // on compte le nombre de cases vides

            int nbCasesVides = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                        nbCasesVides++;
                }
            }

            // casedispo est un tabeau qui stocke des tableaux d'entiers de la forme [ligne,colonne] tels que ligne et colonne sont les indices de ligne et colonne des cases vides du plateau
            int[][] casedispo = new int[nbCasesVides][];
            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (VerifierPlaceVide(i, j, TableauPlateauCaracteristique) == true)
                    {
                        casedispo[index] = new int[] { i + 1, j + 1 };
                        index++;
                    }
                }
            }

            // On choisit une case vide aleatoire, on actualise la derniere Ligne et la derniere Colonne jouees et on remplit le tableau caracteristique et le 
            Random R = new Random();
            int a = R.Next(nbCasesVides);
            Ligne = casedispo[a][0];
            Colonne = casedispo[a][1];
            PlacerPiece(NumeroPiece, Ligne - 1, Colonne - 1, tableauPieceCaracteristique, TableauPieceGraphique, TableauPlateauGraphique, TableauPlateauCaracteristique, tableauPiecesDisponible);
        }

        public static void PlacerPiece(int numeroPiece, int lignePiece, int colonnePiece, string[] tableauPieceCaracteristique, string[][] tableauPieceGraphique, string[][][] tableauPlateauGraphique, int[][] tableauPlateauCaracteristique, int[] tableauPiecesDisponible)
        {
            // On insère une piece qui occupe la position numeroPiece dans tableauPieceGraphique à la ligne lignePiece et la colonne colonnePiece dans tous les tableaux considérés

            tableauPlateauGraphique[lignePiece][colonnePiece] = tableauPieceGraphique[numeroPiece];
            tableauPlateauCaracteristique[lignePiece][colonnePiece] = numeroPiece;
            tableauPiecesDisponible[numeroPiece - 1] = 0;
        }

        public static string[] GenererPiece(string strPiece)
        // fonction qui renvoie la chaine de caractere correspondant à une piece graphique
        {
            string[] tabPiece = new string[10];

            for (int i = 0; i < 8; i++)
            {
                tabPiece[i] = strPiece.Substring(i * 13, 13);
            }
            return tabPiece;
        }


        // =========================================================================================

        public static string[][] CreerTableauPieceGraphique()
        //renvoie un tableau qui comprend le graphisme de chaque piece par ligne en chaine de caractere. la piece vide est la piece 17
        {
            string[] tab = new string[8];
            string[][] tableauPieceGraphique = new string[17][]; // La premiere piece est la piece vide

            // On remplit la derniere piece comme une piece vide
            tableauPieceGraphique[0] = new string[8];
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[0][i] = "b            ";
            }

            // les chaines de caracteres suivantes correspondent chacune à une piece. Le premier caractere de chaque ligne de chaque piece (ici "b") code la couleur de la piece (ici bleu)
            tab[0] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[1] = "b            b   ▄▀▀▀▀▄   b  █      █  b  █▀▄▄▄▄▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[2] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b   ▀▄▄▄▄▀   b            b            ";
            tab[3] = "b            b   ▄████▄   b  ████████  b  █▀████▀█  b  █      █  b  █      █  b   ▀▄▄▄▄▀   b            ";
            tab[4] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[5] = "b            b    ▄▀▀▄    b  ▄▀    █▄  b  █▀▄ ▄▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";
            tab[6] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █  ▄▀  b   ▀▄█▄▀    b            b            ";
            tab[7] = "b            b    ▄██▄    b  ▄██████▄  b  █▀███▀ █  b  █  █   █  b  █  █  ▄▀  b   ▀▄█▄▀    b            ";

            //generation des 8 pieces blanches *on decoupe chaque piece en 8 lignes de 13 caracteres*
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[i + 1] = GenererPiece(tab[i]);
            }

            // generation des 8 pieces noires, on prend les pieces precedentes et on remplace le b par un v a chaque debut de ligne. v qui code la couleur verte
            for (int i = 0; i < 8; i++)
            {
                tableauPieceGraphique[9 + i] = new string[8];
                for (int j = 0; j < 8; j++)
                {

                    tableauPieceGraphique[9 + i][j] = "v" + tableauPieceGraphique[i + 1][j].Substring(1, 12);
                }
            }



            return tableauPieceGraphique;
        }

        // =========================================================================================


        public static string[][][] InitialiserTableauPlateauGraphique()
        // cette fonction renvoie le tableau initialise, c'est à dire ne contenant que des pieces vides
        {
            string[][][] tableauPlateauGraphique = new string[4][][];
            string[][] pieceVide = CreerTableauPieceGraphique();        // la piece stockée à la 16 eme position de pieceVide est la pièce vide
            for (int i = 0; i < 4; i++)
            {
                tableauPlateauGraphique[i] = new string[4][];
                for (int j = 0; j < 4; j++)
                {
                    tableauPlateauGraphique[i][j] = new string[8];
                    tableauPlateauGraphique[i][j] = pieceVide[0];
                }
            }
            return tableauPlateauGraphique;
        }



        //On affiche le plateau mis à jour
        public static void AfficherPlateau(string[][][] tab)
        {
            int j;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ");
            for (int l = 0; l < 4; l++)
                Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄ ");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int l = 0; l < 8; l++) //on parcours les lignes des pieces graphiques 1 par 1
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█"); // Choix de cette séparation
                    j = 0; //pour afficher correctement la ligne, on doit passer d'une colonne à l'autre.
                    while (j < 4)
                    {
                        if (tab[i][j][l][0] == 'b') // la couleur est indiqué par le premier caractère de chaque string (b=blanc, v=vert)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(tab[i][j][l].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(tab[i][j][l].Substring(1));
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█"); // Choix de cette séparation
                        if ((l == 3)&&(j==3))
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

        //Afficher graphiquement les pièces disponibles ainsi que le numéro à afficher si on veut la prendre une
        // on n'affiche que les pièces disponibles, dans les cellules contenant un entier naturel non nul
        public static void AfficherPieceDisponible(string[][] graph, int[] dispo)
        {
            int j;

            //on affiche par 4 lignes de 4 pièces (en mettant du vide si la pièce n'est plus disponible)
            // ligne 1:
            for (int k = 0; k < 4; k++)
            {
                for (int i = 1; i < 8; i++) // on affiche ligne par ligne les pièces
                {
                    j = 4 * k;
                    while (j < 4 * (k + 1))
                    {
                        if (graph[dispo[j]][i][0] == 'b') // la pièce dispo va contenir l'entier correspondant à la pièce à présenter (peut valoir 17, ce qui oriente vers la pièce vide dans notre graph en place 16)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(graph[dispo[j]][i].Substring(1));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(graph[dispo[j]][i].Substring(1));
                        }
                        Console.Write("  ");
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 4 * k; i < 4 * (k + 1); i++) //on veut placer le numéro associé à la pièce 
                    if (i<9)
                        Console.Write("      {0}       ", i + 1);
                    else
                        Console.Write("     {0}       ", i + 1);
                Console.WriteLine();
            }
        
        }
        


        //On verifie que la position où veut jouer le joueur est disponible
        public static bool VerifierPlaceVide(int ligne, int colonne, int[][] tab)
        {
            if (tab[ligne-1][colonne-1] == 0)
                return (true);
            else
                return (false);
        }

        //on vérifie si la pièce est diponible
        public static bool VerifierpieceDisponible(int piece, int[] tab)
        {
            if (tab[piece-1] == 0)
                return (false);
            else
                return (true);
        }

        // Afin de permettre à l'ordinateur de vérifier le Quarto, il doit d'abord checker si il y a 4 pièces alignées

        // Commençons par les colonnes
        public static bool VerifierColonneVide(int colonne, int[][] tab) //on parcours la colonne en comptant le nombre de pièce, si il vaut 4, alors la colonne est pleine
        {
            int NbPiece = 0;
            for (int i = 0; i < 4; i++)
                if (tab[i][colonne-1] != 0)
                    NbPiece++;
            if (NbPiece != 4)
                return (true);
            else
                return (false);
        }

        //Nous faisons de même pour les lignes
        public static bool VerifierLigneVide(int ligne, int[][] tab)
        {
            int NbPiece = 0;
            for (int j = 0; j < 4; j++)
                if (tab[ligne-1][j] != 0)
                    NbPiece++;
            if (NbPiece != 4)
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
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
            else
            {
                for (int i = 0; i <4; i++)
                    if (tab[i][3-i] != 0)
                        NbPiece++;
                if (NbPiece != 4)
                    return (true);
                else
                    return (false);
            }
        }

        //on teste si 4 pièces (représentées pas des entiers distincts compris entre 1 et 16) contienne 1 caractère commun
        public static bool Tester4Pieces(int Piece1, int Piece2, int Piece3, int Piece4, string[] tab)
        {
            bool sortie = false;
            int k = 0;
            //les caractères sont représentés par une chaine de 4 caractères. Si les 4 pièces ont un des caractères commun (au même emplacement) on renvoie true
            while ((!sortie) && (k < 4))
                if ((tab[Piece1 - 1][k] == tab[Piece2 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece3 - 1][k]) && (tab[Piece1 - 1][k] == tab[Piece4 - 1][k]))
                    sortie = true;
                else
                    k++;
            return (sortie);
        }


        public static void Scanner(int ligne, int colonne, string[] quarto, int[][] plateau, string[] caracteristiquesPieces)
        {
            if (Tester4Pieces(plateau[ligne][0], plateau[ligne][1], plateau[ligne][2], plateau[ligne][3], caracteristiquesPieces))
                quarto[0] = "ligne " + ligne;
            else
                quarto[0] = "vide";
            if (Tester4Pieces(plateau[0][colonne], plateau[1][colonne], plateau[2][colonne], plateau[3][colonne], caracteristiquesPieces))
                quarto[1] = "colonne " + colonne;
            else
                quarto[1] = "vide";
            if (colonne == ligne)
                if (Tester4Pieces(plateau[0][0], plateau[1][1], plateau[2][2], plateau[3][3], caracteristiquesPieces))
                    quarto[2] = "diagonale 1";
                else
                    quarto[2] = "vide";
            else
                if (colonne == 3 - ligne)
                    if (Tester4Pieces(plateau[3][0], plateau[2][1], plateau[1][2], plateau[0][3],caracteristiquesPieces))
                        quarto[2] = "diagonale 2";
                    else
                        quarto[2] = "vide";

        }


        /* //On crée une fonction qui permettra à l'ordinateur de vérifier si il y a un quarto sur le plateau
        public static bool ScannerPlateau(string[][] caractPieces, int[][] plateau)
        {
            bool sortie = false;
            int k = 0;
            //On commence par vérifier si le quarto est sur une colonne ou une ligne, et on affiche l'endroit du quarto si il existe
            while ((!sortie) && (k < 4))
                if (!VerifierColonneVide(k, plateau))
                    if (Tester4Pieces(plateau[0][k], plateau[1][k], plateau[2][k], plateau[3][k], caractPieces))
                    {
                        Console.WriteLine(" Quarto sur la colonne {0}", k+1);
                        sortie = true;
                    }
                    else
                        k++;
                else
                    k++;

            //on a une conclusion sur les colonnes, si il n'y a pas de quarto, on se penche que les lignes, reprenant la même idée
            k = 0;
            while ((!sortie) && (k < 4))
                if (!VerifierLigneVide(k, plateau))
                    if (Tester4Pieces(plateau[k][0],plateau[k][1], plateau[k][2], plateau[k][3], caractPieces))
                    {
                        Console.WriteLine(" Quarto sur la ligne {0}", k+1);
                        sortie = true;
                    }
                    else
                        k++;
                else
                    k++;

            //Dans le dernier cas, on regarde les deux digonales
            if(!VerifierDiagonale(1,plateau))
                if (Tester4Pieces(plateau[0][0], plateau[1][1], plateau[2][2], plateau[3][3], caractPieces))
                {
                    Console.WriteLine("Quarto sur la 1ére diagonale");
                    sortie = true;
                }
            else
                if (!VerifierDiagonale(2, plateau))
                    if (Tester4Pieces(plateau[0][3], plateau[1][2], plateau[2][1], plateau[3][0], caractPieces))
                    {
                        Console.WriteLine("Quarto sur la 2éme diagonale");
                        sortie = true;
                    }
            return (sortie);
        }*/



        public static int ChoisirPieceAleatoire(int[] piecesdispo)
        {
            Random rand = new Random();
            int sortie = rand.Next(1, 17);
            while (piecesdispo[sortie-1]==0)
                sortie = rand.Next(1, 17);
            return (sortie);
        }


        public static bool VerifierQuarto(string EntreeJoueur, string[] QuartoPossible)
        {
            bool sortie = false;
            int k = 0;
            while ((!sortie) && (k < 4))
                if (QuartoPossible[k] == EntreeJoueur)
                    sortie = true;
                else
                    k++;
            return (sortie);
        }

        public static void Modif (ref string[] Quarto)
        {
            Quarto = new string[3];
        }




        static void Main(string[] args)
        {
            /*int[] TableauPiecesDisponibles = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            string[][][] TableauPlateauGraphique = InitialiserTableauPlateauGraphique();
            string[][] TableauPiecesGraphiques = CreerTableauPieceGraphique();

            AfficherPlateau(TableauPlateauGraphique);

            TableauPiecesDisponibles[1] = 0;
            for(int i=0; i<9;i++)
               Console.WriteLine(TableauPiecesGraphiques[1][i]);
            AfficherPieceDisponible(TableauPiecesGraphiques, TableauPiecesDisponibles);
            Console.WriteLine(VerifierpieceDisponible(1, TableauPiecesDisponibles));

            Console.ReadLine();*/
            /*
            string[] QuartoPossible = { "ligne 1", "colonne 2", "diagonale 2" };
            Modif(ref QuartoPossible);
            for (int i = 0; i < 3; i++)
                Console.WriteLine(QuartoPossible[i]);
            Console.ReadLine();*/
            int[] TableauPiecesDisponibles = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            string[][][] TableauPlateauGraphique = InitialiserTableauPlateauGraphique();
            string[][] TableauPiecesGraphiques = CreerTableauPieceGraphique();

            int ligne = -1;
            int colonne = -1;
            string[] tableauPieceCaracteristique = { "pbrc", "gbrc", "pbrp", "gbrp", "pbcc", "gbcc", "pbcp", "gbcp", "pvrc", "gvrc", "pvrp", "gvrp", "pvcc", "gvcc", "pvcp", "gvcp" };
            int[][] Plateau = new int[4][];
            for (int i = 0; i < 4; i++)
                Plateau[i] = new int[4];
            Plateau[0][0] = 1;
            //Plateau[0][1] = 2;
            //Plateau[0][3] = 3;
            Plateau[1][0] = 4;
            Plateau[2][0] = 5;
            //Plateau[1][3] = 7;
            //Plateau[3][3] = 8;
            //Plateau[1][1] = 9;
            //Plateau[2][1] = 10;
            //Plateau[3][0] = 11;
            int[][] retour = intelligent.VerifierUnePlace(Plateau);

            Console.WriteLine("Plateau :");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(" " + Plateau[i][j]);
                Console.WriteLine();
            }

            Console.WriteLine("Places dispo :");
                    for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(" " + retour[i][j]);
                Console.WriteLine();
            }
            Console.Write( " {0} {1} \n", retour[2][0], retour[2][1]);

            Console.WriteLine("Quarto:");
            intelligent.PlacerQuarto(6, retour, Plateau, tableauPieceCaracteristique, out ligne, out colonne, TableauPlateauGraphique,TableauPiecesGraphiques,new int[] { 0,2,3,0,0,6,7,8,9,10,11,12,13,14,15,16});
            Console.WriteLine("Plateau ensuite:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(" " + Plateau[i][j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
