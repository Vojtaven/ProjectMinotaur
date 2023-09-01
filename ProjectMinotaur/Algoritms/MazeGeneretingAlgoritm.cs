using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal abstract class MazeGeneretingAlgoritm
    {
        private string name;
        public MazeGeneretingAlgoritm(string name)
        {
            this.name = name;
        }



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

        public abstract bool[,] GenerateMaze(int MazeSize);

        protected abstract void StartingConfiguration(int mazeSize);

    }
}
