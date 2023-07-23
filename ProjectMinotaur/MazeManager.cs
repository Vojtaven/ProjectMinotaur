using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algoritms;

namespace ProjectMinotaur
{
    internal class MazeManager
    {
        private bool[,] maze;
        private int size;
        private GraphicsManager graphicsManager;
        ComboBox algoritmChoiceCB;
        NumericUpDown mazeSizeNUP;
        MazeGeneretingAlgoritm[] algoritms = { new RandomizedDFS("Randomized DFS"), new RandomizedKruskal("Randomized Kruskal"), new RandomizedPrim("Randomized Prim"), new Tessellation("Tessellation"), new Wilson("Wilson") };


        public MazeManager(GraphicsManager graphicsManager,ComboBox algoritmChoiceCB,NumericUpDown mazeSizeNUP)
        {
            this.graphicsManager = graphicsManager;
            this.algoritmChoiceCB = algoritmChoiceCB;
            this.mazeSizeNUP    = mazeSizeNUP;
            UpdateAlgoritmsChoice();
        }

        public void UpdateAlgoritmsChoice()
        {
            algoritmChoiceCB.Items.Clear();
            foreach(MazeGeneretingAlgoritm x in algoritms)
            {
                algoritmChoiceCB.Items.Add(x.ToString());
            }
            algoritmChoiceCB.SelectedIndex = 0;
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
