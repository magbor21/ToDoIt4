using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Data;

namespace ToDoIt4.Model
{
    public class Person // Class for individual persons
    {
        private readonly int personId;
         
        private string firstName;
        private string lastName;
        
        public int PersonId
        { 
            get { return personId; }
           
        }


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


        public Person(string firstName, string lastName, int personId) // creates a person with a personID if given
        {
            this.personId = personId;
            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public Person(string firstName, string lastName) // gets a personID from PersonSequencer and vreates a person
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.personId = PersonSequencer.NextPersonId();

        }
    }
}
