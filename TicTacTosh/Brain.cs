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
            AskAndSetName();
            AskIfFirstTimePlaying();
            StartGame();
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

        public static String UserPiece { get; set; }

        public static String CompPiece { get; set; }

        public static String Name { get; set; }


        //Board = new List<KeyValuePair<string, string>>()
        //    {
        //       new KeyValuePair<string, string>("LT", " "),

        public static List<List<string>> possibleWins = new List<List<String>>
        {
            new List<String> { "LT", "CT", "RT"},
            new List<String> { "LM", "CM", "RM"},
            new List<String> { "LB", "CB", "RB"},
            new List<String> { "test", "test", "test"}
        };

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
                    updatedPos = new KeyValuePair<string, string>(Position.Key, CompPiece);
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

        public static void StartGame()
        {
            do
            {
                Board = ClearBoardValues();
                AssessComputerPossibleMoves();
                AskIfYouWantToBeXorO();
                DecideWhoGoesFirst();
                do
                {
                    if (ComputerGoesFirst)
                    {
                        Console.Write("Computers's turn.\n");
                        ComputerMakeMove();
                        PrintBoard();
                        AssessIfVictoryConditionIsMet();

                        if (Victory == true || Draw == true || Victor != null)
                        {
                            break;
                        }

                        Console.Write($"Your turn {Name}.\n\n");

                        do
                        {
                            GetUsersMove();
                            AssertSpaceIsFree();
                        } while (!NoSpaces && !PositionAvaliable);

                        if (NoSpaces)
                        {
                            break;
                        }

                        UserMakesMove();
                        PrintBoard();
                        AssessIfVictoryConditionIsMet();

                        if (Victory == true || Draw == true || Victor != null)
                        {
                            break;
                        }
                    }
                    else
                    {
                        PrintBoard();
                        Console.Write($"Your turn {Name}.\n\n");
                        GetUsersMove();
                        AssertSpaceIsFree();
                        UserMakesMove();
                        PrintBoard();
                        AssessIfVictoryConditionIsMet();

                        if (Victory == true || Draw == true || Victor != null)
                        {
                            break;
                        }
                        Console.Write("Computer's turn.\n");
                        ComputerMakeMove();
                        PrintBoard();
                        AssessIfVictoryConditionIsMet();

                        if (Victory == true || Draw == true || Victor != null)
                        {
                            break;
                        }
                    }

                } while (!Victory && !Draw);

                DisplayVictoryDrawMessage();
                AskIfYouWantToPlayAgain();

            } while (Repeat);
        }

        public static void DisplayVictoryDrawMessage()
        {
            if (Victor == "Computer")
            {
                Console.Write($"The Computer has won.. TOSH! Better luck next time {Name}!\n\n");
            }
            else if (Draw)
            {
                Console.Write($"Looks like a draw {Name}!\n\n");
            }
            else
            {
                Console.Write($"You have won - Congratulations {Name}!\n\n");
            }
        }

        public static void AskAndSetName()
        {
            Console.Write("\nWelcome! What is your name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (input == "kyle" || input == "Kyle")
            {
                string pass = "";
                string correctPass = "elyk";
                Console.Write("Enter the correct password to use this name: ");
                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);

                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (key.KeyChar == 13)
                        {
                            // do nothing
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else
                        {
                            pass += key.KeyChar;
                            Console.Write("*");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.Write("\b");
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);

                if (pass == correctPass)
                {
                    Name = input;
                    Console.Write($"\nWelcome back {Name}!");
                }
                else
                {
                    Console.Write($"\nThere can be only one!");
                    Name = "Fake Kyle";
                }
            }
            else
            {
                Name = input;
            }
        }

        public static void AskIfYouWantToPlayAgain()
        {
            Console.Write($"Would you like to play again {Name}? (y/n) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string decision = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

            if (decision == "y")
            {
                Victory = false;
                Victor = null;
                Draw = false;
                Repeat = true;
                Console.Write("\nRestarting...\n\n");
            }
            else
            {
                Repeat = false;
                Console.Write($"\nGoodbye {Name}!\n\n");
                Console.ReadLine();
            }
        }

        public static void AssessComputerPossibleMoves()
        {
            List<KeyValuePair<string, string>> boardValues = new List<KeyValuePair<string, string>>();
            string computerPiece = CompPiece;
            boardValues = Board;

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
            Console.Write($"\nWould you like to go first {Name}? (y/n) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string decision = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

            if (decision == "y")
            {
                ComputerGoesFirst = false;
                Console.Write("\nYou will go first.\n");
            }
            else
            {
                Console.Write("\nThe Computer will go first.\n");
                ComputerGoesFirst = true;
            }
        }

        public static void PrintBoard()
        {
            Console.Write("\n\t");
            for (int i = 0; i <= Board.Count - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{Board[i].Value}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (i == 0 || i == 1 || i == 3 || i == 4 || i == 6 || i == 7)
                {
                    Console.Write("|");
                }

                if(i == 2 || i == 5 || i == 8)
                {
                    Console.Write("\n\t");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");

            /*
            Console.Write($"\t{Board[6].Value}|{Board[1].Value}|{Board[2].Value}\n");
            Console.Write($"\t{Board[3].Value}|{Board[4].Value}|{Board[5].Value}\n");
            Console.Write($"\t{Board[6].Value}|{Board[7].Value}|{Board[8].Value}\n\n");
            */
        }

        public static void AskIfFirstTimePlaying()
        {
            string input = "";
            Console.Write($"\nIs this your first time playing {Name}? (y/n) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

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
            Console.Write("\n ************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\t\t\t    Welcome to the help section!\t\t\t    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n ************************************************************************************\n");
            Console.Write(" The positions on the board consist of two letters: Eg. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("LT\n\n");
            Console.ForegroundColor = ConsoleColor.White; 
            Console.Write(" The first letter indicates where along the X axis the player would like to go.\n");
            Console.Write(" The choices being: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("L");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Left");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(", ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("C");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Center");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Right");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".\n\n");
            Console.Write(" The second letter indicates where along the Y axis the player would like to go.\n");
            Console.Write(" The choices being: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("T");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Top");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(", ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("M");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Middle");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("B");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Bottom");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".\n\n");
            Console.Write(" The list of possible choices are: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("LT, LM, LB, CT, CM, CB, RT, RM, RB\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" You can also type them like this: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("TL, ML, BL, TC, MC, BC, TR, MR, BR\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" On the board they are here:\n\n");
            Console.Write(" LT ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" CT ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" RT \n");
            Console.Write(" LM ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" CM ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" RM \n");
            Console.Write(" LB ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" CB ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" RB \n");
        }

        public static void GetUsersMove()
        {
            Boolean moveTaken = false;

            do
            {
                Console.Write($"Where would you like to go? (type 'help' if unsure) ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                switch (input)
                {
                    case "lt":
                    case "tl":
                        Position = new KeyValuePair<string, string>("LT", UserPiece);
                        moveTaken = true;
                        break;
                    case "tc":
                    case "ct":
                        Position = new KeyValuePair<string, string>("CT", UserPiece);
                        moveTaken = true;
                        break;
                    case "tr":
                    case "rt":
                        Position = new KeyValuePair<string, string>("RT", UserPiece);
                        moveTaken = true;
                        break;
                    case "ml":
                    case "lm":
                        Position = new KeyValuePair<string, string>("LM", UserPiece);
                        moveTaken = true;
                        break;
                    case "mc":
                    case "cm":
                        Position = new KeyValuePair<string, string>("CM", UserPiece);
                        moveTaken = true;
                        break;
                    case "rm":
                    case "mr":
                        Position = new KeyValuePair<string, string>("RM", UserPiece);
                        moveTaken = true;
                        break;
                    case "bl":
                    case "lb":
                        Position = new KeyValuePair<string, string>("LB", UserPiece);
                        moveTaken = true;
                        break;
                    case "bc":
                    case "cb":
                        Position = new KeyValuePair<string, string>("CB", UserPiece);
                        moveTaken = true;
                        break;
                    case "br":
                    case "rb":
                        Position = new KeyValuePair<string, string>("RB", UserPiece);
                        moveTaken = true;
                        break;
                    case "help":
                        DisplayHelp();
                        PrintBoard();
                        break;
                    default:
                        Console.Write("\nThis is not a valid move please try again.\n\n");
                        break;
                }
            } while (!moveTaken);
        }

        public static void AssertSpaceIsFree()
        {
            List<KeyValuePair<string, string>> avaliableSpaces = GetAvaliableSpaces();
            List<String> temp = new List<string>();

            if (avaliableSpaces.Count == 0)
            {
                PositionAvaliable = false;
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
                if (Position.Value == UserPiece)
                {
                    Console.Write($"You can't go there {Name}, that spot is already taken!\n\n");
                }
                else
                {
                    Console.Write("Please enter a recognised move to continue.\n\n");
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

        public static void AssessIfVictoryConditionIsMet()
        {
            if (Board[0].Value + Board[1].Value + Board[2].Value == "XXX" || Board[0].Value + Board[1].Value + Board[2].Value == "OOO")
            {
                if (Board[0].Value + Board[1].Value + Board[2].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[3].Value + Board[4].Value + Board[5].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[6].Value + Board[7].Value + Board[8].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[0].Value + Board[3].Value + Board[6].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[1].Value + Board[4].Value + Board[7].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[2].Value + Board[5].Value + Board[8].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[0].Value + Board[4].Value + Board[8].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
                if (Board[6].Value + Board[4].Value + Board[2].Value == $"{CompPiece}{CompPiece}{CompPiece}")
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"  _______       _______         _______        _     
 |__   __|     |__   __|       |__   __|      | |    TM
    | |  _  ___   | | __ _  ___   | | ___  ___| |___ 
    | | (_)/ __|  | |/ _` |/ __|  | |/ _ \/ __| '_  \ 
    | | | | (__   | | (_| | (__   | | (_) \__ \ | | |
    |_| |_|\___|  |_|\__,_|\___|  |_|\___/|___/_| |_|");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n------------ Created by Kyle Smith - 2018 © ------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void AskIfYouWantToBeXorO()
        {
            Boolean valid = false;

            do
            {
                Console.Write("\nWould you like to be X or O? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.White;


                if (input == "x")
                {
                    UserPiece = "X";
                    CompPiece = "O";
                    valid = true;
                }
                else if (input == "o")
                {
                    UserPiece = "O";
                    CompPiece = "X";
                    valid = true;
                }
                else
                {
                    Console.Write($"\nThis is supposed to be X and O not X and {input} {Name}... Try again!\n");
                }
            } while (!valid);
        }
    }
}
