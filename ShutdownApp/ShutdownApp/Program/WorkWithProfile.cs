using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ShutdownApp.Program
{
    public class WorkWithProfile
    {

        public List<Profile> _profiles { get; private set; }

        public void InitializeProfiles(SaveComponent saveComponent, ComboBox profilesBox)
        {
            _profiles = new List<Profile>();

            if (saveComponent.LoadProfiles() != null)
            {
                _profiles.AddRange(saveComponent.LoadProfiles());
            }

            if (!_profiles.Exists(p => p.Name == "Base"))
            {
                _profiles.Insert(0, new Profile("Base", new TimeSpan(1, 0, 0)));
            }

            if (_profiles != null)
            {
                foreach (var profile in _profiles)
                {
                    profilesBox.Items.Add(profile);
                }
            }

            profilesBox.SelectedItem = profilesBox.Items[0];

        }

        public void CreateNewProfile(string name, TextBox textSetHours, TextBox textSetMinutes, TimeSpan time, ComboBox profilesBox)
        {
            if (!int.TryParse(textSetHours.Text, out int hours) && hours >= 0)
            {
                MessageBox.Show("Please, enter hours.");
            }
            else if (!int.TryParse(textSetMinutes.Text, out int minutes) && minutes > 0)
            {
                MessageBox.Show("Please, enter minutes.");
            }
            else
            {
                time = new TimeSpan(hours, minutes, 0);
                var profile = new Profile(name, time);
                _profiles.Add(profile);
                profilesBox.Items.Add(_profiles.Last());
                profilesBox.SelectedItem = profilesBox.Items[profilesBox.Items.Count-1];
            }
        }

        public void DeleteProfile(Profile profile, ComboBox profilesBox)
        {
            profilesBox.Items.Remove(profile);
            profilesBox.SelectedItem = profilesBox.Items[0];
            _profiles.Remove(profile);
        }

        public void SetProfile(Profile profile, TextBox textSetHours, TextBox textSetMinutes, TimeSpan time)
        {
            if (profile != null)
            {
                time = profile.Time;
                textSetHours.Text = profile.Time.Hours.ToString();
                textSetMinutes.Text = profile.Time.Minutes.ToString();
            }
        }
    }
}
