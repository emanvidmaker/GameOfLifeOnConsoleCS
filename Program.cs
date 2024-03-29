﻿/*
 MIT License
-----------

Copyright (c) 2021 Emanuel Acosta
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/
// Code Inspired by https://gameoflife.pro/
using System;
using System.Threading;
using GameOfLife;

namespace GameOfLifeOnConsole
{
    //this is an example program
    //see GameOfLife.cs for game logic implementation 
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
           
            GameOfLifeClass game = new GameOfLifeClass(startPattern); // New game instance is made
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(game.GameToString());// Display its current state
                game.CalculateNextGen(); // Calculate next state
                Thread.Sleep(160);
                Console.Clear();
            }
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();

        }


    }
   
}
