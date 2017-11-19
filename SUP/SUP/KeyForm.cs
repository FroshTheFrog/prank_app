using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SUP
{
    class KeyForm : Form
    {

        private KeyHandler CheckSpace;
        private KeyHandler CheckEnter;

        //1000 = 1 sec
        public int TimerTime = 2000;
        public System.Timers.Timer ShowMe;


        public KeyForm()
        {

            //Timer for when the program shows up
            ShowMe = new System.Timers.Timer{Interval = TimerTime, Enabled = false};

            //Set of the hot key events
            CheckSpace = new KeyHandler(Keys.Space, this);
            CheckSpace.Register();

            CheckEnter = new KeyHandler(Keys.Enter, this);
            CheckEnter.Register();
        }

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
