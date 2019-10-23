using System.Windows;
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
            if (_initialCheck.CheckRunShutdown())
            {
                SetTimer();
                buttonCancel.IsEnabled = true;
            }
            
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
            CancelTimer();

            buttonCancel.IsEnabled = false;
        }

        private void SetTimer()
        {
            _initialCheck.GetNextRunTime();
            _shutdownTime = _initialCheck.Time;

            _dispatcherTimer.Interval = new TimeSpan();
            _dispatcherTimer.Start();
        }

        private void CancelTimer()
        {
            _dispatcherTimer.Stop();

            timer.Content = string.Empty;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            _remainingTime = _shutdownTime - timeNow;
            timer.Content = _remainingTime.ToString();
        }

        
    }
}
