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
        private MazeGeneretingAlgoritm algoritmNowInUse;
        ComboBox algoritmChoiceCB;
        NumericUpDown mazeSizeNUP;
        MazeGeneretingAlgoritm[] algoritms = { new RandomizedDFS("Randomized DFS"), new Tessellation("Tessellation"), new RandomizedKruskal("Randomized Kruskal"), new RandomizedPrim("Randomized Prim"), new Wilson("Wilson") };


        public MazeManager(GraphicsManager graphicsManager,ComboBox algoritmChoiceCB,NumericUpDown mazeSizeNUP)
        {
            this.graphicsManager = graphicsManager;
            this.algoritmChoiceCB = algoritmChoiceCB;
            this.mazeSizeNUP    = mazeSizeNUP;
            Setup();
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
            algoritmNowInUse = algoritms[0];
        }

        public bool[,] Maze
        {
            get { return maze; }
            set
            {
                if (value.GetLength(0) != value.GetLength(1))
                    throw new ArgumentException("Maze map must be square");

                size = value.GetLength(0);
                mazeSizeNUP.Value = size;
                maze = value;
                graphicsManager.CreateMazeFromMap(maze);
            }
        }

        public void CreateMaze()
        {
            size = (int)mazeSizeNUP.Value;
            algoritmNowInUse = algoritms[algoritmChoiceCB.SelectedIndex];
            int[] sugestedSizes;

            if (algoritmNowInUse.ValidSize(size,out sugestedSizes))
            {
               maze = algoritmNowInUse.GenerateMaze(size);
            }
            else
            {
                string message = $"For inputed size is not posible to generate maze with selected algoritm. Posible sizes are {sugestedSizes[0]} and {sugestedSizes[1]}. Press Yes for {sugestedSizes[0]} or No for {sugestedSizes[1]}";
                string title = "Invalid Size";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    size = sugestedSizes[0];
                }
                else if(result == DialogResult.No)
                {
                    size = sugestedSizes[1];
                }
                else
                {
                    return;
                }
                mazeSizeNUP.Value = size;

                maze = algoritmNowInUse.GenerateMaze(size);
            }

            graphicsManager.CreateMazeFromMap(maze);
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

        private void Setup()
        {
            this.Maze = new bool[51, 51];
        }

    }
}
