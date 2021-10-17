using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class PersonSequencer
    {
        private static int personId = 0;

        public static int NextPersonId()
        {
            return ++personId;
        }


        public static int Reset()
        { 
            personId = 0;
            return 0;
        }

    }
}
