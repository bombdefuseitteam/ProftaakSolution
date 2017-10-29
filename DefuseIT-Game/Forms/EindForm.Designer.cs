namespace DefuseIT_Game
{
    partial class EindScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EindScherm));
            this.ControllerStatus = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.CloseApplication = new System.Windows.Forms.Button();
            this.AssemblyName = new System.Windows.Forms.Label();
            this.StartSchermBackground = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.NaamTextBox = new System.Windows.Forms.TextBox();
            this.EndScoreLabel = new System.Windows.Forms.Label();
            this.BevestigBox = new System.Windows.Forms.PictureBox();
            this.AantalFoutenLabel = new System.Windows.Forms.Label();
            this.EindTijdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartSchermBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BevestigBox)).BeginInit();
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
            // AssemblyName
            // 
            this.AssemblyName.AutoSize = true;
            this.AssemblyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AssemblyName.Font = new System.Drawing.Font("Back In The USSR DL", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssemblyName.Image = global::DefuseIT_Game.Properties.Resources.background;
            this.AssemblyName.Location = new System.Drawing.Point(12, 10);
            this.AssemblyName.Name = "AssemblyName";
            this.AssemblyName.Size = new System.Drawing.Size(111, 23);
            this.AssemblyName.TabIndex = 2;
            this.AssemblyName.Text = "DefuseIT";
            // 
            // StartSchermBackground
            // 
            this.StartSchermBackground.Image = ((System.Drawing.Image)(resources.GetObject("StartSchermBackground.Image")));
            this.StartSchermBackground.Location = new System.Drawing.Point(0, 0);
            this.StartSchermBackground.Name = "StartSchermBackground";
            this.StartSchermBackground.Size = new System.Drawing.Size(1920, 1080);
            this.StartSchermBackground.TabIndex = 0;
            this.StartSchermBackground.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DefuseIT_Game.Properties.Resources.WiFi_Not;
            this.pictureBox2.Location = new System.Drawing.Point(1775, 1011);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 62);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // NaamTextBox
            // 
            this.NaamTextBox.BackColor = System.Drawing.Color.Black;
            this.NaamTextBox.Font = new System.Drawing.Font("Back In The USSR DL", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NaamTextBox.Location = new System.Drawing.Point(566, 903);
            this.NaamTextBox.Name = "NaamTextBox";
            this.NaamTextBox.Size = new System.Drawing.Size(507, 63);
            this.NaamTextBox.TabIndex = 9;
            this.NaamTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EndScoreLabel
            // 
            this.EndScoreLabel.Font = new System.Drawing.Font("Back In The USSR DL", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndScoreLabel.Location = new System.Drawing.Point(788, 560);
            this.EndScoreLabel.Name = "EndScoreLabel";
            this.EndScoreLabel.Size = new System.Drawing.Size(367, 80);
            this.EndScoreLabel.TabIndex = 10;
            this.EndScoreLabel.Text = "+SCORE+";
            this.EndScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BevestigBox
            // 
            this.BevestigBox.Image = ((System.Drawing.Image)(resources.GetObject("BevestigBox.Image")));
            this.BevestigBox.Location = new System.Drawing.Point(1147, 874);
            this.BevestigBox.Name = "BevestigBox";
            this.BevestigBox.Size = new System.Drawing.Size(434, 106);
            this.BevestigBox.TabIndex = 11;
            this.BevestigBox.TabStop = false;
            // 
            // AantalFoutenLabel
            // 
            this.AantalFoutenLabel.Font = new System.Drawing.Font("Back In The USSR DL", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AantalFoutenLabel.Location = new System.Drawing.Point(746, 706);
            this.AantalFoutenLabel.Name = "AantalFoutenLabel";
            this.AantalFoutenLabel.Size = new System.Drawing.Size(518, 45);
            this.AantalFoutenLabel.TabIndex = 14;
            this.AantalFoutenLabel.Text = "aantal Fouten: 10";
            this.AantalFoutenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EindTijdLabel
            // 
            this.EindTijdLabel.Font = new System.Drawing.Font("Back In The USSR DL", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EindTijdLabel.Location = new System.Drawing.Point(746, 756);
            this.EindTijdLabel.Name = "EindTijdLabel";
            this.EindTijdLabel.Size = new System.Drawing.Size(518, 45);
            this.EindTijdLabel.TabIndex = 15;
            this.EindTijdLabel.Text = "Tijd: 180 seconden";
            this.EindTijdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EindScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.EindTijdLabel);
            this.Controls.Add(this.AantalFoutenLabel);
            this.Controls.Add(this.BevestigBox);
            this.Controls.Add(this.EndScoreLabel);
            this.Controls.Add(this.NaamTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ControllerStatus);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.CloseApplication);
            this.Controls.Add(this.AssemblyName);
            this.Controls.Add(this.StartSchermBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EindScherm";
            this.Text = "DefuseIT-Game";
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartSchermBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BevestigBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StartSchermBackground;
        private System.Windows.Forms.Label AssemblyName;
        private System.Windows.Forms.Button CloseApplication;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Button Maximize;
        private System.Windows.Forms.PictureBox ControllerStatus;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox NaamTextBox;
        private System.Windows.Forms.Label EndScoreLabel;
        private System.Windows.Forms.PictureBox BevestigBox;
        private System.Windows.Forms.Label AantalFoutenLabel;
        private System.Windows.Forms.Label EindTijdLabel;
    }
}

