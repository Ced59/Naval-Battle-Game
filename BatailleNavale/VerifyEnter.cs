using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavale
{
    class VerifyEnter
    {
        PositionText PositionText = new PositionText();
        Sounds Sound = new Sounds();

        public bool Verify_Letter ( string Letter, out int Letter_Int)
        {

            Letter_Int = -1;

            switch (Letter)
            {
                case "A":
                    Letter_Int = 0;
                    return true;

                case "B":
                    Letter_Int = 1;
                    return true;

                case "C":
                    Letter_Int = 2;
                    return true;

                case "D":
                    Letter_Int = 3;
                    return true;

                case "E":
                    Letter_Int = 4;
                    return true;

                case "F":
                    Letter_Int = 5;
                    return true;

                case "G":
                    Letter_Int = 6;
                    return true;

                case "H":
                    Letter_Int = 7;
                    return true;

                case "I":
                    Letter_Int = 8;
                    return true;

                case "J":
                    Letter_Int = 9;
                    return true;

                default:
                    Letter_Int = -1;
                    PositionText.PasserLignes(2);
                    Console.WriteLine("Veuillez entrer une lettre majuscule entre A et J!!");
                    PositionText.PasserLignes(2);
                    Sound.Error();
                    return false;
                   

            }

            
        }


        public bool Verify_Number ( string saisie )
        {
            

            int test = 0;
            bool saisie_is_valid = false;

            if (int.TryParse(saisie, out test))
            {
                saisie_is_valid = true;
                return saisie_is_valid;
            }
            else
            {
                saisie_is_valid = false;
                Console.WriteLine("Veuillez entrer un nombre valide!");
                Sound.Error();
                return saisie_is_valid;
            }


        }

        public bool Verify_Number_between(int number)
        {
            if ((number >= 1) && (number <= 10))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Vous devez entrer un nombre entre 1 et 10!!");
                Sound.Error();
                return false;

            }
        }

    }
}
