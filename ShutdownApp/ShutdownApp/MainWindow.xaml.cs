using System.Windows;
using System.Windows.Threading;
using ShutdownApp.Program;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

namespace ShutdownApp
{
    public partial class MainWindow : Window
    {

        private ShutdownProcess _shutdownProcess = new ShutdownProcess();
        private InitialCheck _initialCheck = new InitialCheck();
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        private TimeSpan _time;
        private TimeSpan _shutdownTime;
        private TimeSpan _remainingTime;

        private List<Profile> _profiles;

        private SaveComponent _saveComponent = new SaveComponent();


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

            _profiles = new List<Profile>
            {
                new Profile("Base", new TimeSpan(1,0,0)),
                new Profile("Serial", new TimeSpan(1,10,0)),
                new Profile("Film", new TimeSpan(2,30,0))
            };
        }

        private void ButtonSet_Click(object sender, RoutedEventArgs e)
        {   
            if (!int.TryParse(textSetHours.Text, out int hours))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else if (!int.TryParse(textSetMinutes.Text, out int minutes))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                _time = new TimeSpan(hours, minutes, 0);
                _shutdownProcess.SetShutdownTaskSheduler(_time);
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
            timer.Content = $"{_remainingTime.Hours}:{_remainingTime.Minutes}:{_remainingTime.Seconds}";
        }

        private void CreateNewProfile(string name)
        {
            if (!int.TryParse(textSetHours.Text, out int hours))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else if (!int.TryParse(textSetMinutes.Text, out int minutes))
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                _time = new TimeSpan(hours, minutes, 0);
                var profile = new Profile(name, _time);
                _profiles.Add(profile);
                profilesBox.Items.Add(_profiles.Last());
            }
        }

        private void SetProfile(Profile profile)
        {
            if (profile != null)
            {
                _time = profile.Time;
                textSetHours.Text = profile.Time.Hours.ToString();
                textSetMinutes.Text = profile.Time.Minutes.ToString();
            }
        }

        private void DeleteProfile(Profile profile)
        {
            profilesBox.Items.Remove(profile);
            profilesBox.SelectedItem = profilesBox.Items[0];
        }

        private void ProfilesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var profile = profilesBox.SelectedItem;
            SetProfile((Profile)profile);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProfile(textSetName.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var profile = profilesBox.SelectedItem;
            DeleteProfile((Profile)profile);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _saveComponent.SaveProfiles(_profiles);
        }
    }
}
