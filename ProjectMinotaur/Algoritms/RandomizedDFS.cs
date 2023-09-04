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

        /// <summary>
        /// Ze startovní buňky rekurzivně náhodně generuje další buňky, které pak spojuje 
        /// </summary>
        /// <param name="cell"></param>
        private void GenerateNextCell(Point cell)
        {
            //Nastaví buňku jako navštívenou
            maze[cell.X, cell.Y] = false;
            List<Point> unvisitedNeigbours = AddUnvisitedNeigbours(cell);

            Point tempPoint;
            int index;


            while (unvisitedNeigbours.Count > 0)
            {
                //Vybere náhodnou buňku v seznamu
                index = random.Next(unvisitedNeigbours.Count);
                tempPoint = unvisitedNeigbours[index];

                if (maze[tempPoint.X, tempPoint.Y])
                {
                    //Spustí na ni rekurzivně tuto funkci
                    GenerateNextCell(tempPoint);

                    //Vymaže stěnu mezi němi
                    maze[cell.X + (tempPoint.X- cell.X) / 2, cell.Y + ( tempPoint.Y - cell.Y) / 2] = false;
                }
                unvisitedNeigbours.RemoveAt(index);
            }
        }

        /// <summary>
        /// Vytvoří seznam všech nenavštívených sousedů buňky
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private List<Point> AddUnvisitedNeigbours(Point cell)
        {

            List<Point> unvisitedNeigbours = new List<Point>();
            Point tempPoint;
            for (int i = 0; i < 4; i++)
            {
                //Vytvoří souřadnice souseda buňky
                tempPoint = cell;
                tempPoint.Offset(neigbours[i]);

                //Zkontroluje zda je v bludišti a je nenavštívený
                if (IsInBoundaries(tempPoint) && maze[tempPoint.X, tempPoint.Y])
                {
                    unvisitedNeigbours.Add(tempPoint);
                }
            }

            return unvisitedNeigbours;
        }
    }
}
