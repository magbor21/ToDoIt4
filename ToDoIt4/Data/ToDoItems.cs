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
                if(toDoArray[m].IsDone == doneStatus) // Finds all items that are/aren't done.
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[m]; // adds items to a new array
                }

            }

            return resultArray; // return new array

        }

        public ToDo[] FindByAssignee(int personId) // finds items based on who it is assigned to
        {
            ToDo[] resultArray = new ToDo[0];

            for (int n = 0; n < toDoArray.Length; n++)
            {
                if (toDoArray[n].AssignedTo.PersonId == personId)  //finds items
                {
                    Array.Resize(ref resultArray, resultArray.Length + 1);
                    resultArray[resultArray.Length - 1] = toDoArray[n];  // adds them to a new array
                }

            }

            return resultArray; //Returns the new array

        }

        public ToDo[] FindByAssignee(Person assignee) // the same as above but using a whole Person instead of just a number
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

        public ToDo[] FindUnassignedTodoItems() // finds and returns todo items not assigned to anyone yet
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

        public bool DoneIt(int todoID) // marks completed ToDo items as done
        {
            for (int s = 0; s < toDoArray.Length; s++)
            {

                if ((toDoArray[s].ToDoId == todoID) && (toDoArray[s].AssignedTo != null)) //only assigned items can be completed
                {
                    toDoArray[s].DoneIt();
                    return true;
                }
            }
            return false; 
        }

        public bool Remove(int todoId) // finds and removes a ToDo Item
        {
            for (int i = 0; i < toDoArray.Length; i++)
            {
                if (toDoArray[i].ToDoId == todoId) //finds it
                {
                    for (int j = i + 1; j < toDoArray.Length; j++)
                    {
                        toDoArray[j - 1] = toDoArray[j]; // moves the rest up one position
                    }

                    Array.Resize(ref toDoArray, toDoArray.Length - 1); //deletes the last post
                    return true;

                }

            }
            return false; // could not find anything to remove

        }

    }
}
