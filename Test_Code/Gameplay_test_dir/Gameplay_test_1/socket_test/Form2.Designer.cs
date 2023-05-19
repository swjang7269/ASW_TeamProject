namespace socket_test
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtChatMsg = new System.Windows.Forms.TextBox();
            this.portNumTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.musicStartBtn = new System.Windows.Forms.Button();
            this.musicTitleMsg = new System.Windows.Forms.TextBox();
            this.musicTitleBtn = new System.Windows.Forms.Button();
            this.hintBtn1 = new System.Windows.Forms.Button();
            this.hintBtn2 = new System.Windows.Forms.Button();
            this.hintBtn3 = new System.Windows.Forms.Button();
            this.answerTxt = new System.Windows.Forms.Label();
            this.musicAnswerP = new System.Windows.Forms.TextBox();
            this.IPtxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(276, 275);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(262, 84);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "서버 시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(104, 275);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(69, 12);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Tag = "Stop";
            this.lblMsg.Text = "서버 중지됨";
            // 
            // txtChatMsg
            // 
            this.txtChatMsg.Location = new System.Drawing.Point(12, 12);
            this.txtChatMsg.Multiline = true;
            this.txtChatMsg.Name = "txtChatMsg";
            this.txtChatMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatMsg.Size = new System.Drawing.Size(560, 245);
            this.txtChatMsg.TabIndex = 3;
            // 
            // portNumTxt
            // 
            this.portNumTxt.Location = new System.Drawing.Point(127, 338);
            this.portNumTxt.Name = "portNumTxt";
            this.portNumTxt.Size = new System.Drawing.Size(100, 21);
            this.portNumTxt.TabIndex = 4;
            this.portNumTxt.TextChanged += new System.EventHandler(this.portNumTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "방번호";
            // 
            // musicStartBtn
            // 
            this.musicStartBtn.Enabled = false;
            this.musicStartBtn.Location = new System.Drawing.Point(179, 412);
            this.musicStartBtn.Name = "musicStartBtn";
            this.musicStartBtn.Size = new System.Drawing.Size(158, 57);
            this.musicStartBtn.TabIndex = 6;
            this.musicStartBtn.Text = "노래실행";
            this.musicStartBtn.UseVisualStyleBackColor = true;
            this.musicStartBtn.Click += new System.EventHandler(this.musicStartBtn_Click);
            // 
            // musicTitleMsg
            // 
            this.musicTitleMsg.Enabled = false;
            this.musicTitleMsg.Location = new System.Drawing.Point(12, 385);
            this.musicTitleMsg.Name = "musicTitleMsg";
            this.musicTitleMsg.Size = new System.Drawing.Size(559, 21);
            this.musicTitleMsg.TabIndex = 7;
            // 
            // musicTitleBtn
            // 
            this.musicTitleBtn.Enabled = false;
            this.musicTitleBtn.Location = new System.Drawing.Point(12, 412);
            this.musicTitleBtn.Name = "musicTitleBtn";
            this.musicTitleBtn.Size = new System.Drawing.Size(161, 57);
            this.musicTitleBtn.TabIndex = 8;
            this.musicTitleBtn.Text = "노래가져오기";
            this.musicTitleBtn.UseVisualStyleBackColor = true;
            this.musicTitleBtn.Click += new System.EventHandler(this.musicTitleBtn_Click);
            // 
            // hintBtn1
            // 
            this.hintBtn1.Enabled = false;
            this.hintBtn1.Location = new System.Drawing.Point(343, 429);
            this.hintBtn1.Name = "hintBtn1";
            this.hintBtn1.Size = new System.Drawing.Size(75, 23);
            this.hintBtn1.TabIndex = 9;
            this.hintBtn1.Text = "힌트1";
            this.hintBtn1.UseVisualStyleBackColor = true;
            this.hintBtn1.Click += new System.EventHandler(this.hintBtn1_Click);
            // 
            // hintBtn2
            // 
            this.hintBtn2.Enabled = false;
            this.hintBtn2.Location = new System.Drawing.Point(424, 429);
            this.hintBtn2.Name = "hintBtn2";
            this.hintBtn2.Size = new System.Drawing.Size(75, 23);
            this.hintBtn2.TabIndex = 10;
            this.hintBtn2.Text = "힌트2";
            this.hintBtn2.UseVisualStyleBackColor = true;
            this.hintBtn2.Click += new System.EventHandler(this.hintBtn2_Click);
            // 
            // hintBtn3
            // 
            this.hintBtn3.Enabled = false;
            this.hintBtn3.Location = new System.Drawing.Point(505, 429);
            this.hintBtn3.Name = "hintBtn3";
            this.hintBtn3.Size = new System.Drawing.Size(75, 23);
            this.hintBtn3.TabIndex = 11;
            this.hintBtn3.Text = "힌트3";
            this.hintBtn3.UseVisualStyleBackColor = true;
            this.hintBtn3.Click += new System.EventHandler(this.hintBtn3_Click);
            // 
            // answerTxt
            // 
            this.answerTxt.AutoSize = true;
            this.answerTxt.Enabled = false;
            this.answerTxt.Location = new System.Drawing.Point(219, 507);
            this.answerTxt.Name = "answerTxt";
            this.answerTxt.Size = new System.Drawing.Size(41, 12);
            this.answerTxt.TabIndex = 12;
            this.answerTxt.Text = "정답자";
            // 
            // musicAnswerP
            // 
            this.musicAnswerP.Enabled = false;
            this.musicAnswerP.Location = new System.Drawing.Point(266, 504);
            this.musicAnswerP.Name = "musicAnswerP";
            this.musicAnswerP.Size = new System.Drawing.Size(100, 21);
            this.musicAnswerP.TabIndex = 13;
            this.musicAnswerP.TextChanged += new System.EventHandler(this.musicAnswerP_TextChanged);
            this.musicAnswerP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.musicAnswerP_KeyDown);
            this.musicAnswerP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.musicAnswerP_KeyPress);
            // 
            // IPtxt
            // 
            this.IPtxt.AutoSize = true;
            this.IPtxt.Location = new System.Drawing.Point(104, 311);
            this.IPtxt.Name = "IPtxt";
            this.IPtxt.Size = new System.Drawing.Size(16, 12);
            this.IPtxt.TabIndex = 14;
            this.IPtxt.Text = "IP";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.IPtxt);
            this.Controls.Add(this.musicAnswerP);
            this.Controls.Add(this.answerTxt);
            this.Controls.Add(this.hintBtn3);
            this.Controls.Add(this.hintBtn2);
            this.Controls.Add(this.hintBtn1);
            this.Controls.Add(this.musicTitleBtn);
            this.Controls.Add(this.musicTitleMsg);
            this.Controls.Add(this.musicStartBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portNumTxt);
            this.Controls.Add(this.txtChatMsg);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnStart);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtChatMsg;
        private System.Windows.Forms.TextBox portNumTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button musicStartBtn;
        private System.Windows.Forms.TextBox musicTitleMsg;
        private System.Windows.Forms.Button musicTitleBtn;
        private System.Windows.Forms.Button hintBtn1;
        private System.Windows.Forms.Button hintBtn2;
        private System.Windows.Forms.Button hintBtn3;
        private System.Windows.Forms.Label answerTxt;
        private System.Windows.Forms.TextBox musicAnswerP;
        private System.Windows.Forms.Label IPtxt;
    }
}