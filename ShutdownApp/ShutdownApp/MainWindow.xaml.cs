﻿using System.Windows;
using System.Windows.Threading;
using ShutdownApp.Program;
using System;

namespace ShutdownApp
{
    public partial class MainWindow : Window
    {

        private ShutdownProcess _shutdownProcess = new ShutdownProcess();
        private InitialCheck _initialCheck = new InitialCheck();
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        private TimeSpan _shutdownTime;
        private TimeSpan _remainingTime;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);        
        }

        private void ButtonSet_Click(object sender, RoutedEventArgs e)
        {
            int minutes;

            if (!int.TryParse(textSet.Text, out minutes))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                _shutdownProcess.SetShutdownTaskSheduler(minutes);
                SetTimer();

                buttonCancel.IsEnabled = true;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _shutdownProcess.CancelShutdownTaskSheduler();
            SetTimer();

            buttonCancel.IsEnabled = false;
        }

        private void SetTimer()
        {
            if (_initialCheck.CheckRunShutdown())
            {
                _shutdownTime = new TimeSpan(_initialCheck.Hour, _initialCheck.Minutes, _initialCheck.Seconds);

                _dispatcherTimer.Interval = new TimeSpan(0,0,0);
                _dispatcherTimer.Start();
            }
            else
            {
                _dispatcherTimer.Stop();

                timer.Content = "";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            _remainingTime = _shutdownTime - timeNow;
            timer.Content = _remainingTime.ToString();
        }

        
    }
}
