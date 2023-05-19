namespace testcase1
{
    partial class SetForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStnd = new System.Windows.Forms.Button();
            this.btnWrd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStnd
            // 
            this.btnStnd.Location = new System.Drawing.Point(200, 175);
            this.btnStnd.Name = "btnStnd";
            this.btnStnd.Size = new System.Drawing.Size(100, 100);
            this.btnStnd.TabIndex = 0;
            this.btnStnd.Text = "기본 모드";
            this.btnStnd.UseVisualStyleBackColor = true;
            this.btnStnd.Click += new System.EventHandler(this.btnStnd_Click);
            // 
            // btnWrd
            // 
            this.btnWrd.Location = new System.Drawing.Point(350, 175);
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

