using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace socket_test
{
    //������ txtChatMsg �ؽ�Ʈ�ڽ��� ���� �������� ��������Ʈ
    //���� ���� ���°��� Form1Ŭ������ UI�����尡 �ƴ� �ٸ� �������� ChatHandler�� ������ �̱⿡        
    //ChatHandler�� �����忡�� �� ��������Ʈ�� ȣ���Ͽ� �ؽ�Ʈ �ڽ��� ���� ����
    //(���� ��Ʈ���� ���� ������ UI�����尡 �ƴ� �ٸ� �����忡�� �ؽ�Ʈ�ڽ��� ���� ���ٸ� �����߻�)
    delegate void SetTextDelegate(string s);
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        TcpClient tcpClient = null;
        NetworkStream ntwStream = null;
        int portNumber;

        //������ ä���� �����ϴ� Ŭ����
        ChatHandler chatHandler = new ChatHandler();

        //���� ���� ��ư
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "���� ����")
            {
                try
                {
                    portNumber = int.Parse(portNumMsg.Text);
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), portNumber);
                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, this.txtChatMsg);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    // ������ Ŭ���̾�Ʈ�� ���������� �˸��� �޼ҵ�
                    Message_Snd("���� : <" + txtName.Text + "> �Բ��� ���� �ϼ̽��ϴ�.", true);
                    btnConnect.Text = "���� ������";
                }
                catch(System.Exception Ex)
                {
                    MessageBox.Show("�������� �ʴ� �����Դϴ�.");
                }
            }
            else
            {
                Message_Snd("���� : <" + txtName.Text + "> �Բ��� �������� �ϼ̽��ϴ�.", false);
                btnConnect.Text = "���� ����";
                chatHandler.ChatClose();
                ntwStream.Close();
                tcpClient.Close();
                txtChatMsg.Text = "";
            }
        }

        // ������ �޼����� ������ �Լ�
        private void Message_Snd(string lstMessage, Boolean Msg)
        {
            try
            {
                // ���� �����͸� �о� Default ������ ����Ʈ ��Ʈ������ ��ȯ �ؼ� ����
                string dataToSend = lstMessage + "\r\n";
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ntwStream.Write(data, 0, data.Length);
            }
            catch (Exception Ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("������ Start ���� �ʾҰų�\r\n" + Ex.Message, "Client");
                    btnConnect.Text = "���� ����";
                    chatHandler.ChatClose();
                    ntwStream.Close();
                    tcpClient.Close();
                }
            }
        }

        public void SetText(string text)
        {
            if (this.txtChatMsg.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText); // �븮�� ����
                this.Invoke(d, new object[] { text }); // �븮�ڸ� ���� ���� ����
            }
            else // UI Thread �̸�
            {
                this.txtChatMsg.AppendText(text);
            }
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // ���� Ű�� Enter�� ���
            {
                // ������ ������ �� ������ ���
                if (btnConnect.Text == "���� ������")
                {
                    Message_Snd("<" + txtName.Text + "> " + txtMsg.Text, true);
                }

                txtMsg.Text = "";
                e.Handled = true; // �̺�Ʈó�� ����
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
    
        }
    }

    public class ChatHandler
    {
        private TextBox txtChatMsg;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Form3 form3;

        public void Setup(Form3 form3, NetworkStream netStream, TextBox txtChatMsg)
        {
            this.txtChatMsg = txtChatMsg;
            this.netStream = netStream;
            this.form3 = form3;
            this.netStream = netStream;
            this.strReader = new StreamReader(netStream);
        }

        public void ChatClose()
        {
            netStream.Close();
            strReader.Close();
        }

        public void ChatProcess()
        {
            while (true)
            {
                try
                {
                    // ���ڿ��� ����
                    string lstMessage = strReader.ReadLine();

                    if(lstMessage != null && lstMessage != "")
                    {
                        // �븮�� ���
                        form3.SetText(lstMessage + "\r\n");
                    }
                }
                catch (System.Exception)
                {
                    break;
                }
            }
        }
    }
}
