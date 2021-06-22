using System;
using System.Threading;
using GameOfLife;

namespace GameOfLifeOnConsole
{
    class Program
    {
        public static int[,] startPattern = new int[16, 16]{
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0},
        {0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0},
        {0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0}
        };
        static void Main(string[] args)
        {
           
            GameOflife game = new GameOflife(startPattern);
            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(game.GameToString());
                game.CalculateNextGen();
                Thread.Sleep(160);
                Console.Clear();
                
            }

        }

        
    }
   
}
