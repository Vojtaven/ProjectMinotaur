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
            label3 = new Label();
            settingsGB = new GroupBox();
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
            GameCanvas.Location = new Point(249, 0);
            GameCanvas.Name = "GameCanvas";
            GameCanvas.Size = new Size(450, 542);
            GameCanvas.TabIndex = 0;
            GameCanvas.TabStop = false;
            // 
            // generateBt
            // 
            generateBt.AllowDrop = true;
            generateBt.Location = new Point(10, 62);
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
            algoritmChoiceCB.Dock = DockStyle.Left;
            algoritmChoiceCB.DropDownStyle = ComboBoxStyle.DropDownList;
            algoritmChoiceCB.FormattingEnabled = true;
            algoritmChoiceCB.Location = new Point(2, 18);
            algoritmChoiceCB.Margin = new Padding(2);
            algoritmChoiceCB.Name = "algoritmChoiceCB";
            algoritmChoiceCB.Size = new Size(129, 23);
            algoritmChoiceCB.TabIndex = 2;
            algoritmChoiceCB.UseWaitCursor = true;
            // 
            // mazeSizeNUP
            // 
            mazeSizeNUP.AllowDrop = true;
            mazeSizeNUP.Location = new Point(0, 159);
            mazeSizeNUP.Margin = new Padding(70, 60, 70, 60);
            mazeSizeNUP.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            mazeSizeNUP.Name = "mazeSizeNUP";
            mazeSizeNUP.Size = new Size(126, 23);
            mazeSizeNUP.TabIndex = 3;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 104);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // settingsGB
            // 
            settingsGB.Controls.Add(mazeSizeNUP);
            settingsGB.Controls.Add(label3);
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
            KeyUp += MainForm_KeyUp;
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
        private Label label3;
        private GroupBox settingsGB;
    }
}