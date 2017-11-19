using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SUP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static KeyForm k;

        static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();

            main = this;
            k = new KeyForm();
            k.ShowMe.Elapsed += OnTimedEvent;

            Hide();

        string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Videos\Rick_it_up.mp4");

            VidPlayer.Width = SystemParameters.PrimaryScreenWidth;;

            VidPlayer.Stretch = Stretch.Uniform;

            VidPlayer.Source = new Uri(path, UriKind.Absolute);


            //Make the app fullscreen
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Only one thread can access it
            main.Dispatcher.Invoke(() => {
                main.Show();
            });

            k.ShowMe.Interval = k.TimerTime;
            k.ShowMe.Enabled = false;

        }

        private void VidPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

        }
    }
}
