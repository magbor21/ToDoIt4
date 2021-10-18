using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Model;

namespace ToDoIt4.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];

        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll()
        {
            return personArray;

        }

        public Person FindById(int personId)
        {
            for (int i = 0; i < personArray.Length; i++) // will skip if array is empty
                if (personArray[i].PersonId == personId)                
                    return personArray[i];

            throw new ArgumentOutOfRangeException("personId","There is no Person with that ID among the People");
        }

        public Person NewPerson(string firstName, string lastName)
        {
            // PersonSequencer personSequencer = new PersonSequencer();
            
            int newID;
            bool idIsUsed;
            do
            {
                idIsUsed = false;
                newID = PersonSequencer.NextPersonId();  //Sets a new number
                
                for (int j = 0; j < personArray.Length; j++) //checks if it has already been used
                {
                    if (personArray[j].PersonId == newID)
                        idIsUsed = true;
                }
                
            } while (idIsUsed);
            
            Person newPerson = new Person(firstName, lastName, newID); //Any exceptions gets thrown from Person
            Array.Resize(ref personArray, personArray.Length + 1);
            personArray[personArray.Length - 1] = newPerson;
            return newPerson;
        }

        public void Clear()
        {
            if (personArray.Length > 0)
            {
                Array.Clear(personArray, 0, personArray.Length); // removes the entries
                Array.Resize(ref personArray, 0);   //resizes the array
                PersonSequencer.Reset();
            }
            
        }
    }
}
