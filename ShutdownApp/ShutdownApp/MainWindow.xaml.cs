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
        private Timer _timer = new Timer();

        private TimeSpan _time;

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
                _timer.SetTimer(_initialCheck);
                buttonCancel.IsEnabled = true;
            }

            _timer.InitializeTimer(Timer_Tick);

            _profiles = new List<Profile>();

            if (_saveComponent.LoadProfiles() != null)
            {
                _profiles = _saveComponent.LoadProfiles();
            }

            if (_profiles != null)
            {
                foreach (var profile in _profiles)
                {
                    profilesBox.Items.Add(profile);
                }
            }

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
                _timer.SetTimer(_initialCheck);

                buttonCancel.IsEnabled = true;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _shutdownProcess.CancelShutdownTaskSheduler();
            _timer.CancelTimer(timer);

            buttonCancel.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.TimerTick(timer);
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

        private void ButtonSaveProfileClick(object sender, RoutedEventArgs e)
        {
            CreateNewProfile(textSetName.Text);
        }

        private void ButtonDeleteProfileClick(object sender, RoutedEventArgs e)
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
