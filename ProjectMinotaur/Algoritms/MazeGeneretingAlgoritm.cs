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


        public bool ValidSize(int mazeSize, out int[] sugestedSizes)
        {
            sugestedSizes = new int[2];
            return true;
        }
        public override string ToString()
        {
            return name;
        }

        public abstract bool[,] GenerateMaze(int MazeSize);

    }
}
