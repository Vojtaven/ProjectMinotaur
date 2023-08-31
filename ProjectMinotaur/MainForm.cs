using System.Drawing;

namespace ProjectMinotaur
{
    public partial class MainForm : Form
    {
        private const int topPanelPx = 39;
        private const int gameCanvasPadding = 20;
        private GraphicsManager graphicsManager;
        private GameManager gameManager;

        //private MazeManager mazeManager;
        //private PlayerController playerController;
        //private bool[,] testMaze = { {true,false,false, false },{false,false,false, false },{true,false,true, false }, { false, false, false,true } };
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormatWindows();

            graphicsManager = new GraphicsManager(GameCanvas);
            gameManager = new GameManager(graphicsManager, algoritmChoiceCB, mazeSizeNUP);

            //Test code
            //graphicsManager.CreateMazeBase(new int[] { 50,50   });
            //graphicsManager.CreateMazeFromMap(testMaze);
            //graphicsManager.PlayerPosition = new Point(0, 0);
            //graphicsManager.AddWallPiece(new Point(0, 1));
            //graphicsManager.AddWallPiece(new Point(1, 0));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            graphicsManager.Update();
        }


        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            gameManager.KeyPressed(e);
        }

        private void generateBt_Click(object sender, EventArgs e)
        {
            gameManager.GenerateMaze();
        }

        private void FormatWindows()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            GameCanvas.Height = this.Height - topPanelPx - gameCanvasPadding * 2;
            GameCanvas.Width = GameCanvas.Height;
            GameCanvas.Location = new Point((this.Width - GameCanvas.Width) / 2 + gameCanvasPadding, gameCanvasPadding);

        }

        private void algoritmChoiceCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}