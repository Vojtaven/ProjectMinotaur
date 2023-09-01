using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class RandomizedDFS : MazeGeneretingAlgoritm
    {
        private Point[] neigbours = { new Point(2, 0), new Point(0, 2), new Point(-2, 0), new Point(0, -2) };

        private bool[,] maze;
        private Random random = new Random();
        private int mazeSize;
        public RandomizedDFS(string name) : base(name) { }

        public override bool ValidSize(int mazeSize, out int[] sugestedSizes)
        {
            
                return base.ValidSize(mazeSize, out sugestedSizes);
        }
        

        public override bool[,] GenerateMaze(int mazeSize)
        {

            StartingConfiguration(mazeSize);

            GenerateNextCell(new Point(0, 0));


            return maze;
        }

        private void GenerateNextCell(Point cell)
        {
            maze[cell.X, cell.Y] = false;
            List<Point> unvisitedNeigbours = AddNeigbours(cell);

            Point tempPoint;
            int index;
            while (unvisitedNeigbours.Count > 0)
            {
                index = random.Next(unvisitedNeigbours.Count);
                tempPoint = unvisitedNeigbours[index];
                if (maze[tempPoint.X, tempPoint.Y])
                {
                    GenerateNextCell(tempPoint);
                    maze[cell.X + (tempPoint.X- cell.X) / 2, cell.Y + ( tempPoint.Y - cell.Y) / 2] = false;
                }
                unvisitedNeigbours.RemoveAt(index);
            }
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

        private List<Point> AddNeigbours(Point cell)
        {

            List<Point> unvisitedNeigbours = new List<Point>();
            Point tempPoint;
            for (int i = 0; i < 4; i++)
            {
                tempPoint = cell;
                tempPoint.Offset(neigbours[i]);
                if (IsInBoundaries(tempPoint) && maze[tempPoint.X, tempPoint.Y])
                {
                    unvisitedNeigbours.Add(tempPoint);
                }
            }

            return unvisitedNeigbours;
        }
        private bool IsInBoundaries(Point point)
        {
            return 0 <= point.X && point.X < mazeSize && 0 <= point.Y && point.Y < mazeSize;
        }
    }
}
