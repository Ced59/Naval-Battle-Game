using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale
{
    class DisplayGame
    {

        PositionText Position = new PositionText();


        public string IntroGame()
        {
            Position.PasserLignes(2);
            Position.CentrerLeTexte("///////////////////////////////");
            Position.CentrerLeTexte("0                             /");
            Position.CentrerLeTexte("0       Bataille Navale       /");
            Position.CentrerLeTexte("0                             /");
            Position.CentrerLeTexte("0000000000000000000000000000000");
            Position.PasserLignes(3);

            Console.WriteLine("Veuillez entrer votre pseudo: ");
            string pseudo = Console.ReadLine();
            string Welcome = $"Bonjour (pseudo)";

            Console.Clear();

            Position.PasserLignes(2);
            Position.CentrerLeTexte(Welcome);
            Position.PasserLignes(2);
            Position.CentrerLeTexte("Règles du jeu:");
            Position.PasserLignes(2);
            Position.CentrerLeTexte("Vous devez trouver et couler tous les bateaux de votre ennemi en un minimum de coups.");
            Position.CentrerLeTexte("Il y a 5 bateaux différents à trouver: ");
            Position.CentrerLeTexte("Un porte-avion (5 cases)");
            Position.CentrerLeTexte("Un croiseur (4 cases)");
            Position.CentrerLeTexte("Un contre-torpilleur (3 cases)");
            Position.CentrerLeTexte("Un sous-marin (3 cases)");
            Position.CentrerLeTexte("Un torpilleur (2 cases)");
            Console.ReadKey(true);
            Console.Clear();


            if (File.Exists("monFichier.txt"))
            {
                StreamReader reader = new StreamReader("monFichier.txt");
                string Scores = reader.ReadToEnd();
                reader.Close();

                Console.WriteLine("Scores enregistrés:");
                Console.WriteLine("");
                Console.WriteLine(Scores);
                Console.ReadKey(true);
                Console.Clear();
            }



            return pseudo;
        }


        public void DisplayGameArea(string[ , ] tab)
        { 
            Console.Clear();
            Position.PasserLignes(2);
            Position.CentrerLeTexte("Tableau de jeu");
            Position.PasserLignes(3);

            Position.CentrerLeTexte("    " + " A " + " B " + " C " + " D " + " E " + " F " + " G " + " H " + " I " + " J ");
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 1  "  + tab[0, 0] + "  " + tab[0, 1] + "  " + tab[0, 2] + "  " + tab[0, 3] + "  " + tab[0, 4] + "  " + tab[0, 5] + "  " + tab[0, 6] + "  " + tab[0, 7] + "  " + tab[0, 8] + "  " + tab[0, 9] );
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 2  " + tab[1, 0] + "  " + tab[1, 1] + "  " + tab[1, 2] + "  " + tab[1, 3] + "  " + tab[1, 4] + "  " + tab[1, 5] + "  " + tab[1, 6] + "  " + tab[1, 7] + "  " + tab[1, 8] + "  " + tab[1, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 3  " + tab[2, 0] + "  " + tab[2, 1] + "  " + tab[2, 2] + "  " + tab[2, 3] + "  " + tab[2, 4] + "  " + tab[2, 5] + "  " + tab[2, 6] + "  " + tab[2, 7] + "  " + tab[2, 8] + "  " + tab[2, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 4  " + tab[3, 0] + "  " + tab[3, 1] + "  " + tab[3, 2] + "  " + tab[3, 3] + "  " + tab[3, 4] + "  " + tab[3, 5] + "  " + tab[3, 6] + "  " + tab[3, 7] + "  " + tab[3, 8] + "  " + tab[3, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 5  " + tab[4, 0] + "  " + tab[4, 1] + "  " + tab[4, 2] + "  " + tab[4, 3] + "  " + tab[4, 4] + "  " + tab[4, 5] + "  " + tab[4, 6] + "  " + tab[4, 7] + "  " + tab[4, 8] + "  " + tab[4, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 6  " + tab[5, 0] + "  " + tab[5, 1] + "  " + tab[5, 2] + "  " + tab[5, 3] + "  " + tab[5, 4] + "  " + tab[5, 5] + "  " + tab[5, 6] + "  " + tab[5, 7] + "  " + tab[5, 8] + "  " + tab[5, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 7  " + tab[6, 0] + "  " + tab[6, 1] + "  " + tab[6, 2] + "  " + tab[6, 3] + "  " + tab[6, 4] + "  " + tab[6, 5] + "  " + tab[6, 6] + "  " + tab[6, 7] + "  " + tab[6, 8] + "  " + tab[6, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 8  " + tab[7, 0] + "  " + tab[7, 1] + "  " + tab[7, 2] + "  " + tab[7, 3] + "  " + tab[7, 4] + "  " + tab[7, 5] + "  " + tab[7, 6] + "  " + tab[7, 7] + "  " + tab[7, 8] + "  " + tab[7, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 9  " + tab[8, 0] + "  " + tab[8, 1] + "  " + tab[8, 2] + "  " + tab[8, 3] + "  " + tab[8, 4] + "  " + tab[8, 5] + "  " + tab[8, 6] + "  " + tab[8, 7] + "  " + tab[8, 8] + "  " + tab[8, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte("10  " + tab[9, 0] + "  " + tab[9, 1] + "  " + tab[9, 2] + "  " + tab[9, 3] + "  " + tab[9, 4] + "  " + tab[9, 5] + "  " + tab[9, 6] + "  " + tab[9, 7] + "  " + tab[9, 8] + "  " + tab[9, 9]);


        }

        public void DisplayGameAreaInt ( int[,] tab )
        {
            Console.Clear();
            Position.PasserLignes(3);
            Position.CentrerLeTexte("Tableau de jeu");
            Position.PasserLignes(3);

            Position.CentrerLeTexte("    " + " A " + " B " + " C " + " D " + " E " + " F " + " G " + " H " + " I " + " J ");
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 1  " + tab[0, 0] + "  " + tab[0, 1] + "  " + tab[0, 2] + "  " + tab[0, 3] + "  " + tab[0, 4] + "  " + tab[0, 5] + "  " + tab[0, 6] + "  " + tab[0, 7] + "  " + tab[0, 8] + "  " + tab[0, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 2  " + tab[1, 0] + "  " + tab[1, 1] + "  " + tab[1, 2] + "  " + tab[1, 3] + "  " + tab[1, 4] + "  " + tab[1, 5] + "  " + tab[1, 6] + "  " + tab[1, 7] + "  " + tab[1, 8] + "  " + tab[1, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 3  " + tab[2, 0] + "  " + tab[2, 1] + "  " + tab[2, 2] + "  " + tab[2, 3] + "  " + tab[2, 4] + "  " + tab[2, 5] + "  " + tab[2, 6] + "  " + tab[2, 7] + "  " + tab[2, 8] + "  " + tab[2, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 4  " + tab[3, 0] + "  " + tab[3, 1] + "  " + tab[3, 2] + "  " + tab[3, 3] + "  " + tab[3, 4] + "  " + tab[3, 5] + "  " + tab[3, 6] + "  " + tab[3, 7] + "  " + tab[3, 8] + "  " + tab[3, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 5  " + tab[4, 0] + "  " + tab[4, 1] + "  " + tab[4, 2] + "  " + tab[4, 3] + "  " + tab[4, 4] + "  " + tab[4, 5] + "  " + tab[4, 6] + "  " + tab[4, 7] + "  " + tab[4, 8] + "  " + tab[4, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 6  " + tab[5, 0] + "  " + tab[5, 1] + "  " + tab[5, 2] + "  " + tab[5, 3] + "  " + tab[5, 4] + "  " + tab[5, 5] + "  " + tab[5, 6] + "  " + tab[5, 7] + "  " + tab[5, 8] + "  " + tab[5, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 7  " + tab[6, 0] + "  " + tab[6, 1] + "  " + tab[6, 2] + "  " + tab[6, 3] + "  " + tab[6, 4] + "  " + tab[6, 5] + "  " + tab[6, 6] + "  " + tab[6, 7] + "  " + tab[6, 8] + "  " + tab[6, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 8  " + tab[7, 0] + "  " + tab[7, 1] + "  " + tab[7, 2] + "  " + tab[7, 3] + "  " + tab[7, 4] + "  " + tab[7, 5] + "  " + tab[7, 6] + "  " + tab[7, 7] + "  " + tab[7, 8] + "  " + tab[7, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte(" 9  " + tab[8, 0] + "  " + tab[8, 1] + "  " + tab[8, 2] + "  " + tab[8, 3] + "  " + tab[8, 4] + "  " + tab[8, 5] + "  " + tab[8, 6] + "  " + tab[8, 7] + "  " + tab[8, 8] + "  " + tab[8, 9]);
            Position.CentrerLeTexte("");
            Position.CentrerLeTexte("10  " + tab[9, 0] + "  " + tab[9, 1] + "  " + tab[9, 2] + "  " + tab[9, 3] + "  " + tab[9, 4] + "  " + tab[9, 5] + "  " + tab[9, 6] + "  " + tab[9, 7] + "  " + tab[9, 8] + "  " + tab[9, 9]);


        }

        public void DisplayGameFinal ( int[,] TabPlayer, int[,] TabColor)
        {
            Console.Clear();

            string[] TabLettres = new string[] {"A", "B","C","D","E","F","G","H","I","J"};

            for (int i = 0; i < 9; i++)
            {
                string Line = " ";
                
                Position.PasserLignes(2);
                

                for (int j = 0; j <9; j++)
                {


                    //Console.Write("  " + TabPlayer[i, j] + "  ");




                    Line += String.Format( "  " + TabPlayer[i, j] + "  ");

                    //Console.Write(" " + TabPlayer[i, j] + " ");
                    //if((i+1) * (j+1) % 10 == 0)
                    //{
                    //    Console.WriteLine();
                    //}
                }



                Position.CentrerLeTexte(TabLettres[i] + "  " + Line);
                //Position.PasserLignes(2);

            }
        }


        public string DisplayTextChange (int ship)
        {
            if (ship == 0)
            {
                return " est coulé!";
            }
            else if (ship == 1)
            {
                return " a encore " + ship + " case à trouver";
            }
            else
            {
                return " a encore " + ship + " cases à trouver";
            }
        }
    }
}
