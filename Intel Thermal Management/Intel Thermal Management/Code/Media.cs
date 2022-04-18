﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelCooler.My_code
{
    public class Media
    {

        //A list of all the video paths that will be played
        public List<string> videos;

        //For random numbers
        Random rnd;
        

        public Media()
        {
            rnd = new Random();

            videos = new List<string>();

            SetVideos();

        }

        //Reset the video for the play list
        void SetVideos()
        {
            //videos.Add("...video path...");
        }

        //Get a video that will be played by the media element
        public string GetVideo()
        {

            if (videos.Count() == 0)
                SetVideos();

            //The video that will be played
            string v = videos[rnd.Next(videos.Count())];

            //Remove so that there is no repeats
            videos.Remove(v);

            return v;

        }




    }
}
