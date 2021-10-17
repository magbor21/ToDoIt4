using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Data;
using ToDoIt4.Model;

namespace ToDoIt4.Tests.DataTests
{
    public class PeopleTests
    {

        [Fact]
        public void AddingPeople()
        {
            People people = new People();

            people.NewPerson("Tom", "Armstrong"); // 1 success

            var exception = Record.Exception(() => people.NewPerson("", "Bonanno")); // 2 failed
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("First Name can't be empty or null", exception.Message);

            var exception2 = Record.Exception(() => people.NewPerson("Broden", "")); // 3 failed
            Assert.NotNull(exception2);
            Assert.IsType<ArgumentException>(exception2);
            Assert.Equal("Last Name can't be empty or null", exception2.Message);

            Person zach = null; // 4
            zach = people.NewPerson("Zachary","Ruane"); // 5 success
            Assert.Equal("Zachary", zach.FirstName);
            Assert.Equal(5, zach.PersonId); // <- 5

            Assert.Equal(2, people.Size()); // 2

            people.Clear();

        }
        [Fact]
        public void FindingPeople()
        {
            People people2 = new People();
            Person[] persons = people2.FindAll();
            Assert.Empty(persons);

            people2.NewPerson("Tom", "Armstrong");
            people2.NewPerson("Mark", "Bonanno");
            people2.NewPerson("Broden", "Kelly");
            people2.NewPerson("Samuel", "Lingham");
            people2.NewPerson("Max", "Miller");
            people2.NewPerson("Zachary", "Ruane");

            Person foundPerson = people2.FindById(4);
            Assert.Equal("Broden", foundPerson.FirstName); 
            
            var exception = Record.Exception(() => people2.FindById(11)); 
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("There is no Person with that ID among the People (Parameter 'personId')", exception.Message);

            people2.Clear();


        }


    }
}
