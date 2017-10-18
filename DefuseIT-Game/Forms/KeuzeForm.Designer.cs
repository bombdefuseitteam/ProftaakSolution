namespace DefuseIT_Game
{
    partial class KeuzeScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeuzeScherm));
            this.ControllerStatus = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.CloseApplication = new System.Windows.Forms.Button();
            this.RestartGame = new System.Windows.Forms.Label();
            this.Refresh = new System.Windows.Forms.PictureBox();
            this.SocketStatus = new System.Windows.Forms.PictureBox();
            this.VraagLabel = new System.Windows.Forms.Label();
            this.AntwoordABox = new System.Windows.Forms.PictureBox();
            this.AntwoordCBox = new System.Windows.Forms.PictureBox();
            this.AntwoordBBox = new System.Windows.Forms.PictureBox();
            this.AntwoordDBox = new System.Windows.Forms.PictureBox();
            this.AntwoordLabelA = new System.Windows.Forms.Label();
            this.AntwoordLabelB = new System.Windows.Forms.Label();
            this.AntwoordLabelC = new System.Windows.Forms.Label();
            this.AntwoordLabelD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SocketStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordBBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordDBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ControllerStatus
            // 
            this.ControllerStatus.Image = global::DefuseIT_Game.Properties.Resources.Controller_icon_NOT_CONNECTED;
            this.ControllerStatus.Location = new System.Drawing.Point(1844, 1011);
            this.ControllerStatus.Name = "ControllerStatus";
            this.ControllerStatus.Size = new System.Drawing.Size(63, 62);
            this.ControllerStatus.TabIndex = 7;
            this.ControllerStatus.TabStop = false;
            // 
            // Maximize
            // 
            this.Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Maximize.BackgroundImage = global::DefuseIT_Game.Properties.Resources.background;
            this.Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Maximize.Font = new System.Drawing.Font("Back In The USSR DL", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Maximize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Maximize.Location = new System.Drawing.Point(1834, 6);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(37, 33);
            this.Maximize.TabIndex = 6;
            this.Maximize.Text = "🗖 ";
            this.Maximize.UseVisualStyleBackColor = false;
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Minimize.BackgroundImage = global::DefuseIT_Game.Properties.Resources.background;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Back In The USSR DL", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.Location = new System.Drawing.Point(1791, 6);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(37, 33);
            this.Minimize.TabIndex = 5;
            this.Minimize.Text = "_";
            this.Minimize.UseVisualStyleBackColor = false;
            // 
            // CloseApplication
            // 
            this.CloseApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseApplication.BackgroundImage = global::DefuseIT_Game.Properties.Resources.background;
            this.CloseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseApplication.Font = new System.Drawing.Font("Back In The USSR DL", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseApplication.Location = new System.Drawing.Point(1877, 7);
            this.CloseApplication.Name = "CloseApplication";
            this.CloseApplication.Size = new System.Drawing.Size(37, 33);
            this.CloseApplication.TabIndex = 4;
            this.CloseApplication.Text = "X";
            this.CloseApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CloseApplication.UseVisualStyleBackColor = false;
            this.CloseApplication.Click += new System.EventHandler(this.CloseApplication_Click);
            // 
            // RestartGame
            // 
            this.RestartGame.AutoSize = true;
            this.RestartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RestartGame.Font = new System.Drawing.Font("Back In The USSR DL", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartGame.Image = global::DefuseIT_Game.Properties.Resources.background;
            this.RestartGame.Location = new System.Drawing.Point(12, 10);
            this.RestartGame.Name = "RestartGame";
            this.RestartGame.Size = new System.Drawing.Size(111, 23);
            this.RestartGame.TabIndex = 2;
            this.RestartGame.Text = "DefuseIT";
            this.RestartGame.Click += new System.EventHandler(this.RestartGame_Click);
            // 
            // Refresh
            // 
            this.Refresh.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Refresh.ErrorImage")));
            this.Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Refresh.Image")));
            this.Refresh.Location = new System.Drawing.Point(0, 0);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(1920, 1080);
            this.Refresh.TabIndex = 0;
            this.Refresh.TabStop = false;
            // 
            // SocketStatus
            // 
            this.SocketStatus.Image = global::DefuseIT_Game.Properties.Resources.WiFi_Not;
            this.SocketStatus.Location = new System.Drawing.Point(1775, 1011);
            this.SocketStatus.Name = "SocketStatus";
            this.SocketStatus.Size = new System.Drawing.Size(63, 62);
            this.SocketStatus.TabIndex = 9;
            this.SocketStatus.TabStop = false;
            // 
            // VraagLabel
            // 
            this.VraagLabel.AutoSize = true;
            this.VraagLabel.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VraagLabel.Location = new System.Drawing.Point(395, 319);
            this.VraagLabel.Name = "VraagLabel";
            this.VraagLabel.Size = new System.Drawing.Size(1139, 72);
            this.VraagLabel.TabIndex = 10;
            this.VraagLabel.Text = "Wie is de uitvinder van Windows?";
            // 
            // AntwoordABox
            // 
            this.AntwoordABox.Image = ((System.Drawing.Image)(resources.GetObject("AntwoordABox.Image")));
            this.AntwoordABox.Location = new System.Drawing.Point(323, 457);
            this.AntwoordABox.Name = "AntwoordABox";
            this.AntwoordABox.Size = new System.Drawing.Size(608, 133);
            this.AntwoordABox.TabIndex = 11;
            this.AntwoordABox.TabStop = false;
            // 
            // AntwoordCBox
            // 
            this.AntwoordCBox.Image = global::DefuseIT_Game.Properties.Resources.AntwoordenCBox;
            this.AntwoordCBox.Location = new System.Drawing.Point(990, 457);
            this.AntwoordCBox.Name = "AntwoordCBox";
            this.AntwoordCBox.Size = new System.Drawing.Size(607, 133);
            this.AntwoordCBox.TabIndex = 12;
            this.AntwoordCBox.TabStop = false;
            // 
            // AntwoordBBox
            // 
            this.AntwoordBBox.Image = global::DefuseIT_Game.Properties.Resources.AntwoordBoxB;
            this.AntwoordBBox.Location = new System.Drawing.Point(323, 630);
            this.AntwoordBBox.Name = "AntwoordBBox";
            this.AntwoordBBox.Size = new System.Drawing.Size(608, 133);
            this.AntwoordBBox.TabIndex = 13;
            this.AntwoordBBox.TabStop = false;
            // 
            // AntwoordDBox
            // 
            this.AntwoordDBox.Image = global::DefuseIT_Game.Properties.Resources.AntwoordenDBox;
            this.AntwoordDBox.Location = new System.Drawing.Point(990, 630);
            this.AntwoordDBox.Name = "AntwoordDBox";
            this.AntwoordDBox.Size = new System.Drawing.Size(608, 133);
            this.AntwoordDBox.TabIndex = 14;
            this.AntwoordDBox.TabStop = false;
            // 
            // AntwoordLabelA
            // 
            this.AntwoordLabelA.AutoSize = true;
            this.AntwoordLabelA.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AntwoordLabelA.Location = new System.Drawing.Point(448, 487);
            this.AntwoordLabelA.Name = "AntwoordLabelA";
            this.AntwoordLabelA.Size = new System.Drawing.Size(422, 72);
            this.AntwoordLabelA.TabIndex = 15;
            this.AntwoordLabelA.Text = "antwoord a";
            // 
            // AntwoordLabelB
            // 
            this.AntwoordLabelB.AutoSize = true;
            this.AntwoordLabelB.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AntwoordLabelB.Location = new System.Drawing.Point(448, 662);
            this.AntwoordLabelB.Name = "AntwoordLabelB";
            this.AntwoordLabelB.Size = new System.Drawing.Size(427, 72);
            this.AntwoordLabelB.TabIndex = 16;
            this.AntwoordLabelB.Text = "antwoord B";
            // 
            // AntwoordLabelC
            // 
            this.AntwoordLabelC.AutoSize = true;
            this.AntwoordLabelC.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AntwoordLabelC.Location = new System.Drawing.Point(1117, 487);
            this.AntwoordLabelC.Name = "AntwoordLabelC";
            this.AntwoordLabelC.Size = new System.Drawing.Size(427, 72);
            this.AntwoordLabelC.TabIndex = 17;
            this.AntwoordLabelC.Text = "antwoord C";
            // 
            // AntwoordLabelD
            // 
            this.AntwoordLabelD.AutoSize = true;
            this.AntwoordLabelD.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AntwoordLabelD.Location = new System.Drawing.Point(1117, 662);
            this.AntwoordLabelD.Name = "AntwoordLabelD";
            this.AntwoordLabelD.Size = new System.Drawing.Size(427, 72);
            this.AntwoordLabelD.TabIndex = 18;
            this.AntwoordLabelD.Text = "antwoord D";
            // 
            // KeuzeScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.AntwoordLabelD);
            this.Controls.Add(this.AntwoordLabelC);
            this.Controls.Add(this.AntwoordLabelB);
            this.Controls.Add(this.AntwoordLabelA);
            this.Controls.Add(this.AntwoordDBox);
            this.Controls.Add(this.AntwoordBBox);
            this.Controls.Add(this.AntwoordCBox);
            this.Controls.Add(this.AntwoordABox);
            this.Controls.Add(this.VraagLabel);
            this.Controls.Add(this.SocketStatus);
            this.Controls.Add(this.ControllerStatus);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.CloseApplication);
            this.Controls.Add(this.RestartGame);
            this.Controls.Add(this.Refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeuzeScherm";
            this.Text = "DefuseIT-Control";
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SocketStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordBBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntwoordDBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Refresh;
        private System.Windows.Forms.Label RestartGame;
        private System.Windows.Forms.Button CloseApplication;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Button Maximize;
        private System.Windows.Forms.PictureBox ControllerStatus;
        private System.Windows.Forms.PictureBox SocketStatus;
        private System.Windows.Forms.Label VraagLabel;
        private System.Windows.Forms.PictureBox AntwoordABox;
        private System.Windows.Forms.PictureBox AntwoordCBox;
        private System.Windows.Forms.PictureBox AntwoordBBox;
        private System.Windows.Forms.PictureBox AntwoordDBox;
        private System.Windows.Forms.Label AntwoordLabelA;
        private System.Windows.Forms.Label AntwoordLabelB;
        private System.Windows.Forms.Label AntwoordLabelC;
        private System.Windows.Forms.Label AntwoordLabelD;
    }
}

