using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacTosh
{
    public class Brain
    {
        public static void Main(string[] args)
        {
            Board = ClearBoardValues();
            //Decide who goes first 
            //DecideWhoGoesFirst();
            DisplayHelp();
            PrintBoard();
            GetUsersMove();
            UserMakesMove();
            AIMakeMove();
            PrintBoard();

            Console.ReadLine();
        }

        /* Position X, Position Y, State
        * 
        * X can be 1 2 3
        * Y can be 1 2 3
        * 
        * States are:
        * 0 = empty
        * 1 = X - for AI
        * 2 = O - for Player 1
        */

        /* display the grid like this
        * 
        *  T O|X|O
        *  M X|O|X
        *  B O|X|O
        *    L C R
        *       
        *  T LT|CT|RT
        *  M LM|CM|RM
        *  B LB|CB|RB
        *    L  C  R
        *    
        *  Help:
        *  L = Left
        *  C = Center
        *  R = Right
        *  T = Top
        *  M = Middle
        *  B = Bottom
        */

        public static List<List<int>> corners = new List<List<int>>()
        {
            new List<int>() { 1, 1, 0 },
            new List<int>() { 1, 3, 0 },
            new List<int>() { 3, 1, 0 },
            new List<int>() { 3, 3, 0 }
        };

        public static List<List<int>> midEdges = new List<List<int>>()
        {
            new List<int>() { 1, 2, 0 },
            new List<int>() { 2, 1, 0 },
            new List<int>() { 2, 3, 0 },
            new List<int>() { 3, 2, 0 }
        };

        public static List<List<int>> center = new List<List<int>>()
        {
            new List<int>() { 2, 2, 0 }
        };

        public static Boolean AIGoesFirst { get; set; }

        public static List<int> Position { get; set; }

        public static List<List<int>> Board { get; set; }

        public static List<List<int>> Corners { get => corners; set => corners = value; }

        public static List<List<int>> MidEdges { get => midEdges; set => midEdges = value; }

        public static List<List<int>> Center { get => center; set => center = value; }

        public static void AIMakeMove()
        {
            List<List<int>> board = new List<List<int>>();
            List<List<int>> avaliableSpaces = GetAvaliableSpaces();
            Position = ChooseRandomPosition(avaliableSpaces);

            Position[2] = 1;

            foreach (var pos in Board)
            {
                if (pos.ElementAt(0) == Position[0] && pos.ElementAt(1) == Position[1])
                {
                    pos.Insert(2, Position[2]);
                }

                board.Add(pos);

                Board = board;
            }
        }

        public static List<List<int>> GetAvaliableSpaces()
        {
            List<List<int>> spacesAvaliable = new List<List<int>>();

            foreach (var pos in Board)
            {
                if (pos.ElementAt(2) == 0)
                {
                    spacesAvaliable.Add(pos);
                }
            }

            return spacesAvaliable;
        }

        public static List<int> ChooseRandomPosition(List<List<int>> spacesAvaliable)
        {
            Random rnd = new Random();

            var randomNum = rnd.Next(spacesAvaliable.Count() - 1);
            var chosenPosition = spacesAvaliable.ElementAt(randomNum);

            return chosenPosition;
        }

        public static List<List<int>> ClearBoardValues()
        {
            // set values to {1,1,0} {1,2,0} {1,3,0} {2,1,0} {2,2,0} {2,3,0} {3,1,0} {3,2,0} {3,3,0}
            Board = new List<List<int>>()
            {
                new List<int>() { 1, 1, 0 },
                new List<int>() { 1, 2, 0 },
                new List<int>() { 1, 3, 0 },
                new List<int>() { 2, 1, 0 },
                new List<int>() { 2, 2, 0 },
                new List<int>() { 2, 3, 0 },
                new List<int>() { 3, 1, 0 },
                new List<int>() { 3, 2, 0 },
                new List<int>() { 3, 3, 0 }
            };

            Board =
            {
                { { } }
            };

            return Board;
        }

        public static void DecideWhoGoesFirst()
        {
            Console.Write("Would you like to go first? (y/n)");
            string decision = Console.ReadLine();

            if (decision == "y" || decision == "Y")
            {
                AIGoesFirst = false;
                Console.Write("You will go first.");
            }
            else
            {
                Console.Write("The AI will go first");
                AIGoesFirst = true;
            }
        }

        public static void PrintBoard()
        {
            int count = 0;

            foreach (var pos in Board)
            {
                if (count == 0)
                {
                    Console.Write(" T ");
                }
                else if (count == 3)
                {
                    Console.Write(" M ");
                }
                else if (count == 6)
                {
                    Console.Write(" B ");
                }

                if (pos[2] == 0)
                {
                    Console.Write(" ");
                    count++;
                }
                else if (pos[2] == 1)
                {
                    Console.Write("X");
                    count++;
                }
                else if (pos[2] == 2)
                {
                    Console.Write("O");
                    count++;
                }

                if (count == 3 || count == 6)
                {
                    Console.Write("\n");
                }
                else if (count == 9)
                {
                    Console.Write("\n   L C R\n\n");
                }
                else
                {
                    Console.Write("|");
                }
            }
        }

        public static void DisplayHelp()
        {
            Console.Write("\n*************************************************************************************");
            Console.Write("\n*\t\t\t    Welcome to the help section!\t\t\t    *");
            Console.Write("\n*************************************************************************************\n");
            Console.Write("*  Each section of the board can be selected by a value as shown in the table below *\n");
            Console.Write("*  T = Top\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*  M = Mid \t\tLT | CT | RT\t __\t O | X | O\t\t\t    *\n"); 
            Console.Write("*  B = Bot \t\tLM | CM | RM\t __\t X | O | X\t\t\t    *\n"); 
            Console.Write("*  L = Left \t\tLB | CB | RB\t  \t O | X | O\t\t\t    *\n"); 
            Console.Write("*  C = Center\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*  R = Right\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*************************************************************************************\n\n");
        }

        /*
         * T LT|CT|RT
        *  M LM|CM|RM
        *  B LB|CB|RB
        *    L  C  R
        *    
        *  Help:
        *  L = Left
        *  C = Center
        *  R = Right
        *  T = Top
        *  M = Middle
        *  B = Bottom
         */

        public static void GetUsersMove()
        {
            Console.Write("Where would you like to go? ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "LT":
                    Position[0] = 1;
                    Position[1] = 3;
                    Position[2] = 2;
                    break;
                case "CT":
                    Position[0] = 2;
                    Position[1] = 3;
                    Position[2] = 2;
                    break;
                case "RT":
                    Position[0] = 3;
                    Position[1] = 3;
                    Position[2] = 2;
                    break;
                case "LM":
                    Position[0] = 1;
                    Position[1] = 2;
                    Position[2] = 2;
                    break;
                case "CM":
                    Position[0] = 2;
                    Position[1] = 2;
                    Position[2] = 2;
                    break;
                case "RM":
                    Position[0] = 3;
                    Position[1] = 2;
                    Position[2] = 2;
                    break;
                case "LB":
                    Position[0] = 1;
                    Position[1] = 1;
                    Position[2] = 2;
                    break;
                case "CB":
                    Position[0] = 2;
                    Position[1] = 1;
                    Position[2] = 2;
                    break;
                case "RB":
                    Position[0] = 3;
                    Position[1] = 1;
                    Position[2] = 2;
                    break;
                default:
                    Console.Write("This is not a valid move please try again.");
                    break;
            }
        }

        public static void UserMakesMove()
        {
            List<List<int>> board = new List<List<int>>();
            List<List<int>> avaliableSpaces = GetAvaliableSpaces();

            foreach (var pos in Board)
            {
                if (pos.ElementAt(0) == Position[0] && pos.ElementAt(1) == Position[1])
                {
                    pos.Insert(2, Position[2]);
                }

                board.Add(pos);

                Board = board;
            }
        }
    }
}
