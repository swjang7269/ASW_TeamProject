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
    //서버의 txtChatMsg 텍스트박스에 글을 쓰기위한 델리게이트
    //실제 글을 쓰는것은 Form1클래스의 UI쓰레드가 아닌 다른 스레드인 ChatHandler의 스레드 이기에        
    //ChatHandler의 스레드에서 이 델리게이트를 호출하여 텍스트 박스에 글을 쓴다
    //(만약 컨트롤을 만든 윈폼의 UI쓰레드가 아닌 다른 스레드에서 텍스트박스에 글을 쓴다면 에러발생)
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

        //서버와 채팅을 실행하는 클래스
        ChatHandler chatHandler = new ChatHandler();

        //서버 들어가기 버튼
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "서버 들어가기")
            {
                try
                {
                    portNumber = int.Parse(portNumMsg.Text);
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse(IPtxtMsg.Text), portNumber);
                    ntwStream = tcpClient.GetStream();

                    chatHandler.Setup(this, ntwStream, this.txtChatMsg);
                    Thread chatThread = new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start();

                    // 서버로 클라이언트가 접속했음을 알리는 메소드
                    Message_Snd("서버 : <" + txtName.Text + "> 님께서 접속 하셨습니다.", true);
                    btnConnect.Text = "서버 나가기";
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 서버입니다.");
                }
            }
            else
            {
                Message_Snd("서버 : <" + txtName.Text + "> 님께서 접속해제 하셨습니다.", false);
                btnConnect.Text = "서버 들어가기";
                chatHandler.ChatClose();
                ntwStream.Close();
                tcpClient.Close();
                txtChatMsg.Text = "";
            }
        }

        // 서버로 메세지를 보내는 함수
        private void Message_Snd(string lstMessage, Boolean Msg)
        {
            try
            {
                // 보낼 데이터를 읽어 Default 형식의 바이트 스트림으로 변환 해서 전송
                string dataToSend = lstMessage + "\r\n";
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ntwStream.Write(data, 0, data.Length);
            }
            catch (Exception Ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("서버가 Start 되지 않았거나\r\n" + Ex.Message, "Client");
                    btnConnect.Text = "서버 들어가기";
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
                SetTextDelegate d = new SetTextDelegate(SetText); // 대리자 선언
                this.Invoke(d, new object[] { text }); // 대리자를 통해 글을 쓰는
            }
            else // UI Thread 이면
            {
                this.txtChatMsg.AppendText(text);
            }
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 누른 키가 Enter인 경우
            {
                // 서버에 접속이 된 상태일 경우
                if (btnConnect.Text == "서버 나가기")
                {
                    Message_Snd("<" + txtName.Text + "> " + txtMsg.Text, true);
                }

                txtMsg.Text = "";
                e.Handled = true; // 이벤트처리 중지
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
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
                    // 문자열을 받음
                    string lstMessage = strReader.ReadLine();
                    if (lstMessage == "./start")
                    {
                        form3.SetText("start!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage == "./hint1")
                    {
                        form3.SetText("hint1!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage == "./hint2")
                    {
                        form3.SetText("hint2!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage == "./hint3")
                    {
                        form3.SetText("hint3!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage != null && lstMessage != "")
                    {
                        // 대리자 사용
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
