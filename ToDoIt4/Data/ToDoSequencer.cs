using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class ToDoSequencer
    {
        private static int toDoId = 0;
        static int nextToDoId{ get {return ++toDoId; } }

        public int NextToDoId()
        {
            return nextToDoId;
        }


        static int reset()
        { 
            toDoId = 0;
            return toDoId;
        }
        
        public int Reset()
        {
            return reset();
        }


    }
}
