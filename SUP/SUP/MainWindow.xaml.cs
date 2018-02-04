using SUP.My_code;
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

        //The questions that will be used for the test
        public static Test MyTest;

        //The number of right answers that the user has answered in a row
        public static int AnswerIndex = 0;

        public static int WrongAnswerIndex = 0;

        //The answer to the current question
        public string TheAnswer;

        public const int WrongAnswerMax = 5;

        //if the app can close
        public static bool CanClose = false;


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

            //Add closing blocking func to the main window closing event so that the window can't closed
            Closing += MainWindow_Closing;

            ////So that it can't be minimized
            StateChanged += TriedToCloseMe;

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


            //Hind everything user the question event is triggered
            textBlock.Visibility = Visibility.Hidden;
            QuestionText.Visibility = Visibility.Hidden;
            TextRightAnswers.Visibility = Visibility.Hidden;
            TextWrongAnswers.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;

            TextWrongAnswers.Text = "Wrong Answers Left: " + (WrongAnswerMax - WrongAnswerIndex).ToString();
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
        private void MainWindow_Closing(object sender, CancelEventArgs e) {

            if(!CanClose)
                e.Cancel = true;

            QuetionEvent();


        }

        void TriedToCloseMe(object sender, EventArgs e)
        {
            //Only one thread can access it
            WindowState = WindowState.Maximized;
        }

        private void textBlock_TextChanged(object sender, TextChangedEventArgs e)
        {


        }



        void SetNextQuesiton()
        {

            //So that is program can have random numbers
            Random rnd = new Random();

            //The Question that will be used
            Question q = MyTest.TheQuetions[rnd.Next(MyTest.TheQuetions.Count())];

            TheAnswer = q.AnsList[3];

            QuestionText.Text = q.TheQuestion;

            //Random answers for each button
            button.Content = q.AnsList[rnd.Next(q.AnsList.Count())];
            q.AnsList.Remove(button.Content.ToString());

            button1.Content = q.AnsList[rnd.Next(q.AnsList.Count())];
            q.AnsList.Remove(button1.Content.ToString());

            button2.Content = q.AnsList[rnd.Next(q.AnsList.Count())];
            q.AnsList.Remove(button2.Content.ToString());

            button3.Content = q.AnsList[0];
            q.AnsList.Remove(button3.Content.ToString());

            //So that the question can to be picked again
            MyTest.TheQuetions.Remove(q);
        }


        //When the user is asked to answer some questions to get their computer back
        void QuetionEvent()
        {

            //A reference to the lest of questions
            MyTest = new Test();


            textBlock.Text = "Oh! It looks like you want your computer back. Answer three right question in a row to get it back";

            //Make everything visible
            TextRightAnswers.Visibility = Visibility.Visible;
            TextWrongAnswers.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
            QuestionText.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;


            SetNextQuesiton();
        }


        //The function that is called when an answer is picked
        void OnButtonClick (Button b)
        {
            if (b.Content.ToString() == TheAnswer)
            {
                AnswerIndex += 1;

                //Close the app if the user gets three right answers in a row
                if (AnswerIndex == 3)
                {
                    CanClose = true;
                    Close();

                }

            }
            else
            {
                WrongAnswerIndex += 1;
                AnswerIndex = 0;

                if(WrongAnswerIndex == WrongAnswerMax)
                {
                    //TODO: need to add code
                }

                TextWrongAnswers.Text = "Wrong Answers Left: " + (WrongAnswerMax - WrongAnswerIndex).ToString();
            }

            TextRightAnswers.Text = "Right Answers: " + AnswerIndex.ToString();

            SetNextQuesiton();

        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClick(button3);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClick(button2);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClick(button1);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClick(button);

        }

    }
}
