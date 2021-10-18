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
            var exception = Record.Exception(() => new Person("Sven", "")); // empty strings are not welcome
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Last Name can't be empty or null", exception.Message);

        }
        
        [Fact]
        public void PersonIdentityNumber()
        {
            Person person = null;
            new Person("Sven", "Olsson");           // 1
            new Person("Tom", "Olsson");            // 2
            new Person("Kalle", "Olsson");          // 3
            person = new Person("Kalle", "Banan");  // 4

            Assert.Equal(4, person.PersonId);

        }        

    }
}
