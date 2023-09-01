using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algoritms
{
    internal class RandomizedPrim : MazeGeneretingAlgoritm
    {
        private Point[] neigbours = { new Point(2, 0), new Point(0, 2), new Point(-2, 0), new Point(0, -2) };
        private int mazeSize;
        private bool[,] maze;
        Random random = new Random();
        public RandomizedPrim(string name) : base(name) { }


        public override bool[,] GenerateMaze(int mazeSize)
        {
            StartingConfiguration(mazeSize);
            List<Point> unvisitedAdjacentCells = new List<Point>();
            List<Point> adjacentCellsPartOfMaze = new List<Point>();
            List<Point> adjacentCells;

            unvisitedAdjacentCells.Add(new Point(random.Next(mazeSize / 2) * 2, random.Next(mazeSize / 2) * 2));

            Point cellInProcess;
            int index;

            while (unvisitedAdjacentCells.Count > 0)
            {
                index = random.Next( unvisitedAdjacentCells.Count);
                cellInProcess = unvisitedAdjacentCells[index];
                unvisitedAdjacentCells.RemoveAt(index);
                if (maze[cellInProcess.X, cellInProcess.Y])
                {
                    maze[cellInProcess.X, cellInProcess.Y] = false;

                    adjacentCells = FindAllAdjacentCells(cellInProcess);

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

        protected override void StartingConfiguration(int mazeSize)
        {
            this.mazeSize = mazeSize;
            maze = new bool[mazeSize, mazeSize];
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    maze[i, j] = true;
                }
            }
        }

        private void ConnectCellWithRandomCell(Point cell,List<Point> adjacentCells)
        {
            if (adjacentCells.Count > 0)
            {
                Point tempPoint = adjacentCells[random.Next(adjacentCells.Count)];

                maze[cell.X + (tempPoint.X - cell.X) / 2, cell.Y + (tempPoint.Y - cell.Y) / 2] = false;
            }
        }
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

        private bool IsInBoundaries(Point point)
        {
            return 0 <= point.X && point.X < mazeSize && 0 <= point.Y && point.Y < mazeSize;
        }
    }
}
