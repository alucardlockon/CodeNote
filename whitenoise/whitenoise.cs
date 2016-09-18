using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CodeNote.whitenoise
{
    public partial class Whitenoise : Form
    {
        
        public Whitenoise()
        {
            InitializeComponent();
        }

        private void whitenoise_Load(object sender, EventArgs e)
        {
            BindPlayList();
            btn_play_Click(sender, null);
        }

        private void Whitenoise_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void BindPlayList()
        {
            DirectoryInfo root = new DirectoryInfo("sound");

            FileInfo[] rootfinfos = root.GetFiles();

            var tn = new List<string>();
            foreach (FileInfo finfo in rootfinfos)
            {
                if (finfo.Extension == ".mp3")
                {
                    var treeNode = "";
                    treeNode = finfo.Name;
                    tn.Add(treeNode);
                }
            }
            playlist.Items.AddRange(tn.ToArray());
        }

        /// <summary>
        /// 播放
        /// </summary>
        private void btn_play_Click(object sender, EventArgs e)
        {
            if (playlist.Items.Count > 0)
            {
                if (playlist.SelectedIndex == -1) //默认选择从0开始播放
                {
                    PlayOrPauseSound(0);
                }
                else
                {
                    PlayOrPauseSound(playlist.SelectedIndex);
                }
            }
        }

        public void PlayOrPauseSound(int listIndex)
        {
            string filename = "sound/"+playlist.Items[listIndex].ToString();
            WMPLib.IWMPMedia a = axWindowsMediaPlayer1.newMedia(filename);
            axWindowsMediaPlayer1.currentPlaylist.clear();
            axWindowsMediaPlayer1.currentPlaylist.appendItem(a);
            axWindowsMediaPlayer1.Ctlcontrols.play();//播放
            axWindowsMediaPlayer1.settings.setMode("loop", true);//循环播放
            //axWindowsMediaPlayer1.Ctlcontrols.stop();//停止 
        }

        private void playlist_DoubleClick(object sender, EventArgs e)
        {
            btn_play_Click(sender, e);
        }

    }
}
