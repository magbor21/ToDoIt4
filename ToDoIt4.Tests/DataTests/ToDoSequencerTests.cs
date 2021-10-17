using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Data;

namespace ToDoIt4.Tests.DataTests
{
    public class ToDoSequencerTests
    {

        [Fact]
        public void ConstructorAndNextNumber()
        {
            int toDoSequencer1Id = ToDoSequencer.NextToDoId(); // 1
            Assert.Equal(1, toDoSequencer1Id);
            toDoSequencer1Id = ToDoSequencer.NextToDoId();     // 2


            int toDoSequencer2Id = ToDoSequencer.NextToDoId(); // 3     
            Assert.Equal(3, toDoSequencer2Id);

            ToDoSequencer.Reset();                              // 0   Resets on toDoSequencer1
            toDoSequencer2Id = ToDoSequencer.NextToDoId();     // 1   Gets a new number from toDoSequencer2 
            Assert.Equal(1, toDoSequencer2Id);

        }
    }
}
