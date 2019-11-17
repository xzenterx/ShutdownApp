using System.Windows;
using ShutdownApp.Program;
using System;
using System.Windows.Controls;

namespace ShutdownApp
{
    public partial class MainWindow : Window
    {

        private ShutdownProcess _shutdownProcess = new ShutdownProcess();
        private InitialCheck _initialCheck = new InitialCheck();
        private Timer _timer = new Timer();
        private SaveComponent _saveComponent = new SaveComponent();
        private WorkWithProfile _workWithProfile = new WorkWithProfile();

        private TimeSpan _time;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _timer.InitializeTimer(TimerTick);
            _timer.SetInitTimer(_initialCheck, buttonCancel);
            
            _workWithProfile.InitializeProfiles(_saveComponent, profilesBox);
        }

        private void ButtonSetClick(object sender, RoutedEventArgs e)
        {   
            if (!int.TryParse(textSetHours.Text, out int hours))
            {
                MessageBox.Show("Please, enter hours.");
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

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            _shutdownProcess.CancelShutdownTaskSheduler();
            _timer.CancelTimer(timer);

            buttonCancel.IsEnabled = false;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Tick(timer);
        }

        private void ProfilesBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (profilesBox.SelectedItem == profilesBox.Items[0])
            {
                buttonDeleteProfile.IsEnabled = false;
            }
            else
            {
                buttonDeleteProfile.IsEnabled = true;

                var profile = profilesBox.SelectedItem as Profile;
                _workWithProfile.SetProfile(profile, textSetHours, textSetMinutes, _time);
            }
        }

        private void ButtonSaveProfileClick(object sender, RoutedEventArgs e)
        {
            _workWithProfile.CreateNewProfile(textSetName.Text, textSetHours, textSetMinutes, _time, profilesBox);
        }

        private void ButtonDeleteProfileClick(object sender, RoutedEventArgs e)
        {
            var profile = profilesBox.SelectedItem as Profile;
            _workWithProfile.DeleteProfile(profile, profilesBox);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _saveComponent.SaveProfiles(_workWithProfile._profiles);
        }

    }
}
