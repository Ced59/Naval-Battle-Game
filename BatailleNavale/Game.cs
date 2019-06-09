using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale
{
    class Game
    {
        Sounds Sound = new Sounds();

        public string[,] GameTestMatch ( string[,] TabDisplay, int[,] TabAlea, int Number, int Letter, int[,] TabPortavion, 
            int[,] TabCroiseur, int[,] TabContreTorpilleur, int[,] TabSousMarin, int[,] TabTorpilleur)
        {
            PositionText positionText = new PositionText();


            if (TabAlea[Number, Letter] == 1)
            {
                TabDisplay[Number, Letter] = "X";

                if (TabPortavion[Number, Letter] == 1)
                {
                    TabPortavion[Number, Letter] = 2;

                    if (TestCoule(TabPortavion))
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Porte-Avion coulé!");
                        Sound.Victory();
                        Console.ReadKey(true);
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Porte-Avion touché!");
                        Console.ReadKey(true);
                        
                    }

                }

                else if (TabCroiseur[Number, Letter] == 1)
                {
                    TabCroiseur[Number, Letter] = 2;

                    if (TestCoule(TabCroiseur))
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Croiseur coulé!");
                        Sound.Victory();
                        Console.ReadKey(true);
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Croiseur touché!");
                        Console.ReadKey(true);
                        
                    }
                }

                else if (TabContreTorpilleur[Number, Letter] == 1)
                {
                    TabContreTorpilleur[Number, Letter] = 2;

                    if (TestCoule(TabContreTorpilleur))
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Contre Torpilleur coulé!");
                        Sound.Victory();
                        Console.ReadKey(true);
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Contre Torpilleur touché!");
                        Console.ReadKey(true);
                        
                    }
                }

                else if (TabSousMarin[Number, Letter] == 1)
                {
                    TabSousMarin[Number, Letter] = 2;

                    if (TestCoule(TabSousMarin))
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Sous Marin coulé!");
                        Sound.Victory();
                        Console.ReadKey(true);
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Sous Marin touché!");
                        Console.ReadKey(true);
                        
                    }
                }

                else if (TabTorpilleur[Number, Letter] == 1)
                {
                    TabTorpilleur[Number, Letter] = 2;

                    if (TestCoule(TabTorpilleur))
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Torpilleur coulé!");
                        Sound.Victory();
                        Console.ReadKey(true);
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        positionText.CentrerLeTexte("Torpilleur touché!");                       
                        Console.ReadKey(true);
                        
                    }
                }

        

                return TabDisplay;


            }
            else
            {
                TabDisplay[Number, Letter] = "O";
                Console.WriteLine();
                positionText.CentrerLeTexte("Dans l'eau!!!");
                Sound.Error();
                Console.ReadKey(true);

                return TabDisplay;
            }

        }

        public bool GameTestEnd ( int[,] TabPortavion, int[,] TabCroiseur, int[,] TabContreTorpilleur, int[,] TabSousMarin, 
            int[,] TabTorpilleur )

        {
            if (TestCoule(TabPortavion) && TestCoule(TabCroiseur) && TestCoule(TabContreTorpilleur) && 
                TestCoule(TabSousMarin) && TestCoule(TabTorpilleur))

            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool TestCoule ( int[,] ship )
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (ship[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int CountRestShip(int[,] Ship)
        {
            int Rest = 0;

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (Ship[i,j] == 1)
                    {
                        Rest = Rest + 1;
                    }
                }
            }

            return Rest;
        }
    }
}
