namespace design
{
    partial class MySet2
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
            this.btnHigh.Location = new System.Drawing.Point(125, 175);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(125, 50);
            this.btnHigh.TabIndex = 0;
            this.btnHigh.Text = "상 (5초 재생)";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(300, 175);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(125, 50);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "중 (10초 재생)";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(475, 175);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(125, 50);
            this.btnLow.TabIndex = 2;
            this.btnLow.Text = "하 (15초 재생)";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // MySet2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnHigh);
            this.Name = "MySet2";
            this.Text = "MySet2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnLow;
    }
}