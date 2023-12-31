﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMinotaur
{
    internal class GraphicsManager
    {
        private Bitmap maze;
        private Graphics graphics;
        private PictureBox gameCanvas;
        private SolidBrush wallBrush = new SolidBrush(Color.Black);
        private SolidBrush backgroundBrush;
        private SolidBrush finishBrush = new SolidBrush(Color.Yellow);

        private int width, height, mazeSize;
        private float wallThickness;
        private bool mazeGenerationInProgress = false;

        private const float playerScaleDown = 1.50F;
        private float playerOffset;
        public GraphicsManager(PictureBox gameCanvas)
        {
            this.gameCanvas = gameCanvas;
            backgroundBrush = new SolidBrush(gameCanvas.BackColor);
            wallBrush = new SolidBrush(Color.FromArgb(gameCanvas.BackColor.ToArgb() ^ 0xffffff));
        }

        /// <summary>
        /// Vytvoří bludiště z mapy
        /// </summary>
        /// <param name="mazeMap"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Přidá zeď na pozici
        /// </summary>
        /// <param name="position"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddWallPiece(Point position)
        {
            if (position.X >= mazeSize || position.Y >= mazeSize)
                throw new ArgumentException("Wall piece must be in maze boundaries");

            graphics.FillRectangle(wallBrush, (position.Y + 1) * wallThickness, (position.X + 1) * wallThickness, wallThickness, wallThickness);
        }

        /// <summary>
        /// Změní pozici hráče
        /// </summary>
        /// <param name="player"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ChangePlayerPosition(PlayerController player)
        {
            if ((player.Position.X >= mazeSize || player.Position.Y >= mazeSize))
                throw new ArgumentException("Player must be in maze boundaries");

            RemovePlayer(player);
            AddPlayer(player);
        }
        /// <summary>
        /// Odebere hráče z bludiště
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayer(PlayerController player)
        {
            graphics.FillRectangle(backgroundBrush, (player.OldPosition.Y + 1) * wallThickness + playerOffset, (player.OldPosition.X + 1) * wallThickness + playerOffset, wallThickness / playerScaleDown, wallThickness / playerScaleDown);
        }
        /// <summary>
        /// Přidá hráče do bludiště
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(PlayerController player)
        {
            SolidBrush playerBrush = new SolidBrush(player.PlayerColor);
            graphics.FillRectangle(playerBrush, (player.Position.Y + 1) * wallThickness + playerOffset, (player.Position.X + 1) * wallThickness + playerOffset, wallThickness / playerScaleDown, wallThickness / playerScaleDown);
        }

        /// <summary>
        /// Vytvoří základ bludiště
        /// Nastaví hodnoty na wallThickness a playerOffset aby odpovídali velikosti bludiště
        /// </summary>
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

        /// <summary>
        /// Vytvoří 4 základní zdi kolem bludiště
        /// </summary>
        private void CreateMazeWalls()
        {
            graphics.FillRectangle(wallBrush, 0, 0, wallThickness, height);
            graphics.FillRectangle(wallBrush, width - wallThickness, 0, wallThickness, height);
            graphics.FillRectangle(wallBrush, 0, 0, width, wallThickness);
            graphics.FillRectangle(wallBrush, 0, height - wallThickness, width, wallThickness);
        }

        /// <summary>
        /// Aktualizuje mapu bludiště
        /// </summary>
        public void Update()
        {
            if (!mazeGenerationInProgress)
                gameCanvas.Image = maze;
        }
        /// <summary>
        /// Přidá na pozici konec bludiště
        /// </summary>
        /// <param name="finish"></param>
        public void AddFinish(Point finish)
        {
            graphics.FillRectangle(finishBrush, (finish.Y + 1) * wallThickness, (finish.X + 1) * wallThickness, wallThickness, wallThickness);
        }

        public void SaveMazeToPicture()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                gameCanvas.Image.Save(sfd.FileName, format);
            }
        }
    }
}
