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
            ToDoSequencer toDoSequencer1 = new ToDoSequencer(); // toDoID set as 0

            int toDoSequencer1Id = toDoSequencer1.NextToDoId(); // 1
            Assert.Equal(1, toDoSequencer1Id);
            toDoSequencer1Id = toDoSequencer1.NextToDoId();     // 2

            ToDoSequencer toDoSequencer2 = new ToDoSequencer(); // toDoID already set (static)
            int toDoSequencer2Id = toDoSequencer2.NextToDoId(); // 3     
            Assert.Equal(3, toDoSequencer2Id);

            ToDoSequencer.Reset();                              // 0   Resets on toDoSequencer1
            toDoSequencer2Id = toDoSequencer2.NextToDoId();     // 1   Gets a new number from toDoSequencer2 
            Assert.Equal(1, toDoSequencer2Id);

        }
    }
}
