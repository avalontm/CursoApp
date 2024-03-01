using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace CursoApp
{
    public static class YTManager
    {
        public static async Task<bool> VideoDownload(string videoUrl)
        {
            var youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(videoUrl);

            if(video == null)
            {
                return false; 
            }

            var title = video.Title; 
            var author = video.Author.ChannelTitle; 
            var duration = video.Duration;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Duracion: {duration}");

            return true;
        }
    }
}
