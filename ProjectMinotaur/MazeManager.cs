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
            int[] suggestedSizes;

            if (algoritmNowInUse.ValidSize(size,out suggestedSizes))
            {
               maze = algoritmNowInUse.GenerateMaze(size);
            }
            else
            {
                if (suggestedSizes[0] >= mazeSizeNUP.Minimum && suggestedSizes[1] <= mazeSizeNUP.Maximum)
                {
                    size = AskSuggestedSizes(suggestedSizes);
                    if (size == -1)
                        return;


                }if(suggestedSizes[0] < mazeSizeNUP.Minimum && suggestedSizes[1] <= mazeSizeNUP.Maximum)
                {
                    if (AskSuggestedSize(suggestedSizes[1]))
                    {
                        size = suggestedSizes[1];
                    }
                    else
                        return;
                }
                if(suggestedSizes[0] >= mazeSizeNUP.Minimum && suggestedSizes[1] > mazeSizeNUP.Maximum)
                {
                    if (AskSuggestedSize(suggestedSizes[0]))
                    {
                        size = suggestedSizes[0];
                    }
                    else
                        return;

                }
                if(suggestedSizes[0] < mazeSizeNUP.Minimum && suggestedSizes[1] > mazeSizeNUP.Maximum)
                {
                    throw new Exception("Suggested sizes don't fit in mazeSizeNUP interval");
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
        private int AskSuggestedSizes(int[] suggestedSizes)
        {
            string message = $"For inputed size is not posible to generate maze with selected algoritm. Posible sizes are {suggestedSizes[0]} and {suggestedSizes[1]}. Press Yes for {suggestedSizes[0]} or No for {suggestedSizes[1]}";
            string title = "Invalid Size";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                return suggestedSizes[0];
            }
            else if (result == DialogResult.No)
            {
                return suggestedSizes[1];
            }
            else
            {
                return -1;
            }
        }

        private bool AskSuggestedSize(int suggestedSize)
        {
            string message = $"For inputed size is not posible to generate maze with selected algoritm. Posible size is {suggestedSize}. Press Yes for {suggestedSize} or NO to cancel";
            string title = "Invalid Size";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
