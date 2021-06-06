namespace minesweeper_lab.Views
{
    partial class UserRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRequest));
            this.label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.WonLabel = new System.Windows.Forms.Label();
            this.MenuBTN = new System.Windows.Forms.Button();
            this.ReplayBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(112, 90);
            this.UserName.Margin = new System.Windows.Forms.Padding(2);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(155, 24);
            this.UserName.TabIndex = 2;
            // 
            // WonLabel
            // 
            this.WonLabel.AutoSize = true;
            this.WonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WonLabel.Location = new System.Drawing.Point(11, 9);
            this.WonLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WonLabel.Name = "WonLabel";
            this.WonLabel.Size = new System.Drawing.Size(105, 48);
            this.WonLabel.TabIndex = 3;
            this.WonLabel.Text = "Ganhaste!!!\r\nTempo:\r\n";
            // 
            // MenuBTN
            // 
            this.MenuBTN.Location = new System.Drawing.Point(15, 142);
            this.MenuBTN.Name = "MenuBTN";
            this.MenuBTN.Size = new System.Drawing.Size(101, 32);
            this.MenuBTN.TabIndex = 4;
            this.MenuBTN.Text = "Menu";
            this.MenuBTN.UseVisualStyleBackColor = true;
            // 
            // ReplayBTN
            // 
            this.ReplayBTN.Location = new System.Drawing.Point(166, 142);
            this.ReplayBTN.Name = "ReplayBTN";
            this.ReplayBTN.Size = new System.Drawing.Size(101, 32);
            this.ReplayBTN.TabIndex = 5;
            this.ReplayBTN.Text = "Voltar a Jogar";
            this.ReplayBTN.UseVisualStyleBackColor = true;
            // 
            // UserRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(288, 196);
            this.Controls.Add(this.ReplayBTN);
            this.Controls.Add(this.MenuBTN);
            this.Controls.Add(this.WonLabel);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ganhas-te";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label WonLabel;
        public System.Windows.Forms.Button MenuBTN;
        public System.Windows.Forms.Button ReplayBTN;
        public System.Windows.Forms.TextBox UserName;
        public System.Windows.Forms.Label label1;
    }
}