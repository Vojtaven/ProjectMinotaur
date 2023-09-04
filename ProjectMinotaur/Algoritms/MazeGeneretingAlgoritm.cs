using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal abstract class MazeGeneretingAlgoritm
    {
        //Souřadnice pro počítaní sousedních buněk
        protected Point[] neigbours = { new Point(2, 0), new Point(0, 2), new Point(-2, 0), new Point(0, -2) };
        protected Random random = new Random();
        protected bool[,] maze;

        private string name;
        protected int mazeSize;
        public MazeGeneretingAlgoritm(string name)
        {
            this.name = name;
        }


        /// <summary>
        /// Zkontroluje zda velikost bludiště je vhodná pro daný algoritmus
        /// </summary>
        /// <param name="mazeSize"></param>
        /// <param name="sugestedSizes"></param>
        /// <returns></returns>
        public virtual bool ValidSize(int mazeSize, out int[] sugestedSizes)
        {
            if (mazeSize % 2 == 1)
            {
                sugestedSizes = new int[2];
                return true;
            }
            else
            {
                sugestedSizes = new int[] { mazeSize - 1, mazeSize + 1 };
                return false;
            }
        }
        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Vygeneruje bludiště dané velikosti
        /// </summary>
        /// <param name="MazeSize"></param>
        /// <returns></returns>
        public abstract bool[,] GenerateMaze(int MazeSize);
        /// <summary>
        /// Připraví základní konfiguraci bludiště
        /// Přepíše všechny buňky bludiště na true
        /// </summary>
        /// <param name="mazeSize"></param>
        protected virtual void StartingConfiguration(int mazeSize)
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
        /// <summary>
        /// Zkontroluje zda bod je v mezích bludiště
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected bool IsInBoundaries(Point point)
        {
            return 0 <= point.X && point.X < mazeSize && 0 <= point.Y && point.Y < mazeSize;
        }
    }
}
