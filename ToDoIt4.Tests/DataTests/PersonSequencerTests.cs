using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Data;

namespace ToDoIt4.Tests.DataTests
{
    public class PersonSequencerTests
    {
        
        [Fact]
        public void ConstructorAndNextNumber()
        {
            //PersonSequencer personSequencer1 = new PersonSequencer(); // personID set as 0

            int cs1Id = PersonSequencer.NextPersonId(); // 1
            Assert.Equal(1, cs1Id);
            PersonSequencer.NextPersonId();     // 2

            // PersonSequencer personSequencer2 = new PersonSequencer(); // personID already set (static)
            int cs2Id = PersonSequencer.NextPersonId(); // 3     
            Assert.Equal(3, cs2Id);

            PersonSequencer.Reset();                     // 0   Resets on personSequencer
            cs2Id = PersonSequencer.NextPersonId();     // 1   Gets a new number from personSequencer2 
            Assert.Equal(1, cs2Id);

        }
        
    }
}
