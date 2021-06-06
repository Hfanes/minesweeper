namespace minesweeper_lab.Views
{
    partial class MSFacil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSFacil));
            this.BTSair = new System.Windows.Forms.Button();
            this.labelFlags = new System.Windows.Forms.Label();
            this.labelTempo = new System.Windows.Forms.Label();
            this.BTPlay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNovoJogo = new System.Windows.Forms.Button();
            this.panelFacil = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificuldadeMédiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTSair
            // 
            this.BTSair.Location = new System.Drawing.Point(477, 377);
            this.BTSair.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTSair.Name = "BTSair";
            this.BTSair.Size = new System.Drawing.Size(101, 39);
            this.BTSair.TabIndex = 17;
            this.BTSair.Text = "Sair";
            this.BTSair.UseVisualStyleBackColor = true;
            this.BTSair.Click += new System.EventHandler(this.BTSair_Click);
            // 
            // labelFlags
            // 
            this.labelFlags.AutoSize = true;
            this.labelFlags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlags.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelFlags.Location = new System.Drawing.Point(565, 55);
            this.labelFlags.Name = "labelFlags";
            this.labelFlags.Size = new System.Drawing.Size(49, 34);
            this.labelFlags.TabIndex = 16;
            this.labelFlags.Text = "10";
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.Location = new System.Drawing.Point(555, 142);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(0, 17);
            this.labelTempo.TabIndex = 15;
            // 
            // BTPlay
            // 
            this.BTPlay.Location = new System.Drawing.Point(477, 208);
            this.BTPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTPlay.Name = "BTPlay";
            this.BTPlay.Size = new System.Drawing.Size(101, 52);
            this.BTPlay.TabIndex = 14;
            this.BTPlay.Text = "Jogar";
            this.BTPlay.UseVisualStyleBackColor = true;
            this.BTPlay.Click += new System.EventHandler(this.BTPlay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tempo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(459, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Flags";
            // 
            // BTNovoJogo
            // 
            this.BTNovoJogo.Location = new System.Drawing.Point(477, 294);
            this.BTNovoJogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTNovoJogo.Name = "BTNovoJogo";
            this.BTNovoJogo.Size = new System.Drawing.Size(101, 52);
            this.BTNovoJogo.TabIndex = 11;
            this.BTNovoJogo.Text = "Novo Jogo";
            this.BTNovoJogo.UseVisualStyleBackColor = true;
            this.BTNovoJogo.Click += new System.EventHandler(this.BTNovoJogo_Click);
            this.BTNovoJogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNovoJogo_MouseUp);
            // 
            // panelFacil
            // 
            this.panelFacil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelFacil.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelFacil.Location = new System.Drawing.Point(12, 44);
            this.panelFacil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFacil.Name = "panelFacil";
            this.panelFacil.Size = new System.Drawing.Size(417, 385);
            this.panelFacil.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.dificuldadeMédiaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(660, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.MenuToolStripMenuItem.Text = "Menu";
            this.MenuToolStripMenuItem.Click += new System.EventHandler(this.definiçõesToolStripMenuItem_Click);
            // 
            // dificuldadeMédiaToolStripMenuItem
            // 
            this.dificuldadeMédiaToolStripMenuItem.Name = "dificuldadeMédiaToolStripMenuItem";
            this.dificuldadeMédiaToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.dificuldadeMédiaToolStripMenuItem.Text = "Dificuldade: Média";
            this.dificuldadeMédiaToolStripMenuItem.Click += new System.EventHandler(this.dificuldadeMédiaToolStripMenuItem_Click);
            // 
            // MSFacil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(660, 441);
            this.Controls.Add(this.BTSair);
            this.Controls.Add(this.labelFlags);
            this.Controls.Add(this.labelTempo);
            this.Controls.Add(this.BTPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNovoJogo);
            this.Controls.Add(this.panelFacil);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MSFacil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTSair;
        public System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.Button BTPlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNovoJogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dificuldadeMédiaToolStripMenuItem;
        public System.Windows.Forms.Panel panelFacil;
        public System.Windows.Forms.Label labelFlags;
    }
}