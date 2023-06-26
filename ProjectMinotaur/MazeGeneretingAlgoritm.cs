using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMinotaur
{
    internal abstract class MazeGeneretingAlgoritm
    {
        private string name;
        public MazeGeneretingAlgoritm(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
        public abstract bool[,] generateMaze(int MazeSize);

    }
}
