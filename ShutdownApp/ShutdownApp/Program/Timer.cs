using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ShutdownApp.Program
{
    public class Timer
    {

        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        private TimeSpan _shutdownTime;
        private TimeSpan _remainingTime;

        public void InitializeTimer(EventHandler timerTick)
        {
            _dispatcherTimer.Tick += new EventHandler(timerTick);
        }

        public void SetTimer(InitialCheck initialCheck)
        {
            initialCheck.GetNextRunTime();
            _shutdownTime = initialCheck.Time;

            _dispatcherTimer.Interval = new TimeSpan();
            _dispatcherTimer.Start();
        }

        public void CancelTimer(Label timer)
        {
            _dispatcherTimer.Stop();

            timer.Content = string.Empty;
        }

        public void Tick(Label timer)
        {
            TimeSpan timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            _remainingTime = _shutdownTime - timeNow;
            timer.Content = $"{_remainingTime.Hours}:{_remainingTime.Minutes}:{_remainingTime.Seconds}";
        }

        public void SetInitTimer(InitialCheck initialCheck, Button buttonCancel)
        {
            if (initialCheck.CheckRunShutdown())
            {
                SetTimer(initialCheck);
                buttonCancel.IsEnabled = true;
            }
        }
    }
}
