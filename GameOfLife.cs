/*
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
// Git Repo: https://github.com/emanvidmaker/GameOfLifeOnConsoleCS
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameOfLifeClass
    {
        public int[,] gridPattern;
        public GameOfLifeClass(int[,] gridPattern)
        {
            this.gridPattern = gridPattern;
        }

        public void CalculateNextGen()
        {
            gridPattern = CalculateNextGen(gridPattern);
        }
        public static int[,] CalculateNextGen(int[,] grid) //in case you need to render a pattern with out overwrite the previous one
        {
            int width = grid.GetLength(0);
            int hight = grid.GetLength(1);
            int[,] neighborsGrid = CalculateNeighbors(grid, width, hight); //get the Neighbor count on each cell

            var nextGrid = new int[width, hight];

            for (int Y = 0; Y < hight; Y++)
            {
                for (int X = 0; X < width; X++)
                {
                    int currentCell = grid[X, Y];
                    int neighbors = neighborsGrid[X, Y];
                    //The Rules
                    if (currentCell == 1)
                    { //if on
                        if (neighbors == 1) { currentCell = 0; } //has only 1 neighbors then it turns OFF in the next turn. (SOLITUDE)
                        if (neighbors >= 4) { currentCell = 0; } //has 4 or more neighbors then it turns OFF in the next turn. (OVERPOPULATION)
                        if ((neighbors == 2) || (neighbors == 3)) { currentCell = 1; }// has 2 or 3 neighbors then it remains ON in the next turn.
                    }
                    else if (currentCell == 0)
                    { //if off
                        if (neighbors == 3) currentCell = 1; //has exactly 3 neighbors then it turns ON in the next turn. (REPRODUCTION)
                    }

                    nextGrid[X, Y] = currentCell;

                }
            }
            return nextGrid;
        }
        public string GameToString() => GameToString(gridPattern);
        public string GameToString(int[,] grid) //turns the array into a human readable string
        {
            int width = grid.GetLength(0);
            int hight = grid.GetLength(1);
            string output = "";
            for (int X = 0; X < width; X++)
            {
                for (int Y = 0; Y < hight; Y++)
                {
                    if (grid[X, Y] == 1)
                        output += "=";
                    else
                        output += "-";
                    output += "";
                }
                output += System.Environment.NewLine;
            }
            return output;
        }

        public static int[,] CalculateNeighbors(int[,] grid)
        {
            int width = grid.GetLength(0);
            int hight = grid.GetLength(1);
            return CalculateNeighbors(grid, width, hight);
        }

        private static int[,] CalculateNeighbors(int[,] grid, int width, int hight)
        {   //creates an array with the amount of neighbors around each cell at that position 
            int[,] neighborsGrid = new int[width, hight];
            for (int Y = 0; Y < hight; Y++)
            {
                for (int X = 0; X < width; X++)
                {
                    for (int nY = -1; nY <= 1; nY++) //look around
                    {
                        for (int nX = -1; nX <= 1; nX++)
                        {
                            if (!(nX == 0 && nY == 0)) // count the cell if we are not looking at ourselfs
                            {
                                neighborsGrid[X, Y] += (grid[(nX + X + width) % width, (nY + Y + hight) % hight] >= 1) ? 1 : 0;
                                //turner operator to protect from trash input
                            }
                        }
                    }
                }
            }
            return neighborsGrid;
        }
    }
}
