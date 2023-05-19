namespace Catch_Music
{
    partial class MySet3
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
            this.btnHigh = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHigh
            // 
            this.btnHigh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHigh.Font = new System.Drawing.Font("한컴 소망 B", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHigh.Location = new System.Drawing.Point(125, 175);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(160, 75);
            this.btnHigh.TabIndex = 0;
            this.btnHigh.Text = "상 (5초 재생)";
            this.btnHigh.UseVisualStyleBackColor = false;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMedium.Font = new System.Drawing.Font("한컴 소망 B", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMedium.Location = new System.Drawing.Point(325, 175);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(160, 75);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "중 (10초 재생)";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnLow
            // 
            this.btnLow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLow.Font = new System.Drawing.Font("한컴 소망 B", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLow.Location = new System.Drawing.Point(525, 175);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(160, 75);
            this.btnLow.TabIndex = 2;
            this.btnLow.Text = "하 (15초 재생)";
            this.btnLow.UseVisualStyleBackColor = false;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // MySet3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnHigh);
            this.Name = "MySet3";
            this.Text = "MySet3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnLow;
    }
}