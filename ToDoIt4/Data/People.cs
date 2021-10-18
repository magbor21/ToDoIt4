using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt4.Model;

namespace ToDoIt4.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0]; // Persons are stored here

        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll() //returns all the People
        {
            return personArray;

        }

        public Person FindById(int personId)
        {
            for (int i = 0; i < personArray.Length; i++) // will skip if array is empty
                if (personArray[i].PersonId == personId)                
                    return personArray[i];  //returns the person

            throw new ArgumentOutOfRangeException("personId","There is no Person with that ID among the People"); // Can't find person
        }

        public Person NewPerson(string firstName, string lastName) //Adds a new Person
        {
                       
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

            Array.Resize(ref personArray, personArray.Length + 1); //resizes and adds person at the end
            personArray[personArray.Length - 1] = newPerson;
            return newPerson;
        }

        public void Clear() //removes all the persons from People
        {
            if (personArray.Length > 0)
            {
                Array.Clear(personArray, 0, personArray.Length); // removes the entries
                Array.Resize(ref personArray, 0);   //resizes the array
                PersonSequencer.Reset();
            }
            
        }

        public bool Remove(int personId) // Finds and removes a single person
        {
            for(int i = 0; i < personArray.Length;i++) 
            {
                if (personArray[i].PersonId == personId) // finds person
                {
                    for(int j=i+1;j< personArray.Length;j++) 
                    {
                        personArray[j - 1] = personArray[j]; // moves everyone after up one in the array
                    }

                    Array.Resize(ref personArray, personArray.Length - 1); // removes the last position of the array
                    return true;

                }

            }
            return false;

        }
    }
}
