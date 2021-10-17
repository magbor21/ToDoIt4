using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Model;

namespace ToDoIt4.Tests.ModelTests
{
    public class ToDoTests
    {
        [Fact]
        public void ConstructorToDoId()
        {
            
            var exception = Record.Exception(() => new ToDo(-54, "Städa garderoben"));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("The ToDo ID can't be a negative value", exception.Message);

        }

        [Fact]
        public void ConstructorDescription()
        {
            var exception = Record.Exception(() => new ToDo(23,""));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Description can't be empty or null", exception.Message);

        }

    }
}
