namespace design
{
    partial class SetForm
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
            this.btnStnd = new System.Windows.Forms.Button();
            this.btnWrd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStnd
            // 
            this.btnStnd.Location = new System.Drawing.Point(175, 175);
            this.btnStnd.Name = "btnStnd";
            this.btnStnd.Size = new System.Drawing.Size(100, 100);
            this.btnStnd.TabIndex = 0;
            this.btnStnd.Text = "기본 모드";
            this.btnStnd.UseVisualStyleBackColor = true;
            this.btnStnd.Click += new System.EventHandler(this.btnStnd_Click);
            // 
            // btnWrd
            // 
            this.btnWrd.Location = new System.Drawing.Point(400, 175);
            this.btnWrd.Name = "btnWrd";
            this.btnWrd.Size = new System.Drawing.Size(100, 100);
            this.btnWrd.TabIndex = 1;
            this.btnWrd.Text = "초성 모드";
            this.btnWrd.UseVisualStyleBackColor = true;
            this.btnWrd.Click += new System.EventHandler(this.btnWrd_Click);
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWrd);
            this.Controls.Add(this.btnStnd);
            this.Name = "SetForm";
            this.Text = "SetForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStnd;
        private System.Windows.Forms.Button btnWrd;
    }
}