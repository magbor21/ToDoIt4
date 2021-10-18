using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Data;

namespace ToDoIt4.Model
{
    public class ToDo
    {

        private readonly int todoId;
        private readonly string description;
        private bool done;
        private Person assignee;

        public int ToDoId
        { get { return todoId; } }

        public string Description
        { get { return description; } }


        public ToDo(int todoId, string description)
        {
            if (todoId < 0)
                throw new ArgumentException("The ToDo ID can't be a negative value");
            this.todoId = todoId;

            if (description == null || description.Length == 0)
                throw new ArgumentException("Description can't be empty or null");

            this.description = description;
            this.done = false;

        }

        public ToDo(string description)
        {
            this.todoId = ToDoSequencer.NextToDoId();
            this.description = description;
            this.done = false;
        }

        public Person AssignedTo
        { get { return assignee; } }

        public bool Assign(Person person)
        {
            if (person != null)
            {
                this.assignee = person;
                return true;
            }
            return false;
        }


        public bool IsDone
        { get { return done; } }
        
        
        
        public void DoneIt()
        {
            if (this.assignee == null)
                throw new Exception("Unassigned ToDo items can't be completed");
            //else
            done = true;
        }


    }
}
