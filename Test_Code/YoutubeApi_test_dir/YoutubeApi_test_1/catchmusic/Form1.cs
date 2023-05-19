using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Diagnostics;

namespace catchmusic
{
    public partial class Form1 : Form

    {
        private readonly YouTubeAPI youTubeAPI;

        public Form1()
        {
            InitializeComponent();
            youTubeAPI= new YouTubeAPI();
            //musicPlayer = new MusicPlayerMain();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //musicPlayer.PlayMusic(txtSearchQuery.Text);
            string searchQuery = txtSearchQuery.Text;
            youTubeAPI.PlayMusic(searchQuery);
        }
    }
}

public class YouTubeAPI
{
    private YouTubeService youtubeService;

    public YouTubeAPI()
    {
        // YouTube API 인증 및 서비스 생성
        youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyCXYRYadXpJP9AzdPidWCYKVO_Xj5wcQM4"
        });
    }

    public void PlayMusic(string searchQuery)
    {
        // YouTube에서 검색 쿼리에 해당하는 비디오 검색
        var searchListRequest = youtubeService.Search.List("snippet");
        searchListRequest.Q = searchQuery;
        searchListRequest.MaxResults = 1;
        var searchListResponse = searchListRequest.Execute();
        var videoId = searchListResponse.Items[0].Id.VideoId;

        // 검색 결과 중 첫 번째 비디오 ID를 사용하여 음악 재생 URL 생성
        var playerUrl = string.Format("http://www.youtube.com/v/{0}?version=3", videoId);

        // 음악 재생
        // TODO: 여기서 음악을 재생하는 코드 작성
        Process.Start(new ProcessStartInfo()
        {
            FileName = playerUrl,
            UseShellExecute = true,
            Verb = "open"
        });
    }
}