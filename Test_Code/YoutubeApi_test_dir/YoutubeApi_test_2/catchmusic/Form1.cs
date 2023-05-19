using System;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using YoutubeExplode.Videos;
using Newtonsoft.Json;

////AIzaSyCXYRYadXpJP9AzdPidWCYKVO_Xj5wcQM4

namespace catchmusic
{
    public partial class Form1 : Form
    {
        private YouTubeService youtubeService;
        private string videoId;
        private string audioUrl;
        private Process audioProcess;

        public Form1()
        {
            InitializeComponent();
            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCXYRYadXpJP9AzdPidWCYKVO_Xj5wcQM4", // Google API Console에서 생성한 인증키를 입력하세요.
                ApplicationName = this.GetType().ToString()
            });
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
            int start = html.IndexOf("adaptiveFormats");
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
            if (!json.StartsWith("["))
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
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
            lblDescription.Text = result.Snippet.Description;
            lblStatus.Text = "비디오를 재생할 수 있습니다.";
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
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

            audioProcess = new Process();
            audioProcess.StartInfo.FileName = "mpv.exe"; // mpv.exe 파일 경로를 입력하세요.
            audioProcess.StartInfo.Arguments = $"--no-video {audioUrl}";
            audioProcess.StartInfo.UseShellExecute = false;
            audioProcess.StartInfo.RedirectStandardOutput = true;
            audioProcess.StartInfo.CreateNoWindow = true;
            audioProcess.Start();
            lblStatus.Text = "재생 중";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (audioProcess != null && !audioProcess.HasExited)
            {
                audioProcess.Kill();
                lblStatus.Text = "중지됨";
            }
        }
    }


    


}

