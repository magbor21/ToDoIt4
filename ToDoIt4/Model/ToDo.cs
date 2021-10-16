using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Model
{
    class ToDo
    {

        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public ToDo(int todoId, string description)
        {
            if (todoId = null)
                throw new ArgumentNullException("The ToDo ID can't be null");
            this.todoId = todoId;

            if (description == null || description.Length == 0)
                throw new ArgumentException("Description can't be empty or null");

            this.description = description;
            this.done = false;

        }
        

    }
}
