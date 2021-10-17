using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class PersonSequencer
    {
        private static int personId = 0;
        static int nextPersonId{ get {return ++personId; } }

        public int NextPersonId()
        {
            return nextPersonId;
        }


        static int reset()
        { 
            personId = 0;
            return personId;
        }
        
        public int Reset()
        {
            return reset();
        }


    }
}
