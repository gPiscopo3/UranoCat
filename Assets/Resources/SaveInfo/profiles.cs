using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profiles
{
    public List<Profile> profiles;
    public Profile last_profile;


   

    public Profiles() { }

  

    public class Profile
    {
        public string id { get; set; }
        public string name;
        public string last_save;

        public Profile() { }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.id.Equals(((Profile)obj).id);


    }
    }
}
