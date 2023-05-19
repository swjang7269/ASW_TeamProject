using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch_Music
{
    delegate void SetTextDelegate(string s);
    public partial class Client : Form
    {
        TcpClient tcpClient = null;
        NetworkStream ntwStream = null;
        int portNumber;
        ChatHandler chatHandler = new ChatHandler(); //서버와 채팅을 실행하는 클래스
        public string musicTitle = null; // 방장이 음악 실행하면 음악의 제목이 저장될 변수
        public DataSet dataset = new ClientINFO();

        public Client()
        {
            InitializeComponent();
            dataGridView1.DataSource = dataset.Tables["clientINFO"];
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

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
                    Message_Snd("./name " + txtName.Text, true);
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
                Message_Snd("/close " + txtName.Text, true);
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

        private void txtMsg_KeyPress_1(object sender, KeyPressEventArgs e)
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
    }

    public class ChatHandler
    {
        private TextBox txtChatMsg;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Client ce;

        public void Setup(Client ce, NetworkStream netStream, TextBox txtChatMsg)
        {
            this.txtChatMsg = txtChatMsg;
            this.netStream = netStream;
            this.ce = ce;
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

                    // 서버장이 음악실행을 누른 경우
                    if (lstMessage.StartsWith("./start ") == true)
                    {
                        // Substring을 통해 음악제목 가져오기
                        ce.musicTitle = lstMessage.Substring(8);

                        ///
                        // 서버 폼에서 음악실행 버튼을 누르면
                        // 실행할 노래의 제목이 musicTitle에 저장됩니다.
                        // 여기에 음악 실행하는 코드 작성(ce.musicTitle 변수가 음악 제목입니다)
                        ///
                        continue;
                    }

                    if (lstMessage.StartsWith("./name ") == true)
                    {
                        // 닉네임 저장
                        ce.dataset.Tables["clientINFO"].Rows.Add(new object[] { lstMessage.Substring(7), 0 });
                        continue;
                        // Form에 닉네임과 점수 띄우기 필요
                    }

                    if (lstMessage == "./hint1")
                    {
                        ce.SetText("hint1!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage == "./hint2")
                    {
                        ce.SetText("hint2!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage == "./hint3")
                    {
                        ce.SetText("hint3!!!!!!!!!" + "\r\n");
                        continue;
                    }

                    if (lstMessage != null && lstMessage != "")
                    {
                        // 대리자 사용
                        ce.SetText(lstMessage + "\r\n");
                        continue;
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
