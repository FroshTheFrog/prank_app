using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Intel_Thermal_Management.Code
{
    public class VolumeControl
    {
        private System.Timers.Timer SetMaxVolumeTimer;

        private CoreAudioDevice defaultPlaybackDevice;

        // Volume control constructor
        public VolumeControl()
        {
            // Instantiate the timer
            SetMaxVolumeTimer = new System.Timers.Timer { Interval = Constants.VoluemeTime, Enabled = true};

            this.defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

        }

        public void TurnOnVolumeTimer()
        {
            this.SetToMaxVolume();
            this.SetMaxVolumeTimer.Elapsed += SetToMaxVolumeEvent;
        }

        public void TurnOffVolumeTimer()
        {
            this.SetMaxVolumeTimer.Elapsed -= SetToMaxVolumeEvent;
            this.SetMaxVolumeTimer.Enabled = false;
        }

        /// <summary>
        /// Set the volume to max 
        /// </summary>
        private void SetToMaxVolume()
        {
            this.defaultPlaybackDevice.Volume = 100;
        }


        private void SetToMaxVolumeEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.SetToMaxVolume();
        }



    }
}
