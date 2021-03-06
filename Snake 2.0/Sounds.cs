﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Snake_2._0
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
            player.URL = pathToMedia + "Background.wav";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }
        public void Play(string songName)
        {
            player.URL = pathToMedia + songName + ".wav";
            player.controls.play();
        }
        public void PlayEat()
        {
            player.URL = pathToMedia + "Eat.wav";
            player.settings.volume = 100;
            player.controls.play();
        }
        public void PlayLose()
        {
            player.URL = pathToMedia + "Lose.wav";
            player.settings.volume = 100;
            player.controls.play();
        }
        public void Stop()
        {
            player.URL = pathToMedia + "Background.wav";
            player.controls.stop();
        }
        public void Stop(string songName)
        {
            player.URL = pathToMedia + songName + ".wav";
            player.settings.volume = 0;
        }

    }
}
