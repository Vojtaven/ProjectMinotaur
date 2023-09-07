using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class Wilson : MazeGeneretingAlgorithm
    {
        private int[,] mazeForWalk;
        public Wilson(string name) : base(name) { }


        public override bool[,] GenerateMaze(int mazeSize)
        {
            StartingConfiguration(mazeSize);

            List<Point> cells = AddAllCells();
            mazeForWalk = new int[mazeSize, mazeSize]; //Pomocné pole pro náhonou chůzi

            int generation = 1;
            int index = random.Next(cells.Count);
            Point currentCell = cells[index];
            cells.RemoveAt(index);
            mazeForWalk[currentCell.X, currentCell.Y] = generation; //Nastavení první buňky jako součást bludiště   
            generation++;

            while (cells.Count > 0)
            {
                //Vybereme náhodnou buňku, na které spustíme LoopErasedRandomWalk
                index = random.Next(cells.Count);
                currentCell = cells[index];
                cells.RemoveAt(index);

                LoopErasedRandomWalk(currentCell, generation);
                generation++;
            }

            maze = intMazeToBoolMaze(mazeForWalk);
            return maze;
        }
        /// <summary>
        /// Provede Loop Erased Random Walk z cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="generation"></param>
        /// <returns>(-1,-1) pokud přidáváme cestu nebo pozici buňky kam mažeme cestu</returns>
        private Point LoopErasedRandomWalk(Point cell, int generation)
        {
            if (generation == mazeForWalk[cell.X, cell.Y]) //Pokud dostaneme buňku, která již je součástí tehle generace, tak jsme vytvořili smyčku
            {
                return cell; //Vrátíme tuhle buňku, aby jsme věděli kam máme smazat cestu
            }
            else if (mazeForWalk[cell.X, cell.Y] > 0)
            {
                return new Point(-1, -1); //Pokud narazíme na buňku, která je větší jak nula, tak jsme narazili na bludiště a můžeme přidat celou cestu
            }
            else
            {
                //Pokud nenastane ani jenda situace můžeme si poznačit cestu a pokračovat
                mazeForWalk[cell.X, cell.Y] = generation;
            }

            Point tempCell;
            List<Point> adjacentCells = FindAllAdjacentCells(cell);
            tempCell = adjacentCells[random.Next(adjacentCells.Count)];

            //Znovu zavoláme LoopErasedRandomWalk na náhoného souseda
            Point result = LoopErasedRandomWalk(tempCell, generation);

            while (result != new Point(-1, -1))
            {
                if (result == cell) //Pokud se vrácená buňka rovná cell, znamená že smyška končí a můžeme pokračovat
                {
                    tempCell = adjacentCells[random.Next(adjacentCells.Count)];
                    result = LoopErasedRandomWalk(tempCell, generation);
                }
                else //Pokud ne odebereme cell a předáme result dále
                {
                    mazeForWalk[cell.X, cell.Y] = 0;
                    break;
                }
            }

            if (result == new Point(-1, -1)) //Pokud se result rovná (-1,-1) našli jsme bludiště a přidáváme cestu.
            {
                ConnectCells(tempCell, cell, generation);
            }

            return result;
        }

        /// <summary>
        /// Spojí dvě buňky = smaže mezi nimi zeď
        /// </summary>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="generation"></param>
        private void ConnectCells(Point cell1, Point cell2, int generation)
        {
            mazeForWalk[cell1.X + (cell2.X - cell1.X) / 2, cell1.Y + (cell2.Y - cell1.Y) / 2] = generation;
        }

        /// <summary>
        /// Přídá všechny buňky bludiště
        /// </summary>
        /// <returns></returns>
        private List<Point> AddAllCells()
        {
            List<Point> cells = new List<Point>();
            for (int i = 0; i < mazeSize; i += 2)
            {
                for (int j = 0; j < mazeSize; j += 2)
                {
                    cells.Add(new Point(i, j));
                }
            }
            return cells;
        }
        /// <summary>
        /// Najde všechny sousedy
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private List<Point> FindAllAdjacentCells(Point cell)
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

        /// <summary>
        /// Každou buňku která je v intMaze 0 udělá stěnou
        /// </summary>
        /// <param name="intMaze"></param>
        /// <returns></returns>
        private bool[,] intMazeToBoolMaze(int[,] intMaze)
        {
            bool[,] maze = new bool[mazeSize, mazeSize];
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    maze[i, j] = intMaze[i, j] == 0;
                }
            }
            return maze;
        }

        protected override void StartingConfiguration(int mazeSize)
        {
            this.mazeSize = mazeSize;
        }
    }
}
