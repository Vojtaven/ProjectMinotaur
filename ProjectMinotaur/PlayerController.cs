﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMinotaur
{
    internal class PlayerController
    {
        private GraphicsManager graphicsManager;
        private MazeManager mazeManager;
        private Point playerPosition;
        private Point oldPlayerPosition;
        private Color playerColor = Color.LimeGreen;

        //private List<Keys> keysPressed = new List<Keys>();


        public PlayerController(GraphicsManager graphicsManager, MazeManager mazeManager)
        {
            this.graphicsManager = graphicsManager;
            this.mazeManager = mazeManager;
            playerPosition = new Point(0, 0);
            graphicsManager.AddPlayer(this);
        }

        /// <summary>
        /// Zkontroluje, že při změně je políčko volné
        /// </summary>
        public Point Position
        {
            get { return playerPosition; }
            set
            {
                if (mazeManager.IsFree(value))
                {
                    oldPlayerPosition = playerPosition;
                    playerPosition = value;
                    graphicsManager.ChangePlayerPosition(this);
                }
                else
                {
                    throw new ArgumentException("No valid position");
                }
            }
        }
        public Point OldPosition { get { return oldPlayerPosition; } }
        public Color PlayerColor { get { return playerColor; } }

        /// <summary>
        /// Vrátí hráče na původní pozici
        /// </summary>
        public void Reset()
        {
            playerPosition = new Point(0, 0);
            graphicsManager.AddPlayer(this);
        }

        public void KeyPressed(KeyEventArgs e)
        {
            MovePlayer(e.KeyCode);
        }
        /// <summary>
        /// Zkontroluje, která klávesa byla stlačena a popřípadě hýbne hráčem
        /// </summary>
        /// <param name="key"></param>
        private void MovePlayer(Keys key)
        {

            //Rozhodne o nové pozici
            int xModifier = 0, yModifier = 0;
            switch (key)
            {
                case Keys.W:

                    xModifier = -1;
                    break;
                case Keys.S:

                    xModifier = 1;
                    break;
                case Keys.A:

                    yModifier = -1;
                    break;
                case Keys.D:

                    yModifier = 1;
                    break;
                default:
                    return;
            }
            Point newPlayerPosition = new Point(playerPosition.X + xModifier, playerPosition.Y + yModifier);

            //Zkontroluje zda pozice je volná
            if (mazeManager.IsFree(newPlayerPosition))
            {
                oldPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
                graphicsManager.ChangePlayerPosition(this);

                //Zkontroluje zda hráč nevyhrál
                if (mazeManager.IsFinnish(newPlayerPosition))
                {
                    MessageBox.Show("You win! :)");
                }
            }
        }

    }
}
