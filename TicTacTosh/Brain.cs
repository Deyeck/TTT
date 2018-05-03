using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacTosh
{
    public class Brain
    {
        const string fucks = "None";

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

        public static Boolean FirstTurn { get; set; }

        public static KeyValuePair<string, string> BestPosition { get; set; }

        public static string BestMove { get; set; }

        public static string ComputerBestMove { get; set; }

        public static string ComputerGoodMove { get; set; }

        public static string ComputerRandomPosition { get; set; }

        public static string UserBestMove { get; set; }

        public static string UserGoodMove { get; set; }

        public static string UserRandomPosition { get; set; }

        public static List<KeyValuePair<string, int>> FindWinConditionTwoOfThree(string piece)
        {
            List<KeyValuePair<string, string>> boardValues = new List<KeyValuePair<string, string>>();
            boardValues = Board;

            int leftTop = 0;
            int leftMiddle = 0;
            int leftBottom = 0;
            int centerTop = 0;
            int centerMiddle = 0;
            int centerBottom = 0;
            int rightTop = 0;
            int rightMiddle = 0;
            int rightBottom = 0;

            if (piece.Equals("user"))
            {
                if(CompPiece.Equals("X"))
                {
                    piece = "O";
                }
                else
                {
                    piece = "X";
                }
            }

            //LT + CT + empty RT
            // x|x|
            //  | | 
            //  | |
            if (boardValues[0].Value == piece && boardValues[1].Value == piece && boardValues[2].Value == " ")
            {
                rightTop++;
            }
            //LM + CM + empty RM
            //  | |
            // x|x| 
            //  | |
            if (boardValues[3].Value == piece && boardValues[4].Value == piece && boardValues[5].Value == " ")
            {
                rightMiddle++;
            }
            //LB + CB + empty RB
            //  | |
            //  | | 
            // x|x|
            if (boardValues[6].Value == piece && boardValues[7].Value == piece && boardValues[8].Value == " ")
            {
                rightBottom++;
            }
            //CT + RT + empty LT
            //  |x|x
            //  | | 
            //  | |
            if (boardValues[0].Value == " " && boardValues[1].Value == piece && boardValues[2].Value == piece)
            {
                leftTop++;
            }
            //CM + RM + empty LM
            //  | |
            //  |x|x 
            //  | |
            if (boardValues[3].Value == " " && boardValues[4].Value == piece && boardValues[5].Value == piece)
            {
                leftMiddle++;
            }
            //CB + RB + empty LB
            //  | |
            //  | | 
            //  |x|x
            if (boardValues[6].Value == " " && boardValues[7].Value == piece && boardValues[8].Value == piece)
            {
                leftBottom++;
            }
            // LT + LM + empty LB
            // x| |
            // x| | 
            //  | |
            if (boardValues[0].Value == piece && boardValues[3].Value == piece && boardValues[6].Value == " ")
            {
                leftBottom++;
            }
            // CT + CM + empty CB
            //  |x|
            //  |x| 
            //  | |
            if (boardValues[1].Value == piece && boardValues[4].Value == piece && boardValues[7].Value == " ")
            {
                centerBottom++;
            }
            // RT + RM + empty RB
            //  | |x
            //  | |x
            //  | |
            if (boardValues[2].Value == piece && boardValues[5].Value == piece && boardValues[8].Value == " ")
            {
                rightBottom++;
            }
            // LM + LB + empty LT
            //  | |
            // x| |
            // x| |
            if (boardValues[0].Value == " " && boardValues[3].Value == piece && boardValues[6].Value == piece)
            {
                leftTop++;
            }
            // CM + CB + empty CT
            //  | |
            //  |x|
            //  |x|
            if (boardValues[1].Value == " " && boardValues[4].Value == piece && boardValues[7].Value == piece)
            {
                centerTop++;
            }
            // RM + RB + empty RT
            //  | |
            //  | |x
            //  | |x
            if (boardValues[2].Value == " " && boardValues[5].Value == piece && boardValues[8].Value == piece)
            {
                rightTop++;
            }
            // LT + CM + empty RB
            // x| |
            //  |x|
            //  | |
            if (boardValues[0].Value == piece && boardValues[4].Value == piece && boardValues[8].Value == " ")
            {
                rightBottom++;
            }
            // RT + CM + empty LB
            //  | |x
            //  |x|
            //  | |
            if (boardValues[2].Value == piece && boardValues[4].Value == piece && boardValues[6].Value == " ")
            {
                leftBottom++;
            }
            // RB + CM + empty LT
            //  | |
            //  |x|
            //  | |x
            if (boardValues[0].Value == "" && boardValues[4].Value == piece && boardValues[8].Value == piece)
            {
                leftTop++;
            }
            // LB + CM + empty RT
            //  | |
            //  |x|
            // x| |
            if (boardValues[2].Value == " " && boardValues[4].Value == piece && boardValues[6].Value == piece)
            {
                rightTop++;
            }
            // LT + RB + empty CM
            // x| |
            //  | |
            //  | |x
            if (boardValues[0].Value == piece && boardValues[4].Value == " " && boardValues[8].Value == piece)
            {
                centerMiddle++;
            }
            // RT + LB + empty CM
            //  | |x
            //  | |
            // x| |
            if (boardValues[2].Value == piece && boardValues[4].Value == " " && boardValues[6].Value == piece)
            {
                centerMiddle++;
            }
            // CT + CB + empty CM
            //  |x|
            //  | |
            //  |x|
            if (boardValues[1].Value == piece && boardValues[4].Value == " " && boardValues[7].Value == piece)
            {
                centerMiddle++;
            }
            // LT + LB + empty LM
            // x| |
            //  | |
            // x| |
            if (boardValues[0].Value == piece && boardValues[3].Value == " " && boardValues[6].Value == piece)
            {
                leftMiddle++;
            }
            // RT + RB + empty RM
            //  | |x
            //  | |
            //  | |x
            if (boardValues[2].Value == piece && boardValues[5].Value == " " && boardValues[8].Value == piece)
            {
                rightMiddle++;
            }
            // LM + RM + empty CM
            //  | |
            // x| |x
            //  | |
            if (boardValues[3].Value == piece && boardValues[4].Value == " " && boardValues[5].Value == piece)
            {
                centerMiddle++;
            }
            // LT + RT + empty CT
            // X| |x
            //  | |
            //  | |
            if (boardValues[0].Value == piece && boardValues[1].Value == " " && boardValues[2].Value == piece)
            {
                centerTop++;
            }
            // LB + RB + empty CB
            //  | |
            //  | |
            // x| |x
            if (boardValues[6].Value == piece && boardValues[7].Value == " " && boardValues[8].Value == piece)
            {
                centerBottom++;
            }

            List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>
            {
               new KeyValuePair<string, int> ("LT", leftTop),
               new KeyValuePair<string, int> ("LM", leftMiddle),
               new KeyValuePair<string, int> ("LB", leftBottom),
               new KeyValuePair<string, int> ("CT", centerTop),
               new KeyValuePair<string, int> ("CM", centerMiddle),
               new KeyValuePair<string, int> ("CB", centerBottom),
               new KeyValuePair<string, int> ("RT", rightTop),
               new KeyValuePair<string, int> ("RM", rightMiddle),
               new KeyValuePair<string, int> ("RB", rightBottom)
            };

            return listOfScores;
        }

        public static List<KeyValuePair<string, int>> FindWinConditionOneOfThree(string piece)
        {

            List<KeyValuePair<string, string>> boardValues = new List<KeyValuePair<string, string>>();

            if (piece.Equals("user"))
            {
                if (CompPiece.Equals("X"))
                {
                    piece = "O";
                }
                else
                {
                    piece = "X";
                }
            }

            boardValues = Board;

            // reset scores
            int leftTop = 0;
            int leftMiddle = 0;
            int leftBottom = 0;
            int centerTop = 0;
            int centerMiddle = 0;
            int centerBottom = 0;
            int rightTop = 0;
            int rightMiddle = 0;
            int rightBottom = 0;

            //LT + empty CT + empty RT || LT + empty LM + empty LB || LT + empty CM + empty RB
            // x| |
            //  | | 
            //  | |
            if (boardValues[0].Value == piece && boardValues[1].Value == " " && boardValues[2].Value == " ")
            {
                rightTop++;
                centerTop++;
            }
            if (boardValues[0].Value == piece && boardValues[3].Value == " " && boardValues[6].Value == " ")
            {
                leftMiddle++;
                leftBottom++;
            }
            if (boardValues[0].Value == piece && boardValues[4].Value == " " && boardValues[8].Value == " ")
            {
                centerMiddle++;
                rightBottom++;
            }
            //LM + empty LT + empty RT || LM + empty CM + empty CB
            //  |x|
            //  | | 
            //  | |
            if (boardValues[0].Value == " " && boardValues[1].Value == piece && boardValues[2].Value == " ")
            {
                leftTop++;
                rightTop++;
            }
            if (boardValues[1].Value == piece && boardValues[4].Value == " " && boardValues[7].Value == " ")
            {
                centerMiddle++;
                centerBottom++;
            }
            //RT + empty LT + empty CT || RT + empty CM + empty LB || RT + empty RM + empty RB
            //  | |x
            //  | | 
            //  | |
            if (boardValues[0].Value == " " && boardValues[1].Value == " " && boardValues[2].Value == piece)
            {
                leftTop++;
                centerTop++;
            }
            if (boardValues[2].Value == piece && boardValues[4].Value == " " && boardValues[6].Value == " ")
            {
                centerMiddle++;
                leftBottom++;
            }
            if (boardValues[2].Value == piece && boardValues[5].Value == " " && boardValues[8].Value == " ")
            {
                rightMiddle++;
                rightBottom++;
            }
            // LM + empty LT + empty LB || LM + empty CM + empty RM
            //  | |
            // x| | 
            //  | |
            if (boardValues[0].Value == " " && boardValues[3].Value == piece && boardValues[6].Value == " ")
            {
                leftTop++;
                leftBottom++;
            }
            if (boardValues[3].Value == piece && boardValues[4].Value == " " && boardValues[5].Value == " ")
            {
                centerMiddle++;
                rightMiddle++;
            }
            // CM + empty LT + empty RB || CM + empty CT + empty CB || CM + empty RT + empty LB || CM + empty LM + empty RM
            //  | |
            //  |x| 
            //  | |
            if (boardValues[0].Value == " " && boardValues[4].Value == piece && boardValues[8].Value == " ")
            {
                leftTop++;
                rightBottom++;
            }
            if (boardValues[1].Value == " " && boardValues[4].Value == piece && boardValues[7].Value == " ")
            {
                centerTop++;
                centerBottom++;
            }
            if (boardValues[2].Value == " " && boardValues[4].Value == piece && boardValues[6].Value == " ")
            {
                rightTop++;
                leftBottom++;
            }
            if (boardValues[3].Value == " " && boardValues[4].Value == piece && boardValues[5].Value == " ")
            {
                leftMiddle++;
                rightMiddle++;
            }
            // RM + empty RT + empty RB || RM + empty LM + empty CM
            //  | |
            //  | |x
            //  | |
            if (boardValues[2].Value == " " && boardValues[5].Value == piece && boardValues[8].Value == " ")
            {
                rightTop++;
                rightBottom++;
            }
            if (boardValues[3].Value == " " && boardValues[4].Value == " " && boardValues[5].Value == piece)
            {
                leftMiddle++;
                centerMiddle++;
            }
            // LB + empty LM + empty LT || LB + empty CM + empty RT || LB + empty CB + empty RB
            //  | |
            //  | | 
            // x| |
            if (boardValues[6].Value == piece && boardValues[3].Value == " " && boardValues[0].Value == " ")
            {
                leftTop++;
                leftMiddle++;
            }
            if (boardValues[6].Value == piece && boardValues[4].Value == " " && boardValues[2].Value == " ")
            {
                centerMiddle++;
                rightTop++;
            }
            if (boardValues[6].Value == piece && boardValues[7].Value == " " && boardValues[8].Value == " ")
            {
                centerBottom++;
                rightBottom++;
            }
            // CB + empty LB + empty RB || CB + empty CM + empty CT
            //  | |
            //  | | 
            //  |x|
            if (boardValues[6].Value == " " && boardValues[7].Value == piece && boardValues[8].Value == " ")
            {
                leftBottom++;
                rightBottom++;
            }
            if (boardValues[1].Value == " " && boardValues[4].Value == " " && boardValues[7].Value == piece)
            {
                centerMiddle++;
                centerTop++;
            }
            // RB + empty RM + empty RT || RB + empty LT + empty CM || RB + empty CB  + empty LB
            //  | |
            //  | |
            //  | |x
            if (boardValues[8].Value == piece && boardValues[5].Value == " " && boardValues[2].Value == " ")
            {
                leftTop++;
                leftMiddle++;
            }
            if (boardValues[8].Value == piece && boardValues[0].Value == " " && boardValues[4].Value == " ")
            {
                leftTop++;
                centerMiddle++;
            }
            if (boardValues[8].Value == piece && boardValues[6].Value == " " && boardValues[7].Value == " ")
            {
                leftBottom++;
                centerBottom++;
            }

            List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>
            {
               new KeyValuePair<string, int> ("LT", leftTop),
               new KeyValuePair<string, int> ("LM", leftMiddle),
               new KeyValuePair<string, int> ("LB", leftBottom),
               new KeyValuePair<string, int> ("CT", centerTop),
               new KeyValuePair<string, int> ("CM", centerMiddle),
               new KeyValuePair<string, int> ("CB", centerBottom),
               new KeyValuePair<string, int> ("RT", rightTop),
               new KeyValuePair<string, int> ("RM", rightMiddle),
               new KeyValuePair<string, int> ("RB", rightBottom)
            };

            return listOfScores;
        }


        public static void AssessComputerBestMove()
        {
            Random rnd = new Random();
            List<List<string>> possibleWins = new List<List<string>>();
            List<KeyValuePair<string, string>> boardValues = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, string>> avaliableSpaces = new List<KeyValuePair<string, string>>();

            string computerPiece = CompPiece;
            boardValues = Board;

            List<KeyValuePair<string, int>> listOfHighScores = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> listOfScores = new List<KeyValuePair<string, int>>();

            listOfScores = FindWinConditionTwoOfThree(computerPiece);

            int baseScore = 0;

            foreach (var score in listOfScores)
            {
                if (score.Value == 0)
                {
                    continue;
                }

                if (score.Value != 0 && score.Value == baseScore)
                {
                    listOfHighScores.Add(score);
                }

                if (score.Value > baseScore)
                {
                    listOfHighScores.Clear();
                    baseScore = score.Value;
                    listOfHighScores.Add(score);
                }
            }
            ComputerBestMove = null;
            int randomIndex = -1;

            if (listOfHighScores.Count() != 0)
            {
                randomIndex = rnd.Next(listOfHighScores.Count());
                ComputerBestMove = listOfHighScores[randomIndex].Key;
            }

            if(ComputerBestMove != null)
            {
                Position = Board.Where(x => x.Key == ComputerBestMove).Single();
                ComputerBestMove = null;
                return;
            }
            else
            {
                // no win conditions so far in the game, have to choose a different way to select next best move

                listOfHighScores.Clear();
                baseScore = 0;
                listOfScores = FindWinConditionOneOfThree(computerPiece);

                foreach (var score in listOfScores)
                {
                    if (score.Value == 0)
                    {
                        continue;
                    }

                    if (score.Value != 0 && score.Value == baseScore)
                    {
                        listOfHighScores.Add(score);
                    }

                    if (score.Value > baseScore)
                    {
                        listOfHighScores.Clear();
                        baseScore = score.Value;
                        listOfHighScores.Add(score);
                    }
                }

                if (listOfHighScores.Count() != 0)
                {
                    randomIndex = rnd.Next(listOfHighScores.Count());
                    ComputerGoodMove = listOfHighScores[randomIndex].Key;
                }
            }

            if (ComputerGoodMove == null)
            {
                avaliableSpaces = GetAvaliableSpaces();
                ComputerRandomPosition = ChooseRandomPosition(avaliableSpaces).Key;
            }

            //if user move will win then take this place instead of the best move
            UserBestMove = null;
            List<KeyValuePair<string, int>> listOfUserScores = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> listOfUserHighScores = new List<KeyValuePair<string, int>>();
            int baseUserScore = 0;

            listOfUserScores = FindWinConditionTwoOfThree("user");

            foreach (var score in listOfUserScores)
            {
                if (score.Value == 0)
                {
                    continue;
                }

                if (score.Value != 0 && score.Value == baseUserScore)
                {
                    listOfUserHighScores.Add(score);
                }

                if (score.Value > baseUserScore)
                {
                    listOfUserHighScores.Clear();
                    baseUserScore = score.Value;
                    listOfUserHighScores.Add(score);
                }
            }

            ComputerBestMove = null;
            randomIndex = -1;

            if (listOfUserHighScores.Count() != 0)
            {
                randomIndex = rnd.Next(listOfUserHighScores.Count());
                UserBestMove = listOfUserHighScores[randomIndex].Key;
            }

            if (UserBestMove != null)
            {
                Position = Board.Where(x => x.Key == UserBestMove).Single();
                UserBestMove = null;
                return;
            }
            else
            {
                // no win conditions so far in the game, have to choose a different way to select next best move

                listOfUserHighScores.Clear();
                baseUserScore = 0;
                listOfUserScores = FindWinConditionOneOfThree("user");

                foreach (var score in listOfUserScores)
                {
                    if (score.Value == 0)
                    {
                        continue;
                    }

                    if (score.Value != 0 && score.Value == baseUserScore)
                    {
                        listOfUserHighScores.Add(score);
                    }

                    if (score.Value > baseUserScore)
                    {
                        listOfUserHighScores.Clear();
                        baseUserScore = score.Value;
                        listOfUserHighScores.Add(score);
                    }
                }

                if (listOfUserHighScores.Count() != 0)
                {
                    int randomIndexForUser = rnd.Next(listOfUserHighScores.Count());
                    UserGoodMove = listOfUserHighScores[randomIndexForUser].Key;
                }                
            }

            if (ComputerBestMove != null)
            {
                Position = Board.Where(x => x.Key == ComputerBestMove).Single();
            }
            else if (UserBestMove != null)
            {
                Position = Board.Where(x => x.Key == UserBestMove).Single();
            }
            else if (ComputerGoodMove == UserGoodMove)
            {
                Position = Board.Where(x => x.Key == ComputerGoodMove).Single();
            }
            else if (ComputerGoodMove != null)
            {
                Position = Board.Where(x => x.Key == ComputerGoodMove).Single();
            }
            else if (ComputerGoodMove == null && UserGoodMove != null)
            {
                Position = Board.Where(x => x.Key == UserGoodMove).Single();
            }
            else
            {
                Position = Board.Where(x => x.Key == ComputerRandomPosition).Single();
            }

            ComputerBestMove = null;
            UserBestMove = null;
            ComputerGoodMove = null;
            UserGoodMove = null;
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

        public static void AssertSpaceIsFree()
        {
            List<KeyValuePair<string, string>> avaliableSpaces = GetAvaliableSpaces();
            List<string> temp = new List<string>();

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

        public static void ComputerMakeMove()
        {
            List<KeyValuePair<string, string>> board = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> updatedPos = new KeyValuePair<string, string>();

            List<KeyValuePair<string, string>> avaliableSpaces = GetAvaliableSpaces();

            if (ComputerGoesFirst && FirstTurn)
            {
                Position = ChooseRandomPosition(avaliableSpaces);
                FirstTurn = false;
            }
            else
            {
                AssessComputerBestMove();
            }

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

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.Write("\n\t");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
        }

        public static void StartGame()
        {
            do
            {
                Board = ClearBoardValues();
                AskIfYouWantToBeXorO();
                DecideWhoGoesFirst();
                FirstTurn = true;

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
    } 
}
