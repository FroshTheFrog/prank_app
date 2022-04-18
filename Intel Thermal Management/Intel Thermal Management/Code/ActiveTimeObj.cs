﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_Thermal_Management.Code
{
    public class ActiveTimeObj
    {
        public DayOfWeek day;

        //Hour+min
        public List<int> times;


        public ActiveTimeObj (DayOfWeek myDay, List<int> myTimes)
        {

            day = myDay;
            times = myTimes;

        }

        //Returns if it is a valid time for the app to run
        public bool IsVaildTime(DateTime currentTime)
        {

            if(currentTime.DayOfWeek == day &&
                IsInRange((currentTime.Hour * 100) + currentTime.Minute))
                return true;

            return false;
        }

        //Returns if the current hours is in range
        bool IsInRange(int theTime)
        {

            for (int i = 0; i < times.Count(); i+= 2)
            {
                if (theTime >= times[i] && theTime <= times[i + 1])
                    return true;
            }
            return false;

        }
    }
}
