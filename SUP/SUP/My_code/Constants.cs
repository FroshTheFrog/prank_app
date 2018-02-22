﻿using SUP.My_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUP
{
    public class Constants
    {
        //windows message id for hot-key
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        //The ids for windows volume control
        public const int APPCOMMAND_VOLUME_UP = 0xA0000;
        public const int WM_APPCOMMAND = 0x319;

        public const int WrongAnswerMax = 5;

        //1000 = 1 sec
        public const int TestAgainTime = 15000;

        //The time that you have to wait for the app to start after a key event
        public const int WaitTime = 2000;

        //How long the app between setting the volume to max
        public const int VoluemeTime = 8000;

        //---------------------------Active times:-----------------------

        public static IReadOnlyList<ActiveTimeObj> VaildTimes = new List<ActiveTimeObj> {
        new ActiveTimeObj(DayOfWeek.Monday, new List<int> {1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Tuesday, new List<int> {1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Wednesday, new List<int> {1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Thursday, new List<int> {1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Friday, new List<int> { 1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Saturday, new List<int> {1200, 2359}),
        new ActiveTimeObj(DayOfWeek.Sunday, new List<int> { 1200, 2359})
        };




    };


}