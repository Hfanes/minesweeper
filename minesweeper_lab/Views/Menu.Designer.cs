namespace minesweeper_lab
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.CBDificuldade = new System.Windows.Forms.ComboBox();
            this.BTJogar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.carregarJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarContaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaderboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPerfisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dificuldade:";
            // 
            // CBDificuldade
            // 
            this.CBDificuldade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDificuldade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBDificuldade.FormattingEnabled = true;
            this.CBDificuldade.Items.AddRange(new object[] {
            "Fácil",
            "Médio"});
            this.CBDificuldade.Location = new System.Drawing.Point(176, 231);
            this.CBDificuldade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBDificuldade.Name = "CBDificuldade";
            this.CBDificuldade.Size = new System.Drawing.Size(139, 26);
            this.CBDificuldade.TabIndex = 5;
            // 
            // BTJogar
            // 
            this.BTJogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTJogar.Location = new System.Drawing.Point(153, 302);
            this.BTJogar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTJogar.Name = "BTJogar";
            this.BTJogar.Size = new System.Drawing.Size(100, 28);
            this.BTJogar.TabIndex = 4;
            this.BTJogar.Text = "Jogar";
            this.BTJogar.UseVisualStyleBackColor = true;
            this.BTJogar.Click += new System.EventHandler(this.BTJogar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarJogoToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.jogoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(427, 30);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // carregarJogoToolStripMenuItem
            // 
            this.carregarJogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarContaToolStripMenuItem,
            this.LeaderboardToolStripMenuItem,
            this.LoginToolStripMenuItem1,
            this.consultarPerfisToolStripMenuItem});
            this.carregarJogoToolStripMenuItem.Name = "carregarJogoToolStripMenuItem";
            this.carregarJogoToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.carregarJogoToolStripMenuItem.Text = "&Jogo";
            // 
            // criarContaToolStripMenuItem
            // 
            this.criarContaToolStripMenuItem.Name = "criarContaToolStripMenuItem";
            this.criarContaToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.criarContaToolStripMenuItem.Text = "Criar Conta";
            this.criarContaToolStripMenuItem.Click += new System.EventHandler(this.criarContaToolStripMenuItem_Click);
            // 
            // LeaderboardToolStripMenuItem
            // 
            this.LeaderboardToolStripMenuItem.Name = "LeaderboardToolStripMenuItem";
            this.LeaderboardToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.LeaderboardToolStripMenuItem.Text = "LeaderBoard";
            this.LeaderboardToolStripMenuItem.Click += new System.EventHandler(this.leaderBoardToolStripMenuItem_Click);
            // 
            // LoginToolStripMenuItem1
            // 
            this.LoginToolStripMenuItem1.Name = "LoginToolStripMenuItem1";
            this.LoginToolStripMenuItem1.Size = new System.Drawing.Size(193, 26);
            this.LoginToolStripMenuItem1.Text = "Login";
            this.LoginToolStripMenuItem1.Click += new System.EventHandler(this.LoginToolStripMenuItem1_Click);
            // 
            // consultarPerfisToolStripMenuItem
            // 
            this.consultarPerfisToolStripMenuItem.Name = "consultarPerfisToolStripMenuItem";
            this.consultarPerfisToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.consultarPerfisToolStripMenuItem.Text = "Consultar Perfis";
            this.consultarPerfisToolStripMenuItem.Click += new System.EventHandler(this.consultarPerfisToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // jogoToolStripMenuItem
            // 
            this.jogoToolStripMenuItem.Name = "jogoToolStripMenuItem";
            this.jogoToolStripMenuItem.Size = new System.Drawing.Size(48, 26);
            this.jogoToolStripMenuItem.Text = "Sair";
            this.jogoToolStripMenuItem.Click += new System.EventHandler(this.jogoToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Luís Ribeiro Hugo Anes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::minesweeper_lab.Properties.Resources.logo_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(16, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 185);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 11;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(427, 363);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBDificuldade);
            this.Controls.Add(this.BTJogar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBDificuldade;
        private System.Windows.Forms.Button BTJogar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarJogoToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem LoginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LeaderboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarContaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarPerfisToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}

