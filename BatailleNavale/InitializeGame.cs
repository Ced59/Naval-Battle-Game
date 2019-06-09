using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale
{
    class InitializeGame
    {

        public string[,] InitTabDisplay ( string[,] Tab )
        {
            int i;
            int j;
            for (i = 0; i <= 9; i++)
            {
                for (j = 0; j <= 9; j++)
                {
                    Tab[i, j] = ".";
                }

            }

            return Tab;

        }

        public int[,] InitTabAlea ( int[,] Tab, out int[,] TabPortavion, out int[,] TabCroiseur, out int[,] TabContreTorpilleur,
            out int[,] TabSousMarin, out int[,] TabTorpilleur )
        {

            Tab = new int[10, 10];
            TabPortavion = new int[10, 10];

            int[ , ] TabVide = new int[10,10];

            int[ , ] TabPortavion_Verif = new int[10,10];
            int[ , ] TabCroiseur_Verif = new int[10,10];
            int[ , ] TabContreTorpilleur_Verif = new int[10,10];
            int[ , ] TabSousMarin_Verif = new int [10,10];
            int[ , ] TabTorpilleur_Verif = new int [10,10];
            


            int TaillePortavion = 5;
            int TailleCroiseur = 4;
            int TailleContreTorpilleur = 3;
            int TailleSousMarin = 3;
            int TailleTorpilleur = 2;

            TabPortavion = InitShip(TabPortavion, TaillePortavion); // On initialise la position du porte avion
            Tab = TabPortavion; // On rajoute la position du porte avion dans la tab générale


            bool VerifPosition = false; // Pour Porte Avion

            while (!VerifPosition)
            {
                TabPortavion_Verif = InitTabIfNoGoodVerif(TabPortavion_Verif);

                TabPortavion_Verif = InitShip(TabPortavion_Verif, TaillePortavion);

                VerifPosition = VerifChevauchement(Tab, TabPortavion_Verif);
            }

            Tab = AddPositionShip(Tab, TabPortavion_Verif);
            TabPortavion = TabPortavion_Verif;



            VerifPosition = false; // Pour Croiseur

            while (!VerifPosition)
            {
                TabCroiseur_Verif = InitTabIfNoGoodVerif(TabCroiseur_Verif); // réinitialisation de tab croiseur à chaque tour de boucle

                TabCroiseur_Verif = InitShip(TabCroiseur_Verif, TailleCroiseur); // Initialisation Position Croiseur

                VerifPosition = VerifChevauchement(Tab, TabCroiseur_Verif); // Verification Chevauchement Croiseur
            }

            Tab = AddPositionShip(Tab, TabCroiseur_Verif); // Ajout de la position du croiseur à la tab generale
            TabCroiseur = TabCroiseur_Verif; //Envoi de la bonne valeur de Tab Croiseur pour exportation dans le Main


            VerifPosition = false; // Pour Contre Torpilleur

            while (!VerifPosition)
            {
                TabContreTorpilleur_Verif = InitTabIfNoGoodVerif(TabContreTorpilleur_Verif);

                TabContreTorpilleur_Verif = InitShip(TabContreTorpilleur_Verif, TailleContreTorpilleur); 

                VerifPosition = VerifChevauchement(Tab, TabContreTorpilleur_Verif); 
            }

            Tab = AddPositionShip(Tab, TabContreTorpilleur_Verif);
            TabContreTorpilleur = TabContreTorpilleur_Verif;


            VerifPosition = false; // Pour Sous Marin

            while (!VerifPosition)
            {
                TabSousMarin_Verif = InitTabIfNoGoodVerif(TabSousMarin_Verif);

                TabSousMarin_Verif = InitShip(TabSousMarin_Verif, TailleSousMarin);

                VerifPosition = VerifChevauchement(Tab, TabSousMarin_Verif);
            }

            Tab = AddPositionShip(Tab, TabSousMarin_Verif);
            TabSousMarin = TabSousMarin_Verif;

            VerifPosition = false;

            while (!VerifPosition) // Pour Torpilleur
            {
                TabTorpilleur_Verif = InitTabIfNoGoodVerif(TabTorpilleur_Verif);

                TabTorpilleur_Verif = InitShip(TabTorpilleur_Verif, TailleTorpilleur);

                VerifPosition = VerifChevauchement(Tab, TabTorpilleur_Verif);
            }

            Tab = AddPositionShip(Tab, TabTorpilleur_Verif);
            TabTorpilleur = TabTorpilleur_Verif;



            return Tab;
        }


        public int[,] VerifTab (int[,] TabAlea, int[,] TabPortavion, int[,] TabCroiseur, int[,] TabContreTorpilleur,
            int[,] TabSousMarin, int[,] TabTorpilleur )
        {
            int[,] Tab = new int[10,10];

            Tab = AddPositionShip(Tab, TabPortavion);
            Tab = AddPositionShip(Tab, TabCroiseur);
            Tab = AddPositionShip(Tab, TabContreTorpilleur);
            Tab = AddPositionShip(Tab, TabSousMarin);
            Tab = AddPositionShip(Tab, TabTorpilleur);
            return Tab;
        }


        private int[,] InitShip ( int[,] TabShip, int taille ) // Définition des positions des bateaux
        {
            int RandomAlign = -1;
            int RandomInit = -1;
            Random rnd = new Random();

            RandomAlign = rnd.Next(0, 2); // Définition aléatoire de l'alignement du bateau. (0 = vertical ; 1 = horizontal)
            RandomInit = rnd.Next(0, ( 10 - taille )); // Définition aléatoire de la position originelle du bateau sur la grille

            if (RandomAlign == 0)
            {
                int RandomInitColonn = rnd.Next(0,10); // Définition aléatoire de la position colonne du bateau 

                for (int i = 0; i < taille; i++)
                {
                    TabShip[RandomInit, RandomInitColonn] = 1;
                    RandomInit = RandomInit + 1;
                }

                return TabShip;
            }
            else
            {
                int RandomInitLine = rnd.Next(0,10); // Définition aléatoire de la position ligne du bateau

                for (int i = 0; i < taille; i++)
                {
                    TabShip[RandomInitLine, RandomInit] = 1;
                    RandomInit = RandomInit + 1;
                }

                return TabShip;
            }



        }

        private bool VerifChevauchement (int[ , ] Tab, int[ , ] TabVerif) // Verification chevauchement entre nouveau bateau généré et anciens
        {
            bool Verif = false;

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (( Tab[i, j] == 1 ) && ( TabVerif[i, j] == 1 ))
                    {
                        Verif = false;
                        return Verif;
                    }

                }
            }

            Verif = true;
            return Verif;
        }


        private int[ , ] AddPositionShip(int[ , ] Tab, int[ , ] TabAjout) // Ajout du nouveau bateau a la tab generale
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (TabAjout[i , j] ==1)
                    {
                        Tab[i, j] = TabAjout[i, j];
                    }

                }
            }

            return Tab;
        }


        private int[,] InitTabIfNoGoodVerif(int[,] Tab)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    Tab[i, j] = 0;
                }
            }

            return Tab;
        }
    }
}




