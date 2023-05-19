namespace socket_test
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtChatMsg = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.portNumMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IPtxt = new System.Windows.Forms.Label();
            this.IPtxtMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "닉네임";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(60, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(91, 21);
            this.txtName.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(358, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(214, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "서버 들어가기";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtChatMsg
            // 
            this.txtChatMsg.Location = new System.Drawing.Point(13, 69);
            this.txtChatMsg.Multiline = true;
            this.txtChatMsg.Name = "txtChatMsg";
            this.txtChatMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatMsg.Size = new System.Drawing.Size(559, 420);
            this.txtChatMsg.TabIndex = 3;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(13, 515);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(559, 21);
            this.txtMsg.TabIndex = 4;
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            // 
            // portNumMsg
            // 
            this.portNumMsg.Location = new System.Drawing.Point(252, 10);
            this.portNumMsg.Name = "portNumMsg";
            this.portNumMsg.Size = new System.Drawing.Size(100, 21);
            this.portNumMsg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "방번호";
            // 
            // IPtxt
            // 
            this.IPtxt.AutoSize = true;
            this.IPtxt.Location = new System.Drawing.Point(216, 43);
            this.IPtxt.Name = "IPtxt";
            this.IPtxt.Size = new System.Drawing.Size(16, 12);
            this.IPtxt.TabIndex = 7;
            this.IPtxt.Text = "IP";
            // 
            // IPtxtMsg
            // 
            this.IPtxtMsg.Location = new System.Drawing.Point(252, 37);
            this.IPtxtMsg.Name = "IPtxtMsg";
            this.IPtxtMsg.Size = new System.Drawing.Size(320, 21);
            this.IPtxtMsg.TabIndex = 8;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.IPtxtMsg);
            this.Controls.Add(this.IPtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portNumMsg);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtChatMsg);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtChatMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox portNumMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IPtxt;
        private System.Windows.Forms.TextBox IPtxtMsg;
    }
}