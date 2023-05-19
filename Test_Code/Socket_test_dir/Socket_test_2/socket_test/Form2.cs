using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Collections;

namespace socket_test
{
    public partial class Form2 : Form
    {
        //서버의 txtChatMsg 텍스트박스에 글을 쓰기위한 델리게이트
        //실제 글을 쓰는것은 Form1클래스의 UI쓰레드가 아닌 다른 스레드인 ClientHandler의 스레드 이기에        
        //ClientHandler의 스레드에서 이 델리게이트를 호출하여 텍스트 박스에 글을 쓴다
        //(만약 컨트롤을 만든 윈폼의 UI쓰레드가 아닌 다른 스레드에서 텍스트박스에 글을 쓴다면 에러발생)
        delegate void SetTextDelegate(string s);

        public Form2()
        {
            InitializeComponent();
        }

        TcpListener chatServer = new TcpListener(IPAddress.Parse("127.0.0.1"), 2023); // 포트

        public static ArrayList clientSocketArray = new ArrayList();

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //서버가 종료 상태인경우
                if(lblMsg.Tag.ToString() == "Stop")
                {
                    chatServer.Start();
                    Thread waitThread = new Thread(new ThreadStart(AcceptClient));
                    waitThread.Start();

                    lblMsg.Text = "서버 시작됨";
                    lblMsg.Tag = "Start";
                    btnStart.Text = "서버 종료";

                    Form3 form3 = new Form3();
                    form3.ShowDialog(); // 방장도 참가하기 때문
                }
                else
                {
                    chatServer.Stop();
                    foreach(Socket soket in Form2.clientSocketArray)
                    {
                        soket.Close();
                    }
                    clientSocketArray.Clear();

                    lblMsg.Text = "서버 중지됨";
                    lblMsg.Tag = "Stop";
                    btnStart.Text = "서버 시작";
                    txtChatMsg.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 시작 오류 :" + ex.Message);
            }
        }

        // 무한루프 돌면서 client 접속을 기다리는
        private void AcceptClient()
        {
            Socket socketClient = null;
            while (true)
            {
                try
                {
                    socketClient = chatServer.AcceptSocket();

                    ClientHandler clientHandler = new ClientHandler();
                    clientHandler.ClientHandler_Setup(this, socketClient, this.txtChatMsg);

                    Thread thd_ChatProcess = new Thread(new ThreadStart(clientHandler.Chat_Process));
                    thd_ChatProcess.Start();
                }
                catch (System.Exception)
                {
                    Form2.clientSocketArray.Remove(socketClient);
                    break;
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            chatServer.Stop();
        }
    }

    public class ClientHandler
    {
        private TextBox txtChatMsg;
        private Socket socketClient;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Form2 form2;

        public void ClientHandler_Setup(Form2 form2, Socket socketClient, TextBox txtChatMsg)
        {
            this.txtChatMsg = txtChatMsg;
            this.socketClient = socketClient;
            this.netStream = new NetworkStream(socketClient);
            Form2.clientSocketArray.Add(socketClient); // 클라이언트 소켓을 List에 담음
            this.strReader = new StreamReader(netStream);
            this.form2 = form2;
        }

        public void Chat_Process()
        {
            while (true)
            {
                try
                {
                    // 클라이언트에게 문자열을 받음
                    string lstMessage = strReader.ReadLine();
                    if (lstMessage != null && lstMessage != "")
                    {
                        form2.SetText(lstMessage + "\r\n"); // delegate를 사용
                        byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                        lock (Form2.clientSocketArray)
                        {
                            // 접속해 있는 모든 클라이언트에게 글을 쓰는
                            foreach (Socket soket in Form2.clientSocketArray)
                            {
                                NetworkStream stream = new NetworkStream(soket);
                                stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("채팅 오류 :" + ex.Message);
                    Form2.clientSocketArray.Remove(socketClient);
                    break;
                }
            }
        }
    }
}
