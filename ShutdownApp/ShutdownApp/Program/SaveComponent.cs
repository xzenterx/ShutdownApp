using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ShutdownApp.Program
{
    public class SaveComponent
    {
        public void SaveProfiles(List<Profile> profiles)
        {
            using(FileStream file = new FileStream("profiles.json", FileMode.OpenOrCreate))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Profile>));
                jsonSerializer.WriteObject(file, profiles);
            }
        }

        public List<Profile> LoadProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            using (FileStream file = new FileStream("profiles.json", FileMode.OpenOrCreate))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Profile>));
                profiles = jsonSerializer.ReadObject(file) as List<Profile>;
            }

            return profiles;
        }

    }
}
