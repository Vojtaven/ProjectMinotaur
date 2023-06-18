using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMinotaur
{
    internal class MazeManager
    {
        private bool[,] maze;
        private int size;
        private GraphicsManager graphicsManager;
        public MazeManager(GraphicsManager graphicsManager)
        {
            this.graphicsManager = graphicsManager;
        }


        public bool[,] Maze
        {
            get { return maze; }
            set
            {
                if (value.GetLength(0) != value.GetLength(1))
                    throw new ArgumentException("Maze map must be square");

                size = value.GetLength(0);
                maze = value;
                graphicsManager.CreateMazeFromMap(maze);
            }
        }

        public bool IsFree(Point position)
        {
            bool outputValue = false;
            if (position.X >= 0 && position.Y >= 0 && position.X < size && position.Y < size)
            {
                outputValue = !maze[position.X, position.Y];
            }


            return outputValue;
        }

    }
}
