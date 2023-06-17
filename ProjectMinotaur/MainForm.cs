using System.Drawing;

namespace ProjectMinotaur
{
    public partial class MainForm : Form
    {
        private const int topPanelPx = 39;
        private const int gameCanvasPadding = 20;
        GraphicsManager graphicsManager;
        int[,] mazeMap = new int[10, 10];
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            GameCanvas.Height = this.Height - topPanelPx - gameCanvasPadding * 2;
            GameCanvas.Width = GameCanvas.Height;
            GameCanvas.Location = new Point((this.Width - GameCanvas.Width) / 2 + gameCanvasPadding, gameCanvasPadding);
            graphicsManager = new GraphicsManager(GameCanvas);
            graphicsManager.CreateMaze(new int[] { 500,500   });
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            graphicsManager.Update();
        }
    }
}