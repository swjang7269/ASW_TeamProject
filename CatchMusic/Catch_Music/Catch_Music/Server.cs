using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Catch_Music
{
    public partial class Server : Form
    {
        delegate void SetTextDelegate(string s);
        int portNumber;
        TcpListener chatServer;
        string musicTitle = null;
        public static ArrayList clientSocketArray = new ArrayList();
        public DataSet dataset = new ClientINFO();

        private YouTubeService youtubeService;
        private string videoId;
        private string audioUrl;
        private Process audioProcess;

        private System.Windows.Forms.Timer timer;
        private int elapsedTime;

        public Server()
        {
            InitializeComponent();
            dataGridView1.DataSource = dataset.Tables["clientINFO"];

            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCXYRYadXpJP9AzdPidWCYKVO_Xj5wcQM4", // Google API Console에서 생성한 인증키를 입력하세요.
                ApplicationName = this.GetType().ToString()
            });

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1초마다 타이머 이벤트 발생
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            labelTimer.Text = elapsedTime.ToString();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            IPtxt.Text = GetIP();
        }

        // 이더넷 or Wi-Fi의 IP를 가져오는 함수
        public static string GetIP()
        {
            string IPs = "";

            //모든 네트워크 인터페이스 얻기
            foreach (var network in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (network.Name == "이더넷" || network.Name == "Wi-Fi")
                {
                    //IPv4를 지원하는 네트워크 확인
                    if (network.Supports(NetworkInterfaceComponent.IPv4) == true)
                    {
                        // 사용하는 네트워크인지 확인
                        if (NetworkInterface.GetIsNetworkAvailable() && network.OperationalStatus == OperationalStatus.Up)
                        {
                            //Unicast 주소가 할당된 ip 얻기
                            foreach (UnicastIPAddressInformation uniIp in network.GetIPProperties().UnicastAddresses)
                            {
                                if (uniIp.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    string ipAddress = uniIp.Address.ToString();
                                    if (ipAddress != null)
                                    {
                                        IPs = ipAddress;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return IPs;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (portNumTxt.Text != "")
            {
                portNumber = int.Parse(portNumTxt.Text);
                chatServer = new TcpListener(IPAddress.Parse(GetIP()), portNumber); // 포트
            }
            else { return; }

            try
            {
                Thread waitThread = new Thread(new ThreadStart(AcceptClient));
                //서버가 종료 상태인경우
                if (OnOffsv.Tag.ToString() == "Stop")
                {
                    chatServer.Start();
                    waitThread.Start();

                    OnOffsv.Text = "방 열림";
                    OnOffsv.Tag = "Start";
                    btnStart.Text = "방 닫기";
                    portNumTxt.Enabled = false;

                    musicTitleMsg.Enabled = true;
                    musicStartBtn.Enabled = true;
                    hintBtn1.Enabled = true;
                    hintBtn2.Enabled = true;
                    hintBtn3.Enabled = true;
                    answerTxt.Enabled = true;
                    musicAnswerP.Enabled = true;
                }
                else
                {
                    chatServer.Stop();
                    foreach (Socket soket in Server.clientSocketArray)
                    {
                        soket.Close();
                    }
                    clientSocketArray.Clear();

                    OnOffsv.Text = "방 닫기";
                    OnOffsv.Tag = "Stop";
                    btnStart.Text = "방 열기";
                    txtChatMsg.Text = "";
                    portNumTxt.Enabled = true;

                    musicTitleMsg.Enabled = false;
                    musicStartBtn.Enabled = false;
                    hintBtn1.Enabled = false;
                    hintBtn2.Enabled = false;
                    hintBtn3.Enabled = false;
                    answerTxt.Enabled = false;
                    musicAnswerP.Enabled = false;
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
                    Server.clientSocketArray.Remove(socketClient);
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

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clientSocketArray.Count > 0)
            {
                chatServer.Stop();
                foreach (Socket soket in Server.clientSocketArray)
                {
                    soket.Close();
                }
                clientSocketArray.Clear();
            }

           Environment.Exit(0); // 테스트용
        }

        private void musicAnswerP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 적고 엔터키를 누르면 한라운드 끝
                // 정답자에게 점수를 추가해야한다
                string lstMessage = "./plus " + musicAnswerP.Text;
                if (lstMessage != null && lstMessage != "")
                {
                    txtChatMsg.Text = txtChatMsg.Text + "누군가에게 서버장님이 점수를 추가했습니다!" + "\r\n";
                    byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                    lock (Server.clientSocketArray)
                    {
                        // 접속해 있는 모든 클라이언트에게 글을 쓰는
                        foreach (Socket soket in Server.clientSocketArray)
                        {
                            NetworkStream stream = new NetworkStream(soket);
                            stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                        }
                    }
                }
            }
        }
        private string GetHtml(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string html = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return html;
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                return null;
            }
        }

        private string GetAudioUrl(string html)
        {
            int fintWord = html.IndexOf("adaptiveFormats") + 17; //+17
            if (fintWord == -1)
            {
                return null;
            }

            int start = html.IndexOf("[", fintWord);
            if (start == -1)
            {
                return null;
            }

            int end = html.IndexOf("]", start);
            if (end == -1)
            {
                return null;
            }

            string json = html.Substring(start, end - start + 1);

            if (!IsJson(json))
            {
                return null; // 만약 json 형식이 아니라면 null 반환
            }

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            foreach (var item in data)
            {
                string mimeType = item.mimeType;
                if (mimeType.StartsWith("audio/mp4"))
                {
                    string url = item.url;
                    return url;
                }
            }

            return null;
        }
        private bool IsJson(string input)
        {
            try
            {
                JToken.Parse(input);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        private void musicStartBtn_Click(object sender, EventArgs e)
        {
            // 누르면 실행하는 코드
            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("먼저 검색을 실행하세요.");
                return;
            }

            videoId = videoId.Trim();
            string videoUrl = $"https://www.youtube.com/watch?v={videoId}";
            string html = GetHtml(videoUrl);
            if (html == null)
            {
                MessageBox.Show("비디오를 재생할 수 없습니다.");
                return;
            }

            audioUrl = GetAudioUrl(html);
            if (audioUrl == null)
            {
                MessageBox.Show("오디오를 재생할 수 없습니다.");
                return;
            }

            string mpv_path = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\MPV\\mpv.exe";

            audioProcess = new Process();
            audioProcess.StartInfo.FileName = mpv_path; // mpv.exe 파일 경로를 입력하세요.
            audioProcess.StartInfo.Arguments = $"--no-video {audioUrl}";
            audioProcess.StartInfo.UseShellExecute = false;
            audioProcess.StartInfo.RedirectStandardOutput = true;
            audioProcess.StartInfo.CreateNoWindow = true;
            audioProcess.Start();
            lblStatus.Text = "재생 중";

            timer.Stop();
            elapsedTime = 0;
            labelTimer.Text = "0";
            timer.Start();

            // 모든 클라이언트들에게 노래실행 코드와 제목을 보내는 방법은?
            string lstMessage = "./start " + musicTitleMsg.Text;
            if (lstMessage != null && lstMessage != "")
            {
                txtChatMsg.Text = txtChatMsg.Text + "게임실행버튼을 서버장이 눌렀습니다." + "\r\n";
                byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                lock (Server.clientSocketArray)
                {
                    // 접속해 있는 모든 클라이언트에게 글을 쓰는
                    foreach (Socket soket in Server.clientSocketArray)
                    {
                        NetworkStream stream = new NetworkStream(soket);
                        stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                    }
                }
            }
        }

        private void hintBtn1_Click(object sender, EventArgs e)
        {
            // 모든 클라이언트들에게 힌트1실행 코드를 보내는 방법은?
            string lstMessage = "./hint1";
            if (lstMessage != null && lstMessage != "")
            {
                txtChatMsg.Text = txtChatMsg.Text + "힌트1버튼을 서버장이 눌렀습니다." + "\r\n";
                byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                lock (Server.clientSocketArray)
                {
                    // 접속해 있는 모든 클라이언트에게 글을 쓰는
                    foreach (Socket soket in Server.clientSocketArray)
                    {
                        NetworkStream stream = new NetworkStream(soket);
                        stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                    }
                }
            }
        }

        private void hintBtn2_Click(object sender, EventArgs e)
        {
            // 모든 클라이언트들에게 힌트2실행 코드를 보내는 방법은?
            string lstMessage = "./hint2";
            if (lstMessage != null && lstMessage != "")
            {
                txtChatMsg.Text = txtChatMsg.Text + "힌트2버튼을 서버장이 눌렀습니다." + "\r\n";
                byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                lock (Server.clientSocketArray)
                {
                    // 접속해 있는 모든 클라이언트에게 글을 쓰는
                    foreach (Socket soket in Server.clientSocketArray)
                    {
                        NetworkStream stream = new NetworkStream(soket);
                        stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                    }
                }
            }
        }

        private void hintBtn3_Click(object sender, EventArgs e)
        {
            // 모든 클라이언트들에게 힌트2실행 코드를 보내는 방법은?
            string lstMessage = "./hint3";
            if (lstMessage != null && lstMessage != "")
            {
                txtChatMsg.Text = txtChatMsg.Text + "힌트3버튼을 서버장이 눌렀습니다." + "\r\n";
                byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                lock (Server.clientSocketArray)
                {
                    // 접속해 있는 모든 클라이언트에게 글을 쓰는
                    foreach (Socket soket in Server.clientSocketArray)
                    {
                        NetworkStream stream = new NetworkStream(soket);
                        stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                    }
                }
            }
        }

        private void musicStopBtn_Click(object sender, EventArgs e)
        {
            if (audioProcess != null && !audioProcess.HasExited)
            {
                audioProcess.Kill();
                lblStatus.Text = "중지됨";
            }

            timer.Stop();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = musicTitleMsg.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("검색어를 입력하세요.");
                return;
            }

            SearchResource.ListRequest listRequest = youtubeService.Search.List("snippet");
            listRequest.Q = query;
            listRequest.MaxResults = 1;

            SearchListResponse searchListResponse = listRequest.Execute();
            if (searchListResponse.Items.Count == 0)
            {
                MessageBox.Show("검색 결과가 없습니다.");
                return;
            }

            SearchResult result = searchListResponse.Items[0];
            videoId = result.Id.VideoId;
            lblTitle.Text = result.Snippet.Title;
            //lblDescription.Text = result.Snippet.Description;
            lblStatus.Text = "비디오를 재생할 수 있습니다.";
            musicStartBtn.Enabled = true;
        }
    }

    public class ClientHandler
    {
        private TextBox txtChatMsg;
        private Socket socketClient;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Server sv;

        public void ClientHandler_Setup(Server sv, Socket socketClient, TextBox txtChatMsg)
        {
            this.txtChatMsg = txtChatMsg;
            this.socketClient = socketClient;
            this.netStream = new NetworkStream(socketClient);
            Server.clientSocketArray.Add(socketClient); // 클라이언트 소켓을 List에 담음
            this.strReader = new StreamReader(netStream);
            this.sv = sv;
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
                        if (lstMessage.StartsWith("./name ") == true) // 닉네임 정보를 저장하는 if문
                        {
                            sv.dataset.Tables["clientINFO"].Rows.Add(new object[] { lstMessage.Substring(7), 0 });
                        }
                        sv.SetText(lstMessage + "\r\n"); // delegate를 사용
                        byte[] bytSand_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n");
                        lock (Server.clientSocketArray)
                        {
                            // 접속해 있는 모든 클라이언트에게 글을 쓰는
                            foreach (Socket soket in Server.clientSocketArray)
                            {
                                NetworkStream stream = new NetworkStream(soket);
                                stream.Write(bytSand_Data, 0, bytSand_Data.Length);
                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("채팅 오류 :" + ex.Message);
                    Server.clientSocketArray.Remove(socketClient);
                    break;
                }
            }
        }
    }
}
