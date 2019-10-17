using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShutdownApp.Program
{
    public class ShautdownProcess
    {
        private int _seconds;

        private void SetTime(int minutes)
        {
            int seconds = minutes * 60;
            _seconds = seconds;
        }

        public void SetSutdown(int minutes)
        {
            SetTime(minutes);
            ProcessStartInfo processShutdown = new ProcessStartInfo("cmd", $"/c shutdown -s -f -t {_seconds}" );
            Process.Start(processShutdown);
        }
    }
}
