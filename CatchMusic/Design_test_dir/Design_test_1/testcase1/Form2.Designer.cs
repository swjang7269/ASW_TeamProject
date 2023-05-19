namespace testcase1
{
    partial class MySet1
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
            this.btnInvd = new System.Windows.Forms.Button();
            this.btnTeam = new System.Windows.Forms.Button();
            this.btnSolo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInvd
            // 
            this.btnInvd.Location = new System.Drawing.Point(175, 175);
            this.btnInvd.Name = "btnInvd";
            this.btnInvd.Size = new System.Drawing.Size(100, 100);
            this.btnInvd.TabIndex = 0;
            this.btnInvd.Text = "개인전";
            this.btnInvd.UseVisualStyleBackColor = true;
            this.btnInvd.Click += new System.EventHandler(this.btnInvd_Click);
            // 
            // btnTeam
            // 
            this.btnTeam.Location = new System.Drawing.Point(300, 175);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(100, 100);
            this.btnTeam.TabIndex = 1;
            this.btnTeam.Text = "팀전";
            this.btnTeam.UseVisualStyleBackColor = true;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // btnSolo
            // 
            this.btnSolo.Location = new System.Drawing.Point(425, 175);
            this.btnSolo.Name = "btnSolo";
            this.btnSolo.Size = new System.Drawing.Size(100, 100);
            this.btnSolo.TabIndex = 2;
            this.btnSolo.Text = "솔로 플레이";
            this.btnSolo.UseVisualStyleBackColor = true;
            this.btnSolo.Click += new System.EventHandler(this.btnSolo_Click);
            // 
            // MySet1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSolo);
            this.Controls.Add(this.btnTeam);
            this.Controls.Add(this.btnInvd);
            this.Name = "MySet1";
            this.Text = "MySet1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvd;
        private System.Windows.Forms.Button btnTeam;
        private System.Windows.Forms.Button btnSolo;
    }
}