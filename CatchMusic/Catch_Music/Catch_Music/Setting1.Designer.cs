namespace Catch_Music
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
            this.btnStandard = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStandard.Font = new System.Drawing.Font("한컴 소망 B", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStandard.Location = new System.Drawing.Point(200, 175);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(150, 100);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "기본 모드";
            this.btnStandard.UseVisualStyleBackColor = false;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWord.Font = new System.Drawing.Font("한컴 소망 B", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWord.Location = new System.Drawing.Point(475, 175);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(150, 100);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "초성 모드";
            this.btnWord.UseVisualStyleBackColor = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // MySet1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.btnStandard);
            this.Name = "MySet1";
            this.Text = "MySet1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnWord;
    }
}