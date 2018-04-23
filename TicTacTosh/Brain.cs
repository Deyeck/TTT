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
            PrintBoard();
            //UserMakesMove();
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
        * X|X|X
        * X|X|X
        * X|X|X
        * 
        *
        */

        /*
         *  main()
         *  {
         *      ClearBoard();
         *      do
         *      {
         *      
         *      }
         *      while(victor || draw
         *  }
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

        public static List<List<int>> board = new List<List<int>>() { };

        public static List<List<int>> Board { get => board; set => board = value; }

        public static List<List<int>> Corners { get => corners; set => corners = value; }

        public static List<List<int>> MidEdges { get => midEdges; set => midEdges = value; }

        public static List<List<int>> Center { get => center; set => center = value; }

        public static void AIMakeMove()
        {
            List<List<int>> board = new List<List<int>>();
            List<List<int>> avaliableSpaces = GetAvaliableSpaces();
            List<int> position = ChooseRandomPosition(avaliableSpaces);

            position[2] = 1;

            foreach (var pos in Board)
            {
                if (pos.ElementAt(0) == position[0] && pos.ElementAt(1) == position[1])
                {
                    pos.Insert(2, position[2]);
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
            Board = new List<List<int>>(){
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
                    Console.Write("3 ");
                }
                else if (count == 3 )
                {
                    Console.Write("2 ");
                }
                else if (count == 6)
                {
                    Console.Write("1 ");
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
                    Console.Write("\n  1 2 3\n\n");
                }
                else
                {
                    Console.Write("|");
                }
            }
            //Console.WriteLine($"{board[0][2]}|{board[1][2]}|{board[2][2]}");
            //Console.WriteLine($"{board[3][2]}|{board[4][2]}|{board[5][2]}");
            //Console.WriteLine($"{board[6][2]}|{board[7][2]}|{board[8][2]}");
        }

        public static void UserMakesMove()
        { }
    }
}
