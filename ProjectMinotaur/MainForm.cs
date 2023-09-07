using System.Drawing;

namespace ProjectMinotaur
{
    public partial class MainForm : Form
    {
        private const int topPanelPx = 39;
        private const int gameCanvasPadding = 20;
        private GraphicsManager graphicsManager;
        private GameManager gameManager;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormatWindows();

            graphicsManager = new GraphicsManager(GameCanvas);
            gameManager = new GameManager(graphicsManager, algoritmChoiceCB, mazeSizeNUP);
        }
        /// <summary>
        /// Tick timeru na update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            graphicsManager.Update();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            gameManager.KeyPressed(e);
        }
        /// <summary>
        /// Stisknutí tlaèítka na generování bludištì
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateBt_Click(object sender, EventArgs e)
        {
            gameManager.GenerateMaze();
        }
        /// <summary>
        /// Roztáhne okno na celou obrazovku
        /// </summary>
        private void FormatWindows()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            GameCanvas.Height = this.Height - topPanelPx - gameCanvasPadding * 2;
            GameCanvas.Width = GameCanvas.Height;
            GameCanvas.Location = new Point((this.Width - GameCanvas.Width) / 2 + gameCanvasPadding, gameCanvasPadding);

        }
        /// <summary>
        /// Zabránìní psaní do Choice boxu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void algoritmChoiceCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void saveMazeBt_Click(object sender, EventArgs e)
        {
            graphicsManager.SaveMazeToPicture();
        }
    }
}