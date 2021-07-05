using System;

namespace Bomb
{
    class Program
    {
        static string previouslyPressed;
        static string userInput;
        static void Main(string[] args)
        {
            Console.WriteLine
                ("Disarm the bomb! You need to cut the wires in order to disarm the bomb\nWires: \nWhite [W], Black [B], Red [R], Green[G], Orange[O], Purple[P]");

            previouslyPressed = Console.ReadLine().ToUpper();

            int wiresToCut = 5;
            int wiresCut = 1;
            bool exploded = false;
            while (wiresCut < wiresToCut && exploded == false)
            {
                Console.WriteLine("The bomb did not explode yet. Cut another wire.");
                exploded = !NextToCut();
                previouslyPressed = userInput;
                wiresCut++;
            }
            if(exploded == true)
                Console.WriteLine("you did the poopoo");
            else
                Console.WriteLine("You do it");
            
        }

        static bool NextToCut()
        {
            userInput = Console.ReadLine().ToUpper();
            switch (previouslyPressed)
            {
                case "W":
                    return CutWhite();
                case "R":
                    return CutRed();
                case "B":
                    return CutBlack();
                case "O":
                    return CutOrange();
                case "G":
                    return CutGreen();
                case "P":
                    return CutPurple();
                default:
                    Console.WriteLine("Not a valid wire");
                    return false;
            }

        }
        static bool CutWhite() //can't cut a white or black wire next
        {
            if (!(userInput == "W" || userInput == "B"))
                return true;
            else
                return false;
        }
        static bool CutRed() //has to cut a green wire next
        {
            if (userInput == "G")
                return true;
            else
                return false;
        }

        static bool CutBlack()//can't cut white, green or orange next
        {
            if (!(userInput == "W" || userInput == "G" || userInput == "O"))
                return true;
            else
                return false;
        }

        static bool CutOrange()//has to cut red or black next
        {
            if (userInput == "R" || userInput == "B")
                return true;
            else
                return false;
        }
        static bool CutGreen() //has to cut orange or white
        {
            if (userInput == "O" || userInput == "W")
                return true;
            else
                return false;
        }

        static bool CutPurple() //can't cut purple, green, orange or white
        {
            if (!(userInput == "P" || userInput == "G" || userInput == "O" || userInput == "W"))
                return true;
            else
                return false;
        }
    }
}
