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
            var exception = Record.Exception(() => new (null, "Städa garderoben"));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("The ToDo ID can't be null", exception.Message);

        }

        [Fact]
        public void ConstructorDescription()
        {
            var exception = Record.Exception(() => new(23,"");
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Description can't be empty or null", exception.Message);

        }

    }
}
