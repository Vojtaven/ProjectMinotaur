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
            generateBt = new Button();
            algoritmChoiceCB = new ComboBox();
            mazeSizeNUP = new NumericUpDown();
            label2 = new Label();
            algoritmChoiceLB = new Label();
            settingsGB = new GroupBox();
            mazeSizeLB = new Label();
            ((System.ComponentModel.ISupportInitialize)GameCanvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mazeSizeNUP).BeginInit();
            settingsGB.SuspendLayout();
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
            GameCanvas.BackColor = SystemColors.InfoText;
            GameCanvas.Location = new Point(244, 0);
            GameCanvas.Name = "GameCanvas";
            GameCanvas.Size = new Size(450, 542);
            GameCanvas.TabIndex = 0;
            GameCanvas.TabStop = false;
            // 
            // generateBt
            // 
            generateBt.AllowDrop = true;
            generateBt.Location = new Point(10, 120);
            generateBt.Margin = new Padding(2);
            generateBt.Name = "generateBt";
            generateBt.Size = new Size(78, 20);
            generateBt.TabIndex = 1;
            generateBt.Text = "Generate";
            generateBt.UseVisualStyleBackColor = true;
            generateBt.UseWaitCursor = true;
            generateBt.Click += generateBt_Click;
            // 
            // algoritmChoiceCB
            // 
            algoritmChoiceCB.AllowDrop = true;
            algoritmChoiceCB.FormattingEnabled = true;
            algoritmChoiceCB.Location = new Point(7, 35);
            algoritmChoiceCB.Margin = new Padding(2);
            algoritmChoiceCB.Name = "algoritmChoiceCB";
            algoritmChoiceCB.Size = new Size(129, 23);
            algoritmChoiceCB.TabIndex = 2;
            algoritmChoiceCB.UseWaitCursor = true;
            // 
            // mazeSizeNUP
            // 
            mazeSizeNUP.AllowDrop = true;
            mazeSizeNUP.Location = new Point(10, 81);
            mazeSizeNUP.Margin = new Padding(70, 60, 70, 60);
            mazeSizeNUP.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            mazeSizeNUP.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            mazeSizeNUP.Name = "mazeSizeNUP";
            mazeSizeNUP.Size = new Size(126, 23);
            mazeSizeNUP.TabIndex = 3;
            mazeSizeNUP.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 89);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 5;
            // 
            // algoritmChoiceLB
            // 
            algoritmChoiceLB.AutoSize = true;
            algoritmChoiceLB.Location = new Point(7, 18);
            algoritmChoiceLB.Margin = new Padding(2, 0, 2, 0);
            algoritmChoiceLB.Name = "algoritmChoiceLB";
            algoritmChoiceLB.Size = new Size(94, 15);
            algoritmChoiceLB.TabIndex = 6;
            algoritmChoiceLB.Text = "Algoritm Choice";
            // 
            // settingsGB
            // 
            settingsGB.Controls.Add(mazeSizeLB);
            settingsGB.Controls.Add(mazeSizeNUP);
            settingsGB.Controls.Add(algoritmChoiceLB);
            settingsGB.Controls.Add(algoritmChoiceCB);
            settingsGB.Controls.Add(generateBt);
            settingsGB.Dock = DockStyle.Left;
            settingsGB.Location = new Point(0, 0);
            settingsGB.Margin = new Padding(70, 2, 2, 2);
            settingsGB.Name = "settingsGB";
            settingsGB.Padding = new Padding(2);
            settingsGB.Size = new Size(157, 542);
            settingsGB.TabIndex = 7;
            settingsGB.TabStop = false;
            settingsGB.Text = "Settings";
            // 
            // mazeSizeLB
            // 
            mazeSizeLB.AutoSize = true;
            mazeSizeLB.Location = new Point(7, 60);
            mazeSizeLB.Margin = new Padding(2, 0, 2, 0);
            mazeSizeLB.Name = "mazeSizeLB";
            mazeSizeLB.Size = new Size(58, 15);
            mazeSizeLB.TabIndex = 7;
            mazeSizeLB.Text = "Maze Size";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(976, 542);
            Controls.Add(settingsGB);
            Controls.Add(label2);
            Controls.Add(GameCanvas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MainForm";
            Text = "Project Minotaur";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)GameCanvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)mazeSizeNUP).EndInit();
            settingsGB.ResumeLayout(false);
            settingsGB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private PictureBox GameCanvas;
        private Button generateBt;
        private ComboBox algoritmChoiceCB;
        private NumericUpDown mazeSizeNUP;
        private Label label2;
        private Label algoritmChoiceLB;
        private GroupBox settingsGB;
        private Label mazeSizeLB;
    }
}