namespace DefuseIT_Game
{
    partial class ControlScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlScherm));
            this.ControllerStatus = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.CloseApplication = new System.Windows.Forms.Button();
            this.AssemblyName = new System.Windows.Forms.Label();
            this.ControlSchermBackground = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.WebcamStream = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlSchermBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamStream)).BeginInit();
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
            // ControlSchermBackground
            // 
            this.ControlSchermBackground.Image = ((System.Drawing.Image)(resources.GetObject("ControlSchermBackground.Image")));
            this.ControlSchermBackground.Location = new System.Drawing.Point(0, 0);
            this.ControlSchermBackground.Name = "ControlSchermBackground";
            this.ControlSchermBackground.Size = new System.Drawing.Size(1920, 1080);
            this.ControlSchermBackground.TabIndex = 0;
            this.ControlSchermBackground.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DefuseIT_Game.Properties.Resources.WiFi_Not;
            this.pictureBox2.Location = new System.Drawing.Point(1775, 1011);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 62);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // WebcamStream
            // 
            this.WebcamStream.Enabled = true;
            this.WebcamStream.Location = new System.Drawing.Point(657, 267);
            this.WebcamStream.Name = "WebcamStream";
            this.WebcamStream.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WebcamStream.OcxState")));
            this.WebcamStream.Size = new System.Drawing.Size(1191, 728);
            this.WebcamStream.TabIndex = 8;
            // 
            // ControlScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.WebcamStream);
            this.Controls.Add(this.ControllerStatus);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.CloseApplication);
            this.Controls.Add(this.AssemblyName);
            this.Controls.Add(this.ControlSchermBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlScherm";
            this.Text = "DefuseIT-Control";
            ((System.ComponentModel.ISupportInitialize)(this.ControllerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlSchermBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamStream)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ControlSchermBackground;
        private System.Windows.Forms.Label AssemblyName;
        private System.Windows.Forms.Button CloseApplication;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Button Maximize;
        private System.Windows.Forms.PictureBox ControllerStatus;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AxAXVLC.AxVLCPlugin2 WebcamStream;
    }
}

