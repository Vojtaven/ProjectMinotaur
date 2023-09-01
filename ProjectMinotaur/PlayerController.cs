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
        private List<Keys> controls = new List<Keys>{Keys.W,Keys.S,Keys.A,Keys.D };
       
        //private List<Keys> keysPressed = new List<Keys>();


        public PlayerController(GraphicsManager graphicsManager, MazeManager mazeManager)
        {
            this.graphicsManager = graphicsManager;
            this.mazeManager = mazeManager;
            playerPosition = new Point(0,0);
            graphicsManager.AddPlayer(this);
        }

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
                    throw new ArgumentException("Now valid position");
                }
            }
        }
        public Point OldPosition { get { return oldPlayerPosition; } }
        public Color PlayerColor { get {  return playerColor; } }


        public void Reset()
        {
            playerPosition = new Point(0, 0);
            graphicsManager.AddPlayer(this);
        }
        public void KeyPressed(KeyEventArgs e)
        {
            MovePlayer(e.KeyCode);
        }
        private void MovePlayer(Keys key)
        {
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
            }
            Point newPlayerPosition = new Point(playerPosition.X + xModifier, playerPosition.Y + yModifier);

            if (mazeManager.IsFree(newPlayerPosition))
            {
                oldPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
                graphicsManager.ChangePlayerPosition(this);
            }
        }

    }
}
