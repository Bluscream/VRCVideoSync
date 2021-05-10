using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDLSharp;
using WK.Libraries.SharpClipboardNS;
using System.Text.RegularExpressions;
using System.IO;

namespace VRCVideoSync
{
    public partial class MainForm : Form
    {
        public VideoList videoList;

        public YoutubeDL ytdl;
        public SharpClipboard clipboard;

        public static Regex url = new Regex(@"^((?:https?:)?\/\/)?((?:www|m)\.)?((?:youtube\.com|youtu.be))(\/(?:[\w\-]+\?v=|embed\/|v\/)?)([\w\-]+)(\S+)?$");
        public MainForm()
        {
            InitializeComponent();
            ytdl = new YoutubeDL();
            videoList = new VideoList(new FileInfo(@"S:\Steam\steamapps\common\VRChat\UserData\UHModz\Videos.txt"));
            lst_urls.DataSource = videoList.Videos;
            videoList.Load();
            clipboard = new SharpClipboard();
            clipboard.ClipboardChanged += ClipboardChanged;

        }

        public async void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType != SharpClipboard.ContentTypes.Text) return;
            Uri uri;
            var isUri = Uri.TryCreate(uriString: clipboard.ClipboardText, uriKind: UriKind.Absolute, out uri);
            if (!isUri) return;
            if (!url.IsMatch(uri.AbsoluteUri)) return;
            await videoList.Add(ytdl, uri);
            lst_urls.Update(); lst_urls.Refresh();
        }

        public async void txt_url_KeyUp(object sender, KeyEventArgs e)
        {
            await videoList.Add(ytdl, new Uri(txt_url.Text));
            lst_urls.Update(); lst_urls.Refresh();
        }

    }
}