﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        private SolidBrush wallBrush = new SolidBrush(Color.Black);
        private SolidBrush playerBrush = new SolidBrush(Color.Lime);
        private SolidBrush backgroundBrush;
        private int width, height, mazeSize;
        private float wallThickness;
        private bool mazeGenerationInProgress = false;

        private Point playerPosition = new Point(-1, -1);
        private const float playerScaleDown = 1.25F;
        private float playerOffset;
        public GraphicsManager(PictureBox gameCanvas)
        {
            this.gameCanvas = gameCanvas;
            backgroundBrush = new SolidBrush(gameCanvas.BackColor);
            wallBrush = new SolidBrush(Color.FromArgb(gameCanvas.BackColor.ToArgb() ^ 0xffffff));
        }

        public void CreateMazeFromMap(bool[,] mazeMap)
        {
            if (mazeMap.GetLength(0) != mazeMap.GetLength(1))
                throw new ArgumentException("Maze map must be square");

            mazeSize = mazeMap.GetLength(0);
            mazeGenerationInProgress = true;

            CreateMazeBase();

            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    if (mazeMap[i, j])
                    {
                        AddWallPiece(new Point(i, j));
                    }
                }
            }

            mazeGenerationInProgress = false;
        }
        public void AddWallPiece(Point position)
        {
            if (position.X >= mazeSize || position.Y >= mazeSize)
                throw new ArgumentException("Wall piece must be in maze boundaries");

            graphics.FillRectangle(wallBrush, (position.Y + 1) * wallThickness, (position.X + 1) * wallThickness, wallThickness, wallThickness);
        }


        public Point PlayerPosition
        {
            set
            {
                Point position = value;
                if ((position.X >= mazeSize || position.Y >= mazeSize))
                    throw new ArgumentException("Player must be in maze boundaries");
                if (playerPosition.X != -1)
                {
                    RemovePlayer(playerPosition);
                }
                playerPosition = position;
                AddPlayer(playerPosition);
            }
            get { return playerPosition; }
        }

        private void RemovePlayer(Point position)
        {
            graphics.FillRectangle(backgroundBrush, (position.Y + 1) * wallThickness + playerOffset, (position.X + 1) * wallThickness + playerOffset, wallThickness / playerScaleDown, wallThickness / playerScaleDown);
        }

        private void AddPlayer(Point position)
        {
            graphics.FillRectangle(playerBrush, (position.Y + 1) * wallThickness + playerOffset, (position.X + 1) * wallThickness + playerOffset, wallThickness / playerScaleDown, wallThickness / playerScaleDown);
        }

        public void CreateMazeBase(int[] mazeShape)
        {
            if (mazeShape[0] != mazeShape[1])
                throw new ArgumentException("Maze must be square");

            width = gameCanvas.Width;
            height = gameCanvas.Height;
            mazeSize = mazeShape[0];

            wallThickness = (float)width / (mazeSize + 2);
            playerOffset = (wallThickness - (wallThickness / playerScaleDown)) / 2;

            maze = new Bitmap(width, height);
            graphics = Graphics.FromImage(maze);

            CreateMazeWalls();
        }

        private void CreateMazeBase()
        {
            width = gameCanvas.Width;
            height = gameCanvas.Height;
            wallThickness = (float)width / (mazeSize + 2);
            playerOffset = (wallThickness - (wallThickness / playerScaleDown)) / 2;

            maze = new Bitmap(width, height);
            graphics = Graphics.FromImage(maze);

            CreateMazeWalls();
        }


        private void CreateMazeWalls()
        {
            graphics.FillRectangle(wallBrush, 0, 0, wallThickness, height);
            graphics.FillRectangle(wallBrush, width - wallThickness, 0, wallThickness, height);
            graphics.FillRectangle(wallBrush, 0, 0, width, wallThickness);
            graphics.FillRectangle(wallBrush, 0, height - wallThickness, width, wallThickness);
        }

        public void Update()
        {
            if (!mazeGenerationInProgress)
                gameCanvas.Image = maze;
        }
    }
}