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
        private MazeGeneretingAlgorithm algoritmNowInUse;
        private Point playerStart = new Point(0, 0);
        private Point playerFinish;
        ComboBox algoritmChoiceCB;
        NumericUpDown mazeSizeNUP;
        MazeGeneretingAlgorithm[] algoritms = { new Wilson("Wilson") ,new RandomizedKruskal("Randomized Kruskal"), new RandomizedDFS("Randomized DFS"), new Tessellation("Tessellation"), new RandomizedPrim("Randomized Prim")};


        public MazeManager(GraphicsManager graphicsManager, ComboBox algoritmChoiceCB, NumericUpDown mazeSizeNUP)
        {
            this.graphicsManager = graphicsManager;
            this.algoritmChoiceCB = algoritmChoiceCB;
            this.mazeSizeNUP = mazeSizeNUP;
            Setup();
            UpdateAlgoritmsChoice();
        }
        /// <summary>
        /// Alktualizuje výběr algoritmů v Choice Boxu
        /// </summary>
        public void UpdateAlgoritmsChoice()
        {
            algoritmChoiceCB.Items.Clear();
            foreach (MazeGeneretingAlgorithm x in algoritms)
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
                playerFinish = new Point(size - 1, size - 1);
                graphicsManager.CreateMazeFromMap(maze);
            }
        }

        /// <summary>
        /// Vytvoří bludiště 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CreateMaze()
        {
            size = (int)mazeSizeNUP.Value;
            algoritmNowInUse = algoritms[algoritmChoiceCB.SelectedIndex];
            int[] suggestedSizes;

            //Zkontroluje zda velikost bludistě je vhodná
            if (algoritmNowInUse.ValidSize(size, out suggestedSizes))
            {
                maze = algoritmNowInUse.GenerateMaze(size);
            }
            else
            {
                //Pokud ne vybere mezi navrženými velikostmi
                //A přitom zkontroluje že velikosti jsou v rozmezí NumberUpDown boxu
                if (suggestedSizes[0] >= mazeSizeNUP.Minimum && suggestedSizes[1] <= mazeSizeNUP.Maximum)
                {
                    size = AskSuggestedSizes(suggestedSizes);
                    if (size == -1)
                        return;
                }
                if (suggestedSizes[0] < mazeSizeNUP.Minimum && suggestedSizes[1] <= mazeSizeNUP.Maximum)
                {
                    if (AskSuggestedSize(suggestedSizes[1]))
                    {
                        size = suggestedSizes[1];
                    }
                    else
                        return;
                }
                if (suggestedSizes[0] >= mazeSizeNUP.Minimum && suggestedSizes[1] > mazeSizeNUP.Maximum)
                {
                    if (AskSuggestedSize(suggestedSizes[0]))
                    {
                        size = suggestedSizes[0];
                    }
                    else
                        return;

                }
                if (suggestedSizes[0] < mazeSizeNUP.Minimum && suggestedSizes[1] > mazeSizeNUP.Maximum)
                {
                    throw new Exception("Suggested sizes don't fit in mazeSizeNUP interval");
                }

                //Vytvoření bludiště
                mazeSizeNUP.Value = size;
                maze = algoritmNowInUse.GenerateMaze(size);
            }

            //Přidání konce
            playerFinish = new Point(size - 1, size - 1);

            //Vytvoření bludiště a přidání konce
            graphicsManager.CreateMazeFromMap(maze);
            graphicsManager.AddFinish(playerFinish);

        }


        /// <summary>
        /// Zkontroluje zda na pozici není zed
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsFree(Point position)
        {
            bool outputValue = false;
            if (position.X >= 0 && position.Y >= 0 && position.X < size && position.Y < size)
            {
                outputValue = !maze[position.X, position.Y];
            }

            return outputValue;
        }

        /// <summary>
        /// Počáteční nastavení bludiště
        /// </summary>
        private void Setup()
        {
            this.Maze = new bool[51, 51];
        }

        /// <summary>
        /// Zeptá se na navrhnuté velikosti pomocí Message boxu
        /// </summary>
        /// <param name="suggestedSizes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Zeptá se na navrhnutou velikost pomocí Message boxu
        /// </summary>
        /// <param name="suggestedSize"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Zkontroluje zda pozice není konec
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsFinnish(Point position)
        {
            return position == playerFinish;
        }
    }
}
