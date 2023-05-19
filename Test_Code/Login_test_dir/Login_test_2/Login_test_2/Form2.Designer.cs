namespace Login_test_2
{
    partial class Form2
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
            this.labelJoin = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Join = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelJoin
            // 
            this.labelJoin.AutoSize = true;
            this.labelJoin.Font = new System.Drawing.Font("굴림", 20F);
            this.labelJoin.Location = new System.Drawing.Point(155, 39);
            this.labelJoin.Name = "labelJoin";
            this.labelJoin.Size = new System.Drawing.Size(120, 27);
            this.labelJoin.TabIndex = 0;
            this.labelJoin.Text = "회원가입";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(115, 97);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(226, 21);
            this.txtID.TabIndex = 1;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(106, 158);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(226, 21);
            this.txtPW.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 225);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(226, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(126, 294);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(226, 21);
            this.txtBirth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "비밀번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "생년월일 (8자리)";
            // 
            // Join
            // 
            this.Join.Location = new System.Drawing.Point(140, 362);
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(87, 33);
            this.Join.TabIndex = 3;
            this.Join.Text = "회원가입";
            this.Join.UseVisualStyleBackColor = true;
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 450);
            this.Controls.Add(this.Join);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.labelJoin);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJoin;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Join;
    }
}