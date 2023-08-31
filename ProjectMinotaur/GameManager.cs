using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMinotaur
{
    internal class GameManager
    {
        private MazeManager mazeManager;
        private PlayerController player;

        public GameManager(GraphicsManager graphicsManager,ComboBox algorimChoiceCB, NumericUpDown mazeSizeNUP)
        {
            mazeManager = new MazeManager(graphicsManager, algorimChoiceCB, mazeSizeNUP);
            player = new PlayerController(graphicsManager,mazeManager);
        }



        public void GenerateMaze()
        {
            mazeManager.CreateMaze();
            player.Reset();
        }

        public void KeyPressed(KeyEventArgs e)
        {
            player.KeyPressed(e);
        }
    }
}
