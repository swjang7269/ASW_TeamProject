using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catchmusic
{
    class MusicPlayerMain
    {
        private readonly YouTubeAPI youtubeAPI;

        public MusicPlayerMain()
        {
            youtubeAPI = new YouTubeAPI();
        }

        public void PlayMusic(string searchQuery)
        {
            youtubeAPI.PlayMusic(searchQuery);
        }
    }
}
