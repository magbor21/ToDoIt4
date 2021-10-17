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

            people.NewPerson("Tom", "Armstrong");

            var exception = Record.Exception(() => people.NewPerson("", "Bonanno"));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("First Name can't be empty or null", exception.Message);

            var exception2 = Record.Exception(() => people.NewPerson("Broden", ""));
            Assert.NotNull(exception2);
            Assert.IsType<ArgumentException>(exception2);
            Assert.Equal("Last Name can't be empty or null", exception2.Message);

            Person zach = people.NewPerson("Zachary","Ruane");
            Assert.Equal("Zachary", zach.FirstName);
            Assert.Equal(5, zach.PersonId);

            Assert.Equal(2, people.Size());


        }




    }
}
