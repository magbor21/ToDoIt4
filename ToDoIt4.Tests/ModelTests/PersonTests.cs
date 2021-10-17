using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Model;

namespace ToDoIt4.Tests.ModelTests
{
    public class PersonTests
    {
        [Fact]
        public void Constructor()
        {
            var exception = Record.Exception(() => new Person("Sven", ""));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Last Name can't be empty or null", exception.Message);

        }

        [Fact]
        public void PersonIdentityNumber()
        {
            //Person person = null;
            Person person2 = new Person("Sven", "Olsson");
            Person person = new Person("Kalle", "Banan");

            Assert.Equal(3, person.PersonId);

        }



    }
}
