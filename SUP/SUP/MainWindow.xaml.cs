using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SUP
{

    public partial class MainWindow : Window
    {
        //The obj that contains hotkeys and timer for starting the app
        static HotkeyControl k;

        //The obj that contains the functions for turning up the volume
        public static VolumeControl v;

        //A reference to the window's self so that it can be accessed by other functions
        static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();

            v = new VolumeControl();
            //setup volume control timer
            v.SetMaxVolumeTime.Elapsed += OnTimedEventVolume;

            main = this;

            k = new HotkeyControl();

            //Set of hotkey timer
            k.ShowMe.Elapsed += OnTimedEvent;


            //So that the window can't the covered
            Topmost = true;

            //Add closing blocking func to the main window cloing event so that the window can't closed
            Closing += MainWindow_Closing;

            ////So that it can't be minimized
            //!StateChanged += TriedToCloseMe;

            Hide();

            //The path of the video file
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Videos\Rick_it_up.mp4");

            //Set vidplay's source
            VidPlayer.Source = new Uri(path, UriKind.Absolute);

            //Get the with of the primary screen and set it to the media element width
            VidPlayer.Width = SystemParameters.PrimaryScreenWidth;

            //Stretch the media element's hight in a uniform way
            VidPlayer.Stretch = Stretch.Uniform;

            //The highest the volume can be
            VidPlayer.Volume = 1;

            //Make the application fullscreen
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

        }

        //Attached to the event for when the volume controller ends
        private static void OnTimedEventVolume(Object source, System.Timers.ElapsedEventArgs e)
        {
            v = new VolumeControl();
            v.SetToMaxVolume();
        }


        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Only one thread can access it
            main.Dispatcher.Invoke(() =>
            {
                main.Show();
            });

            //Set volume timer
            v = new VolumeControl();
            v.SetToMaxVolume();

            //Turn off other timer
            k.ShowMe.Interval = k.TimerTime;
            k.ShowMe.Enabled = false;

        }

        //Cancel window closing event keeping the user from being able to close the window
        private void MainWindow_Closing(object sender, CancelEventArgs e) { e.Cancel = true; }

        void TriedToCloseMe(object sender, EventArgs e)
        {
            //Only one thread can access it
            WindowState = WindowState.Maximized;
        }
    }
}
