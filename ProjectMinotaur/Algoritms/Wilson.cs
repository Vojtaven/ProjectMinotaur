using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class Wilson : MazeGeneretingAlgoritm
    {
        public Wilson(string name) : base(name) { }


        public override bool[,] GenerateMaze(int mazeSize)
        {
            bool[,] maze = new bool[mazeSize, mazeSize];





            return maze;
        }

        protected override void StartingConfiguration(int mazeSize)
        {
            throw new NotImplementedException();
        }
    }
}
