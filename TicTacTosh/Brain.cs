using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacTosh
{
    public class Brain
    {
        public static void Main(string[] args)
        {
            DisplayLogo();
            do
            {
                Board = ClearBoardValues();
                AskIfFirstTimePlaying();
                DecideWhoGoesFirst();
                do
                {
                    if (ComputerGoesFirst)
                    {
                        Console.Write("Computers's turn.\n");
                        ComputerMakeMove();
                        PrintBoard();
                        AssessVictoryCondition();
                        Console.Write("Your turn.\n\n");

                        do
                        {
                            GetUsersMove();
                            AssertSpaceIsFree();
                        } while (!NoSpaces && !PositionAvaliable);

                        UserMakesMove();
                        AssessVictoryCondition();
                        PrintBoard();
                    }
                    else
                    {
                        Console.Write("Your turn.\n\n");
                        GetUsersMove();
                        AssertSpaceIsFree();
                        UserMakesMove();
                        AssessVictoryCondition();
                        PrintBoard();
                        Console.Write("Computer's turn.\n");
                        ComputerMakeMove();
                        AssessVictoryCondition();
                        PrintBoard();
                    }

                } while (!Victory && !Draw);

                if (Victor == "Computer")
                {
                    Console.Write($"The Computer has won - Better luck next time!\n\n");
                }
                else
                {
                    Console.Write($"You have won - Congratulations!\n\n");
                }
                Console.Write("Would you like to play again? (y/n)");
                string decision = Console.ReadLine().ToLower();

                if (decision == "y")
                {
                    Repeat = true;
                    Console.Write("\nRestarting...\n");
                }
                else
                {
                    Repeat = false;
                    Console.Write("\nGoodbye!\n");
                }
            } while (Repeat);
        }

        public static List<KeyValuePair<string, string>> Board { get; set; }

        public static Boolean ComputerGoesFirst { get; set; }

        public static KeyValuePair<string, string> Position { get; set; }

        public static Boolean Victory = false;

        public static Boolean Draw = false;

        public static String Victor { get; set; }

        public static Boolean Repeat = true;

        public static Boolean NoSpaces = false;

        public static Boolean PositionAvaliable = true;

        public static void ComputerMakeMove()
        {
            List<KeyValuePair<string, string>> board = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> updatedPos = new KeyValuePair<string, string>();

            List<KeyValuePair<string, string>> avaliableSpaces = GetAvaliableSpaces();

            Position = ChooseRandomPosition(avaliableSpaces);

            foreach (var position in Board)
            {
                if (position.Key == Position.Key)
                {
                    updatedPos = new KeyValuePair<string, string>(Position.Key, "X");
                    board.Add(updatedPos);
                }
                else
                {
                    board.Add(position);
                }
            }

            Board = board;

            Position = new KeyValuePair<string, string>();
        }

        public static List<KeyValuePair<string, string>> GetAvaliableSpaces()
        {
            List<KeyValuePair<string, string>> spacesAvaliable = new List<KeyValuePair<string, string>>();

            foreach (var key in Board)
            {
                if (key.Value == " ")
                {
                    spacesAvaliable.Add(key);
                }
            }

            return spacesAvaliable;
        }

        public static KeyValuePair<string, string> ChooseRandomPosition(List<KeyValuePair<string, string>> spacesAvaliable)
        {
            Random rnd = new Random();

            KeyValuePair<string, string> randomPos = new KeyValuePair<string, string>();

            var randomNum = rnd.Next(spacesAvaliable.Count() - 1);
            randomPos = new KeyValuePair<string, string>(spacesAvaliable[randomNum].Key, spacesAvaliable[randomNum].Value);

            return randomPos;
        }

        public static List<KeyValuePair<string, string>> ClearBoardValues()
        {
            Board = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("LT", " "),
                new KeyValuePair<string, string>("CT", " "),
                new KeyValuePair<string, string>("RT", " "),
                new KeyValuePair<string, string>("LM", " "),
                new KeyValuePair<string, string>("CM", " "),
                new KeyValuePair<string, string>("RM", " "),
                new KeyValuePair<string, string>("LB", " "),
                new KeyValuePair<string, string>("CB", " "),
                new KeyValuePair<string, string>("RB", " ")
            };

            return Board;
        }

        public static void DecideWhoGoesFirst()
        {
            Console.Write("Would you like to go first? (y/n)");
            string decision = Console.ReadLine().ToLower();

            if (decision == "y")
            {
                ComputerGoesFirst = false;
                Console.Write("\nYou will go first.\n");
            }
            else
            {
                Console.Write("\nThe Computer will go first\n");
                ComputerGoesFirst = true;
            }
        }

        public static void PrintBoard()
        {
            Console.Write($"\n\t{Board[0].Value}|{Board[1].Value}|{Board[2].Value}\n");
            Console.Write($"\t{Board[3].Value}|{Board[4].Value}|{Board[5].Value}\n");
            Console.Write($"\t{Board[6].Value}|{Board[7].Value}|{Board[8].Value}\n\n");
        }

        public static void AskIfFirstTimePlaying()
        {
            string input = "";
            Console.Write("\nIs this your first time playing? (y/n)");
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "y":
                    DisplayHelp();
                    break;
                default:
                    break;
            }
        }

        public static void DisplayHelp()
        {
            Console.Write("\n*************************************************************************************");
            Console.Write("\n*\t\t\t    Welcome to the help section!\t\t\t    *");
            Console.Write("\n*************************************************************************************\n");
            Console.Write("*  Each section of the board can be selected by a value as shown in the table below *\n");
            Console.Write("*  \t\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*  T = Top\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*  M = Middle \t\tLT | CT | RT\t __\t O | X | O\t\t\t    *\n");
            Console.Write("*  B = Bottom \t\tLM | CM | RM\t __\t X | O | X\t\t\t    *\n");
            Console.Write("*  L = Left \t\tLB | CB | RB\t  \t O | X | O\t\t\t    *\n");
            Console.Write("*  C = Center\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*  R = Right\t\t\t\t\t\t\t\t\t    *\n");
            Console.Write("*************************************************************************************\n");
        }

        public static void GetUsersMove()
        {
            Console.Write("Where would you like to go? ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "LT":
                    Position = new KeyValuePair<string, string>("LT", "O");
                    break;
                case "CT":
                    Position = new KeyValuePair<string, string>("CT", "O");
                    break;
                case "RT":
                    Position = new KeyValuePair<string, string>("RT", "O");
                    break;
                case "LM":
                    Position = new KeyValuePair<string, string>("LM", "O");
                    break;
                case "CM":
                    Position = new KeyValuePair<string, string>("CM", "O");
                    break;
                case "RM":
                    Position = new KeyValuePair<string, string>("RM", "O");
                    break;
                case "LB":
                    Position = new KeyValuePair<string, string>("LB", "O");
                    break;
                case "CB":
                    Position = new KeyValuePair<string, string>("CB", "O");
                    break;
                case "RB":
                    Position = new KeyValuePair<string, string>("RB", "O");
                    break;
                default:
                    Console.Write("\nThis is not a valid move please try again.\n\n");
                    break;
            }
        }

        public static void AssertSpaceIsFree()
        {
            List<KeyValuePair<string, string>> avaliableSpaces = GetAvaliableSpaces();
            List<String> temp = new List<string>();

            if (avaliableSpaces.Count == 0)
            {
                NoSpaces = true;
                Draw = true;
                return;
            }

            foreach (var space in avaliableSpaces)
            {
                temp.Add(space.Key);
            }

            if (temp.Contains(Position.Key))
            {
                PositionAvaliable = true;
            }
            else
            { 
                if (Position.Value == "O")
                {
                    Console.Write("You can't go there, that spot is already taken.\n\n");
                }
                else
                {
                    Console.Write("Enter a recognised move to continue.\n\n");
                }
                
                PositionAvaliable = false;
                Position = new KeyValuePair<string, string>();
            }
        }

        public static void UserMakesMove()
        {
            List<KeyValuePair<string, string>> board = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> updatedPos;

            foreach (KeyValuePair<string, string> position in Board)
            {
                if (position.Key == Position.Key)
                {
                    updatedPos = new KeyValuePair<string, string>(Position.Key, Position.Value);
                    board.Add(updatedPos);
                }
                else
                {
                    board.Add(position);
                }
            }
            Board = board;

            Position = new KeyValuePair<string, string>();
        }

        public static void AssessVictoryCondition()
        {
            if (Board[0].Value + Board[1].Value + Board[2].Value == "XXX" || Board[0].Value + Board[1].Value + Board[2].Value == "OOO")
            {
                if (Board[0].Value + Board[1].Value + Board[2].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[3].Value + Board[4].Value + Board[5].Value == "XXX" || Board[3].Value + Board[4].Value + Board[5].Value == "OOO")
            {
                if (Board[3].Value + Board[4].Value + Board[5].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[6].Value + Board[7].Value + Board[8].Value == "XXX" || Board[6].Value + Board[7].Value + Board[8].Value == "OOO")
            {
                if (Board[6].Value + Board[7].Value + Board[8].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[0].Value + Board[3].Value + Board[6].Value == "XXX" || Board[0].Value + Board[3].Value + Board[6].Value == "OOO")
            {
                if (Board[0].Value + Board[3].Value + Board[6].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[1].Value + Board[4].Value + Board[7].Value == "XXX" || Board[1].Value + Board[4].Value + Board[7].Value == "OOO")
            {
                if (Board[1].Value + Board[4].Value + Board[7].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[2].Value + Board[5].Value + Board[8].Value == "XXX" || Board[2].Value + Board[5].Value + Board[8].Value == "OOO")
            {
                if (Board[2].Value + Board[5].Value + Board[8].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[0].Value + Board[4].Value + Board[8].Value == "XXX" || Board[0].Value + Board[4].Value + Board[8].Value == "OOO")
            {
                if (Board[0].Value + Board[4].Value + Board[8].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (Board[6].Value + Board[4].Value + Board[2].Value == "XXX" || Board[6].Value + Board[4].Value + Board[2].Value == "OOO")
            {
                if (Board[6].Value + Board[4].Value + Board[2].Value == "XXX")
                {
                    Victor = "Computer";
                }
                else
                {
                    Victor = "User";
                }

                Victory = true;
            }
            else if (GetAvaliableSpaces().Count == 0)
            {
                Draw = true;
            }
            else
            {
                Victory = false;
            }
        }

        public static void DisplayLogo()
        {
            Console.Write(@"  _______       _______         _______        _     
 |__   __|     |__   __|       |__   __|      | |    TM
    | |  _  ___   | | __ _  ___   | | ___  ___| |___ 
    | | (_)/ __|  | |/ _` |/ __|  | |/ _ \/ __| '_  \ 
    | | | | (__   | | (_| | (__   | | (_) \__ \ | | |
    |_| |_|\___|  |_|\__,_|\___|  |_|\___/|___/_| |_|");
            Console.Write("\n------------ Created by Kyle Smith - 2018 © ------------\n");
        }
    }
}
