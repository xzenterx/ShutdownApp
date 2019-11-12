using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ShutdownApp.Program
{
    public class SaveComponent
    {
        public async void SaveProfiles(List<Profile> profiles)
        {
            using(FileStream file = new FileStream("profiles.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(file, profiles);
            }
        }

        /*public void LoadProfiles(List<Profile> profiles)
        {
            using (FileStream file = new FileStream("profiles.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Deserialize<Profile>(file));
            }
        }*/

    }
}
