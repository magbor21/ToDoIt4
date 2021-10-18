using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Data;

namespace ToDoIt4.Model
{
    public class ToDo // class for single ToDo items
    {

        private readonly int todoId;
        private readonly string description;
        private bool done;
        private Person assignee;

        public int ToDoId
        { get { return todoId; } }

        public string Description // Descriptions can only be set at Creation
        { get { return description; } }


        public ToDo(int todoId, string description)   // Creates a ToDo item
        {
            if (todoId < 0)
                throw new ArgumentException("The ToDo ID can't be a negative value");
            this.todoId = todoId;

            if (description == null || description.Length == 0)
                throw new ArgumentException("Description can't be empty or null");

            this.description = description;
            this.done = false; // New items can't be done

        }

        public ToDo(string description) // Collects a todoID from ToDoSequencer and uses that at creation
        {
            this.todoId = ToDoSequencer.NextToDoId();
            this.description = description;
            this.done = false;
        }

        public Person AssignedTo // who is this item assigned to?
        { get { return assignee; } }

        public bool Assign(Person person) //Assign a person to this item
        {
            if (person != null)
            {
                this.assignee = person;
                return true;
            }
            return false;
        }


        public bool IsDone // Has the item been completed by the assignee
        { get { return done; } }
        
        
        
        public void DoneIt() // Checks items as completed
        {
            if (this.assignee == null)
                throw new Exception("Unassigned ToDo items can't be completed");
            //else
            done = true;
        }


    }
}
