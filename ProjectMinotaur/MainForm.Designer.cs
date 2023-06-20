namespace ProjectMinotaur
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gameTimer = new System.Windows.Forms.Timer(components);
            GameCanvas = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)GameCanvas).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 15;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // GameCanvas
            // 
            GameCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            GameCanvas.BackColor = SystemColors.WindowFrame;
            GameCanvas.Location = new Point(141, 0);
            GameCanvas.Margin = new Padding(4, 5, 4, 5);
            GameCanvas.Name = "GameCanvas";
            GameCanvas.Size = new Size(643, 600);
            GameCanvas.TabIndex = 0;
            GameCanvas.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(964, 600);
            Controls.Add(GameCanvas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Project Minotaur";
            Load += MainForm_Load;
            KeyUp += MainForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)GameCanvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private PictureBox GameCanvas;
    }
}