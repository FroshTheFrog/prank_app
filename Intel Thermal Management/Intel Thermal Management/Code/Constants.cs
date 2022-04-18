using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_Thermal_Management.Code
{
    public class Constants
    {
        // windows message id for hot-key
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        // The ids for windows volume control
        public const int APPCOMMAND_VOLUME_UP = 0xA0000;
        public const int WM_APPCOMMAND = 0x319;

        public const int WrongAnswerMax = 5;

        // 1000 = 1 sec
        public const int TestAgainTime = 15000;

        // The time that you have to wait for the app to start after a key event
        public const int KeyPressWaitTime = 60;

        // The time in between two incances of the app starting
        public const int StartAgainWaitTime = 7200 * 1000;

        // How long the app between setting the volume to max
        public const int VoluemeTime = 8000;

        // the height of a button in a 1080 screen
        public const int buttonHeight = 70;

        // How much the a button grows it width due to its number of characters in it's answer
        public const int ButtonWidthCoefficient = 25;

        // the border around a button's text in width
        public const int ButtonBorder = 3;

        public const string AppName = "Intel Thermal Management";

        public const string WrongAnswerSound = @"Sounds\Wrong.wav";
        public const string CorrectAnswerSound = @"Sounds\Correct.wav";

        // ---------------------------Active times:-----------------------

        public static IReadOnlyList<ActiveTimeObj> VaildTimes = new List<ActiveTimeObj> {
        new ActiveTimeObj(DayOfWeek.Monday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Tuesday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Wednesday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Thursday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Friday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Saturday, new List<int> {0, 2359}),
        new ActiveTimeObj(DayOfWeek.Monday, new List<int> {0, 2359}),
        };
    };
}