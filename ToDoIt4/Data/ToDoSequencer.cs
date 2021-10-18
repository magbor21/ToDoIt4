using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Data
{
    public class ToDoSequencer
    {
        private static int toDoId = 0; // Sets a counter to 0

        public static int NextToDoId() // adds one to the counter and returns it
        {
            return ++toDoId;
        }


        public static int Reset() //resets counter to 0
        { 
            toDoId = 0;
            return toDoId;
        }

    }
}
