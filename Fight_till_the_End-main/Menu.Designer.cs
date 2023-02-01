namespace Fight_til_the_End
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
            this.lbl_intro = new System.Windows.Forms.Label();
            this.lbl_how = new System.Windows.Forms.Label();
            this.btn_how = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.spiderman = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spiderman)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_intro
            // 
            this.lbl_intro.AutoSize = true;
            this.lbl_intro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_intro.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_intro.ForeColor = System.Drawing.Color.White;
            this.lbl_intro.Location = new System.Drawing.Point(68, 179);
            this.lbl_intro.Name = "lbl_intro";
            this.lbl_intro.Size = new System.Drawing.Size(455, 120);
            this.lbl_intro.TabIndex = 0;
            this.lbl_intro.Text = "遊戲介紹:\r\n此遊戲為 2P，一個是蜘蛛人，一個是綠魔\r\n雙方必須在時間結束前想盡辦法取得寶物\r\n時間一到持有寶物的人為贏家\r\n";
            // 
            // lbl_how
            // 
            this.lbl_how.AutoSize = true;
            this.lbl_how.BackColor = System.Drawing.Color.Transparent;
            this.lbl_how.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_how.ForeColor = System.Drawing.Color.White;
            this.lbl_how.Location = new System.Drawing.Point(68, 338);
            this.lbl_how.Name = "lbl_how";
            this.lbl_how.Size = new System.Drawing.Size(413, 60);
            this.lbl_how.TabIndex = 1;
            this.lbl_how.Text = "道具使用:\r\n有兩種道具(增加時間、增加子彈數量)\r\n";
            // 
            // btn_how
            // 
            this.btn_how.Font = new System.Drawing.Font("jf open 粉圓 1.1", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_how.Location = new System.Drawing.Point(206, 466);
            this.btn_how.Name = "btn_how";
            this.btn_how.Size = new System.Drawing.Size(146, 54);
            this.btn_how.TabIndex = 2;
            this.btn_how.Text = "遊戲玩法";
            this.btn_how.UseVisualStyleBackColor = true;
            this.btn_how.Click += new System.EventHandler(this.btn_how_Click);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("jf open 粉圓 1.1", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_start.Location = new System.Drawing.Point(206, 327);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(146, 54);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "開始遊戲";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // spiderman
            // 
            this.spiderman.BackColor = System.Drawing.Color.Transparent;
            this.spiderman.Image = global::Fight_til_the_End.Properties.Resources.spiderman_hanging;
            this.spiderman.Location = new System.Drawing.Point(12, 110);
            this.spiderman.Name = "spiderman";
            this.spiderman.Size = new System.Drawing.Size(140, 225);
            this.spiderman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spiderman.TabIndex = 4;
            this.spiderman.TabStop = false;
            // 
            // Menu
            // 
            this.BackgroundImage = global::Fight_til_the_End.Properties.Resources.start_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(561, 590);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_how);
            this.Controls.Add(this.lbl_how);
            this.Controls.Add(this.lbl_intro);
            this.Controls.Add(this.spiderman);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spiderman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_intro;
        private System.Windows.Forms.Label lbl_how;
        private System.Windows.Forms.Button btn_how;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.PictureBox spiderman;
    }
}