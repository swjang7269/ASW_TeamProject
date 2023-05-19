namespace Login_test3
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            this.labelBirth = new System.Windows.Forms.Label();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelPWcheck = new System.Windows.Forms.Label();
            this.txtPWch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 21);
            this.txtName.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(130, 124);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(132, 21);
            this.txtID.TabIndex = 0;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(130, 175);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(132, 21);
            this.txtPW.TabIndex = 0;
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(130, 253);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(132, 21);
            this.txtBirth.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(43, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "이름";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(33, 124);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(41, 12);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "아이디";
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.Location = new System.Drawing.Point(33, 175);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(53, 12);
            this.labelPW.TabIndex = 3;
            this.labelPW.Text = "비밀번호";
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Location = new System.Drawing.Point(17, 253);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(93, 12);
            this.labelBirth.TabIndex = 4;
            this.labelBirth.Text = "생년월일(8자리)";
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(96, 316);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(70, 34);
            this.btnJoin.TabIndex = 5;
            this.btnJoin.Text = "회원가입";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelPWcheck
            // 
            this.labelPWcheck.AutoSize = true;
            this.labelPWcheck.Location = new System.Drawing.Point(33, 209);
            this.labelPWcheck.Name = "labelPWcheck";
            this.labelPWcheck.Size = new System.Drawing.Size(81, 12);
            this.labelPWcheck.TabIndex = 3;
            this.labelPWcheck.Text = "비밀번호 확인";
            // 
            // txtPWch
            // 
            this.txtPWch.Location = new System.Drawing.Point(130, 200);
            this.txtPWch.Name = "txtPWch";
            this.txtPWch.Size = new System.Drawing.Size(132, 21);
            this.txtPWch.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.labelPWcheck);
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtBirth);
            this.Controls.Add(this.txtPWch);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPW;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelPWcheck;
        private System.Windows.Forms.TextBox txtPWch;
    }
}

