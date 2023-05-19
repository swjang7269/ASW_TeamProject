namespace Login_test_1
{
    partial class Form1
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
            this.login_label = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_PW = new System.Windows.Forms.TextBox();
            this.Signin_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("굴림", 20F);
            this.login_label.Location = new System.Drawing.Point(216, 47);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(129, 27);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "로그인 창";
            // 
            // txt_ID
            // 
            this.txt_ID.Font = new System.Drawing.Font("굴림", 15F);
            this.txt_ID.Location = new System.Drawing.Point(143, 138);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(287, 30);
            this.txt_ID.TabIndex = 1;
            // 
            // txt_PW
            // 
            this.txt_PW.Font = new System.Drawing.Font("굴림", 15F);
            this.txt_PW.Location = new System.Drawing.Point(143, 254);
            this.txt_PW.Name = "txt_PW";
            this.txt_PW.PasswordChar = '*';
            this.txt_PW.Size = new System.Drawing.Size(287, 30);
            this.txt_PW.TabIndex = 1;
            // 
            // Signin_btn
            // 
            this.Signin_btn.Location = new System.Drawing.Point(145, 315);
            this.Signin_btn.Name = "Signin_btn";
            this.Signin_btn.Size = new System.Drawing.Size(284, 49);
            this.Signin_btn.TabIndex = 2;
            this.Signin_btn.Text = "로그인";
            this.Signin_btn.UseVisualStyleBackColor = true;
            this.Signin_btn.Click += new System.EventHandler(this.Signin_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 450);
            this.Controls.Add(this.Signin_btn);
            this.Controls.Add(this.txt_PW);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.login_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_PW;
        private System.Windows.Forms.Button Signin_btn;
    }
}

