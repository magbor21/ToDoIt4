using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt4.Model
{
    public class Person
    {
        private static int idCounter = 0;
        private readonly int personId;
        private string firstName;
        private string lastName;
        
        public int PersonId
        { get { return personId; } }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("First Name can't be empty or null");

                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Last Name can't be empty or null");

                lastName = value;
            }
        }


        public Person(string firstName, string lastName)
        {
            this.personId = ++idCounter;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }
}
