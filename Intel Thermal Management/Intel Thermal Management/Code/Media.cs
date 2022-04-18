using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_Thermal_Management.Code
{
    public class Media
    {

        //A list of all the video paths that will be played
        public List<string> videos;

        //For random numbers
        readonly Random rnd;
        

        public Media()
        {
            rnd = new Random();

            videos = new List<string>();

            SetVideos();

        }

        //Reset the video for the play list
        void SetVideos()
        {
            string folder = "Videos";
            string[] videosInFolder = Directory.GetFiles(folder);
            foreach (string video in videosInFolder)
            {
                videos.Add(video); 
                Console.WriteLine(video);
            } 
        }

        //Get a video that will be played by the media element
        public string GetVideo()
        {

            if (videos.Count() == 0)
            {
                SetVideos();
            }

            //The video that will be played
            string v = videos[rnd.Next(videos.Count())];

            //Remove so that there is no repeats
            videos.Remove(v);

            return v;

        }




    }
}
