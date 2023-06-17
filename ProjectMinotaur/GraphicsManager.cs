using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMinotaur
{
    internal class GraphicsManager
    {
        private Bitmap maze;
        private Graphics graphics;
        private PictureBox gameCanvas;
        private Brush brush = Brushes.Black;
        private int wallThickness,width,height;
        public GraphicsManager(PictureBox gameCanvas)
        {
            this.gameCanvas = gameCanvas;
        }
        public void CreateMaze(int[] mazeSize)
        {
            if (mazeSize[0] != mazeSize[1])
               throw new ArgumentException("Array must be square");

            width = gameCanvas.Width;
            height = gameCanvas.Height;
            wallThickness = width / (mazeSize[0] +2);

            maze = new Bitmap(width, height);
            graphics = Graphics.FromImage(maze);


            CreateMazeWalls();
        }


        private void CreateMazeWalls()
        {
            graphics.FillRectangle(brush, 0, 0, wallThickness, height);
            graphics.FillRectangle(brush, width - wallThickness, 0, wallThickness, height);
            graphics.FillRectangle(brush, 0, 0, width, wallThickness);
            graphics.FillRectangle(brush, 0, height - wallThickness, width, wallThickness);
        }

        public void Update()
        {
            gameCanvas.Image = maze;
        }
    }
}
