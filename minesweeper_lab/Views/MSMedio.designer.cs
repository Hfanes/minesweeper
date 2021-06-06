namespace minesweeper_lab
{
    partial class Medio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Medio));
            this.BTMJogar = new System.Windows.Forms.Button();
            this.BTMNovojogo = new System.Windows.Forms.Button();
            this.BTMSair = new System.Windows.Forms.Button();
            this.panelMedio = new System.Windows.Forms.Panel();
            this.LBMFlags = new System.Windows.Forms.Label();
            this.labelFlagsMedio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MSmedio = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificuladadeMédioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LBTMedio = new System.Windows.Forms.Label();
            this.MSmedio.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTMJogar
            // 
            this.BTMJogar.Location = new System.Drawing.Point(624, 245);
            this.BTMJogar.Margin = new System.Windows.Forms.Padding(4);
            this.BTMJogar.Name = "BTMJogar";
            this.BTMJogar.Size = new System.Drawing.Size(124, 50);
            this.BTMJogar.TabIndex = 0;
            this.BTMJogar.Text = "Jogar";
            this.BTMJogar.UseVisualStyleBackColor = true;
            this.BTMJogar.Click += new System.EventHandler(this.BTMJogar_Click);
            // 
            // BTMNovojogo
            // 
            this.BTMNovojogo.Location = new System.Drawing.Point(624, 354);
            this.BTMNovojogo.Margin = new System.Windows.Forms.Padding(4);
            this.BTMNovojogo.Name = "BTMNovojogo";
            this.BTMNovojogo.Size = new System.Drawing.Size(124, 44);
            this.BTMNovojogo.TabIndex = 1;
            this.BTMNovojogo.Text = "Novo Jogo";
            this.BTMNovojogo.UseVisualStyleBackColor = true;
            this.BTMNovojogo.Click += new System.EventHandler(this.BTMNovojogo_Click);
            this.BTMNovojogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNovoJogo_MouseUp);
            // 
            // BTMSair
            // 
            this.BTMSair.Location = new System.Drawing.Point(624, 455);
            this.BTMSair.Margin = new System.Windows.Forms.Padding(4);
            this.BTMSair.Name = "BTMSair";
            this.BTMSair.Size = new System.Drawing.Size(124, 43);
            this.BTMSair.TabIndex = 2;
            this.BTMSair.Text = "Sair";
            this.BTMSair.UseVisualStyleBackColor = true;
            this.BTMSair.Click += new System.EventHandler(this.BTMSair_Click);
            // 
            // panelMedio
            // 
            this.panelMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelMedio.Location = new System.Drawing.Point(17, 84);
            this.panelMedio.Margin = new System.Windows.Forms.Padding(4);
            this.panelMedio.Name = "panelMedio";
            this.panelMedio.Size = new System.Drawing.Size(552, 484);
            this.panelMedio.TabIndex = 3;
            // 
            // LBMFlags
            // 
            this.LBMFlags.AutoSize = true;
            this.LBMFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMFlags.Location = new System.Drawing.Point(592, 48);
            this.LBMFlags.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBMFlags.Name = "LBMFlags";
            this.LBMFlags.Size = new System.Drawing.Size(79, 29);
            this.LBMFlags.TabIndex = 4;
            this.LBMFlags.Text = "Flags:";
            // 
            // labelFlagsMedio
            // 
            this.labelFlagsMedio.AutoSize = true;
            this.labelFlagsMedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFlagsMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlagsMedio.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelFlagsMedio.Location = new System.Drawing.Point(689, 48);
            this.labelFlagsMedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFlagsMedio.Name = "labelFlagsMedio";
            this.labelFlagsMedio.Size = new System.Drawing.Size(49, 35);
            this.labelFlagsMedio.TabIndex = 5;
            this.labelFlagsMedio.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(592, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tempo:";
            // 
            // MSmedio
            // 
            this.MSmedio.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MSmedio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.dificuladadeMédioToolStripMenuItem});
            this.MSmedio.Location = new System.Drawing.Point(0, 0);
            this.MSmedio.Name = "MSmedio";
            this.MSmedio.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MSmedio.Size = new System.Drawing.Size(820, 28);
            this.MSmedio.TabIndex = 7;
            this.MSmedio.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // dificuladadeMédioToolStripMenuItem
            // 
            this.dificuladadeMédioToolStripMenuItem.Name = "dificuladadeMédioToolStripMenuItem";
            this.dificuladadeMédioToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.dificuladadeMédioToolStripMenuItem.Text = "Dificuladade:Fácil";
            this.dificuladadeMédioToolStripMenuItem.Click += new System.EventHandler(this.dificuladadeMédioToolStripMenuItem_Click);
            // 
            // LBTMedio
            // 
            this.LBTMedio.AutoSize = true;
            this.LBTMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTMedio.Location = new System.Drawing.Point(709, 127);
            this.LBTMedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBTMedio.Name = "LBTMedio";
            this.LBTMedio.Size = new System.Drawing.Size(0, 25);
            this.LBTMedio.TabIndex = 8;
            // 
            // Medio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(820, 583);
            this.Controls.Add(this.LBTMedio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFlagsMedio);
            this.Controls.Add(this.LBMFlags);
            this.Controls.Add(this.panelMedio);
            this.Controls.Add(this.BTMSair);
            this.Controls.Add(this.BTMNovojogo);
            this.Controls.Add(this.BTMJogar);
            this.Controls.Add(this.MSmedio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MSmedio;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Medio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.MSmedio.ResumeLayout(false);
            this.MSmedio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTMJogar;
        private System.Windows.Forms.Button BTMNovojogo;
        private System.Windows.Forms.Button BTMSair;
        private System.Windows.Forms.Label LBMFlags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip MSmedio;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        public System.Windows.Forms.Label LBTMedio;
        public System.Windows.Forms.Panel panelMedio;
        public System.Windows.Forms.Label labelFlagsMedio;
        private System.Windows.Forms.ToolStripMenuItem dificuladadeMédioToolStripMenuItem;
    }
}