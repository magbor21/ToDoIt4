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
                
                for (int k = 0; k < toDoArray.Length; k++) //checks if it has already been used
                {
                    if (toDoArray[k].ToDoId == newID)
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

        public bool Assign(int toDoId, Person person)
        {
            for (int l = 0; l < toDoArray.Length; l++) // will skip if array is empty
                if (toDoArray[l].ToDoId == toDoId)
                {
                    toDoArray[l].Assign(person);
                    return true;
                }
                 
            return false;

        }

        public ToDo[] FindByDoneStatus(bool doneStatus)
        {
            ToDo[] resultArray = new ToDo[0];

            for(int m = 0; m < toDoArray.Length; m++)
            {
                if(toDoArray[m].IsDone == doneStatus)
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[m];
                }

            }

            return resultArray;

        }

        public ToDo[] FindByAssignee(int personId)
        {
            ToDo[] resultArray = new ToDo[0];

            for (int n = 0; n < toDoArray.Length; n++)
            {
                if (toDoArray[n].AssignedTo.PersonId == personId)
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[n];
                }

            }

            return resultArray;

        }

        public ToDo[] FindByAssignee(Person assignee)
        {
            ToDo[] resultArray = new ToDo[0];

            for (int o = 0; o < toDoArray.Length; o++)
            {
                if (toDoArray[o].AssignedTo == assignee)
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[o];
                }

            }

            return resultArray;

        }

        public ToDo[] FindUnassignedTodoItems()
        {
            ToDo[] resultArray = new ToDo[0];

            for (int p = 0; p < toDoArray.Length; p++)
            {
                if (toDoArray[p].AssignedTo == null)
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[p];
                }

            }

            return resultArray;

        }

        public bool DoneIt(int todoID)
        {
            for (int s = 0; s < toDoArray.Length; s++)
            {

                if (toDoArray[s].ToDoId == todoID && toDoArray[s].AssignedTo != null)
                {
                    toDoArray[s].DoneIt();
                    return true;
                }
            }
            return false;
        }

    }
}
