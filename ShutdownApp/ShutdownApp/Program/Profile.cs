﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ShutdownApp.Program
{   
    [DataContract]
    public class Profile
    {   
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TimeSpan Time { get; set; }

        public Profile(string name, TimeSpan time)
        {
            Name = name;
            Time = time;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
