using System;
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
        public PlayerController(GraphicsManager graphicsManager, MazeManager mazeManager)
        {
            this.graphicsManager = graphicsManager;
            this.mazeManager = mazeManager;
            playerPosition = new Point(0,0);
        }

        public void keyPressed(KeyEventArgs e)
        {
            int xModifier= 0,yModifier=0;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    xModifier = -1;
                    break;
                case Keys.Down:
                    xModifier = 1;
                    break;
                case Keys.Left:
                    yModifier = -1;
                    break;
                case Keys.Right:
                        yModifier = 1;
                    break;
            }
            Point newPlayerPosition = new Point(playerPosition.X + xModifier,playerPosition.Y+yModifier);

            if (mazeManager.IsFree(newPlayerPosition))
            {
                playerPosition = newPlayerPosition;
                graphicsManager.PlayerPosition = newPlayerPosition;
            }
        }
    }
}
