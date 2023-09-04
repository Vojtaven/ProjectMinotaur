using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algoritms
{
    internal class RandomizedPrim : MazeGeneretingAlgoritm
    {
        public RandomizedPrim(string name) : base(name) { }


        public override bool[,] GenerateMaze(int mazeSize)
        {
            StartingConfiguration(mazeSize);

            List<Point> unvisitedAdjacentCells = new List<Point>();
            List<Point> adjacentCellsPartOfMaze = new List<Point>();
            List<Point> adjacentCells;

            //Náhodný bod pro začátek generace bludiště
            unvisitedAdjacentCells.Add(new Point(random.Next(mazeSize / 2) * 2, random.Next(mazeSize / 2) * 2));

            Point cellInProcess;
            int index;

            while (unvisitedAdjacentCells.Count > 0)
            {
                //Vybereme náhodnou buňku ze seznamu
                index = random.Next( unvisitedAdjacentCells.Count);
                cellInProcess = unvisitedAdjacentCells[index];
                unvisitedAdjacentCells.RemoveAt(index);

                //Zkontrolujeme zda je nenavštívená
                if (maze[cellInProcess.X, cellInProcess.Y])
                {
                    
                    maze[cellInProcess.X, cellInProcess.Y] = false;

                    adjacentCells = FindAllAdjacentCells(cellInProcess);

                    //Zjistíme, kteří sousedé jsou navštívení a kteří ne
                    for (int i = 0; i < adjacentCells.Count; i++)
                    {
                        if (maze[adjacentCells[i].X, adjacentCells[i].Y])
                        {
                            unvisitedAdjacentCells.Add(adjacentCells[i]);
                        }
                        else
                        {
                            adjacentCellsPartOfMaze.Add(adjacentCells[i]);
                        }
                    }

                    ConnectCellWithRandomCell(cellInProcess, adjacentCellsPartOfMaze);
                    adjacentCellsPartOfMaze.Clear();
                }
            }

            return maze;
        }

        /// <summary>
        /// Pokud existuje nějaká buňka v seznamu adjacentCells tak vybere náhnou a spojí s ní bunku cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="adjacentCells"></param>
        private void ConnectCellWithRandomCell(Point cell,List<Point> adjacentCells)
        {
            if (adjacentCells.Count > 0)
            {
                Point tempPoint = adjacentCells[random.Next(adjacentCells.Count)];

                maze[cell.X + (tempPoint.X - cell.X) / 2, cell.Y + (tempPoint.Y - cell.Y) / 2] = false;
            }
        }

        /// <summary>
        /// Najde všechny sousedy buňky cell, kteří nejsou mimo hranice bludiště
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private List<Point> FindAllAdjacentCells( Point cell)
        {
            List<Point> adjacentCells = new List<Point>();
            Point tempPoint;
            for (int i = 0; i < 4; i++)
            {
                tempPoint = cell;
                tempPoint.Offset(neigbours[i]);
                if (IsInBoundaries(tempPoint))
                {
                    adjacentCells.Add(tempPoint);
                }
            }

            return adjacentCells;
        }


    }
}
