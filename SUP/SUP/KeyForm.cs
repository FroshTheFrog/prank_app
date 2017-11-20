using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SUP
{
    class HotkeyControl : Form
    {
        //Hot-key checkers
        private KeyHandler CheckSpace;
        private KeyHandler CheckEnter;
        private KeyHandler CheckE;

        //1000 = 1 sec
        public int TimerTime = 2000;
        //The timer for when the app starts after a key is pressed
        public System.Timers.Timer ShowMe;


        public HotkeyControl()
        {

            //Timer for when the program shows up
            ShowMe = new System.Timers.Timer{Interval = TimerTime, Enabled = false};

            //Set of the hot key events
            CheckSpace = new KeyHandler(Keys.Space, this);
            CheckSpace.Register();

            CheckEnter = new KeyHandler(Keys.Enter, this);
            CheckEnter.Register();

            CheckE = new KeyHandler(Keys.E, this);
            CheckE.Register();
        }

        //The function that is called when a hot-key is pressed
        private void HandleHotkey()
        {
            ShowMe.Enabled = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}
