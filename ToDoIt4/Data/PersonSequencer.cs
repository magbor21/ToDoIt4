using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class PersonSequencer
    {
        private static int personId = 0;

        public static int NextPersonId() // Adds 1 to personID and returns it
        {
            return ++personId;
        }


        public static int Reset() // Resets counter to 0. Next number will be 1;
        { 
            personId = 0;
            return 0;
        }

    }
}
