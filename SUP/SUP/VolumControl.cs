using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUP
{
    public class VolumeControl : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        //1000 = 1 sec
        public int TimerTime = 8000;
        public System.Timers.Timer SetMaxVolumeTime;

        //Volume control constructor
        public VolumeControl()
        {
            //Instantiate the timer
            SetMaxVolumeTime = new System.Timers.Timer { Interval = TimerTime, Enabled = true};

        }

        /// <summary>
        /// Set the volume to max
        /// </summary>
        public void SetToMaxVolume()
        {
            for (int i = 0; i < 50; i++)
            {
                SendMessageW(this.Handle,Constants.WM_APPCOMMAND, this.Handle,
                (IntPtr) Constants.APPCOMMAND_VOLUME_UP);
            }
        }



    }
}
