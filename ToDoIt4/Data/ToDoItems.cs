using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Model;

namespace ToDoIt4.Data
{
    public class ToDoItems
    {
        private static ToDo[] toDoArray = new ToDo[0];

        public int Size()
        {
            return toDoArray.Length;
        }

        public ToDo[] FindAll()
        {
            return toDoArray;

        }

        public ToDo FindById(int toDoId)
        {
            for (int i = 0; i < toDoArray.Length; i++) // will skip if array is empty
                if (toDoArray[i].ToDoId == toDoId)                
                    return toDoArray[i];

            throw new ArgumentOutOfRangeException("toDoId","There is no ToDo with that ID among the ToDoItems");
        }

        public ToDo NewToDo(string description)
        {
            
            int newID;
            bool idIsUsed;
            do
            {
                idIsUsed = false;
                newID = ToDoSequencer.NextToDoId();  //Asks for a new number

                for (int i = 0; i < toDoArray.Length; i++) //checks if it has already been used
                {
                    if (toDoArray[i].ToDoId == newID)
                        idIsUsed = true;
                }

            } while (idIsUsed); // If used, go back and ask for a new number
            
            ToDo newToDo = new ToDo(newID, description); //Any exceptions gets thrown from ToDo
            Array.Resize(ref toDoArray, toDoArray.Length + 1);
            toDoArray[toDoArray.Length - 1] = newToDo;
            return newToDo;
        }

        public void Clear()
        {
            if (toDoArray.Length > 0)
            {
                Array.Clear(toDoArray, 0, toDoArray.Length); // removes the entries
                Array.Resize(ref toDoArray, 0);   //resizes the array
                ToDoSequencer.Reset();
            }
            
        }
    }
}
