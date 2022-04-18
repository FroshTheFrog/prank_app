using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Windows.Input;

namespace Intel_Thermal_Management.Code
{
    class HotkeyControl : Form
    {
        //Hot-key checkers
        private KeyHandler CheckSpace;
        private KeyHandler CheckEnter;

        //The timer for when the app starts after a key is pressed
        public System.Timers.Timer ShowMe;

        System.Timers.Timer appStartAgainWait;


        public HotkeyControl()
        {

            //Timer for when the program shows up
            ShowMe = new System.Timers.Timer{Interval = Constants.KeyPressWaitTime, Enabled = false};

            appStartAgainWait = new System.Timers.Timer { Interval = Constants.StartAgainWaitTime, Enabled = false};
            appStartAgainWait.Elapsed += OnTimedEvent;

            //Set of the hot key events
            CheckSpace = new KeyHandler(Keys.Space, this);
            CheckSpace.Register();

            CheckEnter = new KeyHandler(Keys.Enter, this);
            CheckEnter.Register();
        }

        //The function that is called when a hot-key is pressed
        private void HandleHotkey()
        {

            //No that it does not get stuck in a loop during the SendKeys.SendWait function
            CheckEnter.Unregiser();
            CheckSpace.Unregiser();

            //So that they keys will still register
            //Windows hooks remaps the key
            if (Keyboard.IsKeyDown(Key.Enter))
                SendKeys.SendWait("{ENTER}");
            else
                SendKeys.SendWait(" ");

            //Reset the hot-keys
            CheckSpace.Register();
            CheckEnter.Register();

            if (appStartAgainWait.Enabled == false)
            {
                //If the current time in valid to start the app
                for (int i = 0; i < Constants.VaildTimes.Count(); i++)
                {
                    if (Constants.VaildTimes[i].IsVaildTime(DateTime.Now))
                    {
                        ShowMe.Enabled = true;
                        appStartAgainWait.Enabled = true;
                    }
                }

            }

        }

        // called when the appStartAgainWait timer ends
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            appStartAgainWait.Enabled = false;

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}
