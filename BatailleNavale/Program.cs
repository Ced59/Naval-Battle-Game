using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BatailleNavale
{
    class Program
    {
        static void Main ( string[] args )
        {
            
            Console.SetWindowSize(150, 44);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Sounds Sound = new Sounds();
            PositionText PositionText = new PositionText();
            VerifyEnter VerifEnter = new VerifyEnter();
            DisplayGame Display = new DisplayGame();
            InitializeGame Init = new InitializeGame();
            Game Game_Corps = new Game();

            string pseudo = Display.IntroGame();

            int[ , ] TabAlea = new int[10,10]; // Tableau de jeu à trouver
            int[ , ] TabPlayer = new int[10,10]; // Tableau du jeu du joueur
            string[ , ] TabDisplay = new string[10,10];
            int[ , ] TabPortavion = new int[10,10];
            int[ , ] TabCroiseur = new int[10, 10];
            int[ , ] TabContreTorpilleur = new int[10, 10];
            int[ , ] TabSousMarin = new int[10, 10];
            int[ , ] TabTorpilleur = new int[10, 10];
            int[ , ] TabColor = new int [10 , 10];

            string Letter_Player = "z"; // Lettre entrée par le joueur
            string Number_Player = "z"; // Chiffre entré par le joueur
            int Letter_Int = -1; // Référence de la lettre entrée par le joueur
            int Number_Player_Int = -1;

            bool over = false; // Vrai si game over

            TabDisplay = Init.InitTabDisplay(TabDisplay); // Initialisation du tableau de jeu

            TabAlea = Init.InitTabAlea(TabAlea, out TabPortavion, out TabCroiseur, out TabContreTorpilleur, out TabSousMarin, out TabTorpilleur); // Initialisation du tableau aléatoire de l'adversaire

            TabAlea = Init.VerifTab(TabAlea, TabPortavion, TabCroiseur, TabContreTorpilleur, TabSousMarin, TabTorpilleur);

            int tour = 0;

            while (!over)
            {
                int RestPortavion = Game_Corps.CountRestShip(TabPortavion);
                int RestCroiseur = Game_Corps.CountRestShip(TabCroiseur);
                int RestContreTorpilleur = Game_Corps.CountRestShip(TabContreTorpilleur);
                int RestSousMarin = Game_Corps.CountRestShip(TabSousMarin);
                int RestTorpilleur = Game_Corps.CountRestShip(TabTorpilleur);




                tour = tour + 1;

                bool Test_Entry = false;
                bool Test_Egality = false;

                while (!Test_Egality)
                {

                    while (!Test_Entry)
                    {


                        Display.DisplayGameArea(TabDisplay); // Affichage du tableau de jeu

                        Console.WriteLine("");

                        Console.WriteLine(" Le Porte Avion" + Display.DisplayTextChange(RestPortavion));
                        Console.WriteLine(" Le Croiseur" + Display.DisplayTextChange(RestCroiseur));
                        Console.WriteLine(" Le Contre Torpilleur" + Display.DisplayTextChange(RestContreTorpilleur));
                        Console.WriteLine(" Le Sous Marin" + Display.DisplayTextChange(RestSousMarin));
                        Console.WriteLine(" Le Torpilleur" + Display.DisplayTextChange(RestTorpilleur));

                        Console.WriteLine("");
                        if (tour >= 2)
                        {
                            Console.WriteLine("Dernière case jouée: [" + Letter_Player + " , " + Number_Player + "]");
                        }
                        PositionText.PasserLignes(2);
                        Console.WriteLine("Tour n°: " + tour);
                        Console.Write("Veuillez entrer la lettre que vous voulez jouer:  ");
                        Letter_Player = Console.ReadLine();
                        Letter_Player = Letter_Player.ToUpper();

                        Test_Entry = VerifEnter.Verify_Letter(Letter_Player, out Letter_Int);



                    }


                    Test_Entry = false;
                    bool Test_Entry_Between = false;

                    while (!Test_Entry_Between)
                    {

                        while (!Test_Entry)
                        {

                            Console.Write("Veuillez entrer le chiffre que vous voulez jouer:  ");
                            Number_Player = Console.ReadLine();

                            Test_Entry = VerifEnter.Verify_Number(Number_Player);

                        }

                        Number_Player_Int = Convert.ToInt32(Number_Player);
                        Test_Entry = false;



                        Test_Entry_Between = VerifEnter.Verify_Number_between(Number_Player_Int);



                    }


                    Number_Player_Int = Number_Player_Int - 1;

                    if (TabPlayer[Letter_Int,Number_Player_Int] == 1)
                    {
                        Test_Egality = false;
                        Console.WriteLine("Vous avez déjà joué ces coordonnées!");
                        
                        Console.ReadKey(true);
                    }
                    else
                    {
                        TabPlayer[Letter_Int, Number_Player_Int] = 1;
                        Test_Egality = true;
                    }


                }


                Console.Write("Vous avez joué [" + Letter_Player + " , " + Number_Player + "]");


                TabDisplay = Game_Corps.GameTestMatch(TabDisplay, TabAlea, Number_Player_Int, Letter_Int, TabPortavion, TabCroiseur, TabContreTorpilleur, TabSousMarin, TabTorpilleur);
                Console.ReadKey();
                Console.Clear();



                Display.DisplayGameArea(TabDisplay);







                over = Game_Corps.GameTestEnd(TabPortavion, TabCroiseur, TabContreTorpilleur, TabSousMarin, TabTorpilleur);



            }

            PositionText.PasserLignes(4);
            PositionText.CentrerLeTexte("Bravo " + pseudo + "! Vous avez coulé tous les bateaux ennemis!");
            PositionText.CentrerLeTexte("Vous avez réussi en " + tour + " coups!");
            Sound.Victory();

            string oldText = "";
            if (File.Exists("monFichier.txt"))
            {
                StreamReader reader = new StreamReader("monFichier.txt");
                oldText = reader.ReadToEnd();
                reader.Close();
            }

            StreamWriter file = new StreamWriter("monFichier.txt");
            file.Write(oldText);
            file.WriteLine($"{pseudo} : Gagné en {tour} coups le {DateTime.Now}");
            file.Close();
            Console.ReadKey(true);




            //Display.DisplayGameAreaInt(TabAlea); // Tests d'affichage

            //Console.ReadKey(true);

            //Display.DisplayGameAreaInt(TabPortavion);

            //Console.ReadKey(true);

            //Display.DisplayGameAreaInt(TabCroiseur);

            //Console.ReadKey(true);

            //Display.DisplayGameAreaInt(TabContreTorpilleur);

            //Console.ReadKey(true);

            //Display.DisplayGameAreaInt(TabSousMarin);

            //Console.ReadKey(true);

            //Display.DisplayGameAreaInt(TabTorpilleur);

            //Console.ReadKey(true);

            //Display.DisplayGameFinal(TabAlea, TabColor);

            //Console.ReadKey(true);



        }
    }
}
