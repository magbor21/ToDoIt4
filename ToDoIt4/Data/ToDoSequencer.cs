using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class ToDoSequencer
    {
        private static int toDoId = 0;

        public static int NextToDoId() 
        {
            return ++toDoId;
        }


        public static int Reset()
        { 
            toDoId = 0;
            return toDoId;
        }

    }
}
