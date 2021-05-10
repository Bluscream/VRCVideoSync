using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCVideoSync
{
    public class VideoList
    {
        public FileInfo VideosFile;
        public List<Video> Videos;
        public VideoList(FileInfo videosFile)
        {
            this.VideosFile = videosFile;
            this.Load();
        }
        public List<Video> Load()
        {
            Videos = new List<Video>();
            StreamReader file = new StreamReader(this.VideosFile.FullName);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (String.IsNullOrWhiteSpace(line)) continue;
                var lineArray = line.Split('|');
                this.Videos.Add(new Video(lineArray[1], lineArray[0]));
            }
            file.Close();
            return this.Videos;
        }
        public void Save()
        {
            StreamWriter file = new StreamWriter(this.VideosFile.FullName);
            foreach (var video in this.Videos)
            {
                file.WriteLine(video.ToString());
            }
            file.Close();
        }
        public async Task<Video> Add(YoutubeDLSharp.YoutubeDL ytdl, Uri url, string title = "")
        {
            var video = this.Videos.FirstOrDefault(v => v.Url == url);
            if (video != null) return video;
            if (String.IsNullOrEmpty(title))
            {
                var res = await ytdl.RunVideoDataFetch(url.AbsoluteUri);
                title = res.Data.Title;
            }
            video = new Video(url, title);
            this.Videos.Add(video);
            this.Save();
            return video;
        }
        public Video Remove(Uri url)
        {
            var video = this.Videos.FirstOrDefault(v => v.Url == url);
            if (video is null) return null;
            Videos.Remove(video);
            this.Save();
            return video;
        }
        /*public async void UpdateAll()
        {
            List<Video> oldList = new List<Video>();
            Videos.CopyTo(oldList.ToArray());
            foreach (var video in Videos)
            {

            }
            oldList = newList;
        }*/
    }
    public class Video
    {
        public string Title { get; set; }
        public Uri Url { get; set; }
        public Video(string url, string title = null)
        {
            this.Url = new Uri(url); this.Title = title ?? url;
        }
        public Video(Uri url, string title = null)
        {
            this.Url = url; this.Title = title ?? url.AbsoluteUri;
        }
        public override string ToString()
        {
            return $"{this.Title}|{this.Url}";
        }
    }
}
