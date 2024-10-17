using System;



public class Profile{
        public string name;
        public string last_save;
        public DateTime dateTime;

        public Profile() { }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.name.Equals(((Profile)obj).name);

    }
    
}
