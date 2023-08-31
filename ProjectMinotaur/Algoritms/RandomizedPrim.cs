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
            bool[,] maze = new bool[mazeSize, mazeSize];





            return maze;
        }

        protected override void StartingConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
