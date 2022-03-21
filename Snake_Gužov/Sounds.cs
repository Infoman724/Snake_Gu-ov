using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;

namespace Snake_Gužov
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            player.URL = pathToMedia + "music.mp3";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        public void Play(string songName)
        {
            player.URL = pathToMedia + songName + "music.mp3";
            player.controls.play();
        }
    
        public void PlayEat()
        {
            player.URL = pathToMedia + "eats.mp3";
            player.settings.volume = 100;
            player.controls.play();
        }
    }
}
