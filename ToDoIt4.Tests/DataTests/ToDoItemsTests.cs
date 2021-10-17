using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt4.Data;
using ToDoIt4.Model;

namespace ToDoIt4.Tests.DataTests
{
    public class ToDoTests
    {

        [Fact]
        public void AddingToDoItems()
        {
            ToDoItems toDoItems = new ToDoItems();

            toDoItems.NewToDo("Do the Dishes"); // 1 success

            var exception = Record.Exception(() => toDoItems.NewToDo("")); // 2 failed
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("First Name can't be empty or null", exception.Message);

            ToDo car = null; // 3
            car = toDoItems.NewToDo("Wash the car"); // 4 success
            Assert.Equal("Wash the car", car.Description);
            Assert.Equal(4, car.ToDoId); // <- 4

            Assert.Equal(2, toDoItems.Size()); // 2

            toDoItems.Clear();

        }
        [Fact]
        public void FindingToDo()
        {
            ToDoItems toDoItems2 = new ToDoItems();
            ToDo[] toDos = toDoItems2.FindAll();
            Assert.Empty(toDos);

            toDoItems2.NewToDo("Walk");
            toDoItems2.NewToDo("Run");
            toDoItems2.NewToDo("Jump");
            toDoItems2.NewToDo("Land");
            toDoItems2.NewToDo("Duck");
            toDoItems2.NewToDo("Zach");

            ToDo foundTodo = toDoItems2.FindById(4);
            Assert.Equal("Land", foundTodo.Description); 
            
            var exception = Record.Exception(() => toDoItems2.FindById(12)); 
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("There is no ToDo with that ID among the ToDoItems (Parameter 'toDoId')", exception.Message);

            toDoItems2.Clear();


        }


    }
}
