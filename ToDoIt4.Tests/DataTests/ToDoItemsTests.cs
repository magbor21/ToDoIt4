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
            Assert.Equal("Description can't be empty or null", exception.Message);


            ToDo car = null;
            toDoItems.NewToDo("Wash the bear"); // 3 success

            car = toDoItems.NewToDo("Wash the car"); // 4 success

            Assert.Equal("Wash the car", car.Description);
            Assert.Equal(4, car.ToDoId); // <- 4

            Assert.Equal(3, toDoItems.Size()); // 3


        }


        [Fact]
        public void FindingToDoById() 
        {
            ToDoItems toDoItems2 = new ToDoItems();
            ToDo[] toDos = toDoItems2.FindAll();
            Assert.Empty(toDos); // starts with empty ToDoItems

            toDoItems2.NewToDo("Walk");
            toDoItems2.NewToDo("Run");
            new ToDo("Not included in ToDoItems");
            toDoItems2.NewToDo("Jump");
            toDoItems2.NewToDo("Land");
            toDoItems2.NewToDo("Duck");
            toDoItems2.NewToDo("Zach");

            toDos = toDoItems2.FindAll();
            Assert.Equal(6, toDos.Length); // six items, not seven
            Assert.Equal(7, toDos[5].ToDoId); // last todoId = 7


            ToDo foundTodo = toDoItems2.FindById(4); // find Jump
            Assert.Equal("Jump", foundTodo.Description);

            var exception = Record.Exception(() => toDoItems2.FindById(12)); 
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("There is no ToDo with that ID among the ToDoItems (Parameter 'toDoId')", exception.Message);

            toDoItems2.Clear();
        }


        [Fact]
        public void FindByNotDone()
        {
            ToDoItems toDoItems3 = new ToDoItems(); // Adds ToDo Items
            toDoItems3.NewToDo("Walk");
            toDoItems3.NewToDo("Run");
            toDoItems3.NewToDo("Jump");
            toDoItems3.NewToDo("Land");
            toDoItems3.NewToDo("Duck");
            toDoItems3.NewToDo("Zach");

            People people3 = new People(); // Adds persons
            people3.NewPerson("Tom", "Armstrong");
            people3.NewPerson("Mark", "Bonanno");
            people3.NewPerson("Broden", "Kelly");
            people3.NewPerson("Samuel", "Lingham");
            people3.NewPerson("Max", "Miller");
            people3.NewPerson("Zachary", "Ruane");

            for (int q = 1; q < 7; q++)
                toDoItems3.Assign(q, people3.FindById(q)); // adds first person to first ToDo and so on.

            for (int r = 0; r < 7; r += 2) // 2, 4 and 6 are Done
                toDoItems3.DoneIt(r); 

            ToDo[] todoResult = toDoItems3.FindByDoneStatus(false); //returned 1, 3 and 5

            Assert.Equal("Tom", todoResult[0].AssignedTo.FirstName);
            Assert.Equal("Broden", todoResult[1].AssignedTo.FirstName);
            Assert.Equal("Max", todoResult[2].AssignedTo.FirstName);

        }

        [Fact]
        public void FindByAssignee()
        {
            ToDoItems toDoItems3 = new ToDoItems();
            toDoItems3.NewToDo("Walk"); // Tom
            toDoItems3.NewToDo("Run");  // Mark
            toDoItems3.NewToDo("Jump"); // Broden
            toDoItems3.NewToDo("Land"); // Tom
            toDoItems3.NewToDo("Duck"); // Mark
            toDoItems3.NewToDo("Zach"); // Broden

            People people3 = new People();
            people3.NewPerson("Tom", "Armstrong");
            people3.NewPerson("Mark", "Bonanno");
            people3.NewPerson("Broden", "Kelly");

            for (int q = 0; q < 6; q++)
                toDoItems3.Assign((q + 1), people3.FindById(q % 3 + 1)); // 1 2 3 1 2 3

            ToDo[] todoResult = toDoItems3.FindByAssignee(3); // Broden

            Assert.Equal("Broden", todoResult[0].AssignedTo.FirstName); // Broden has 2 things to do
            Assert.Equal(2, todoResult.Length);

            ToDo[] todoResult2 = toDoItems3.FindByAssignee(people3.FindById(1));

            Assert.Equal("Tom", todoResult2[0].AssignedTo.FirstName); // Tom has 2 things to do
            Assert.Equal(2, todoResult2.Length);
        }

        [Fact]
        public void FindUnassigned()
        {
            ToDoItems toDoItems3 = new ToDoItems();
            toDoItems3.NewToDo("Walk"); // Unassigned
            toDoItems3.NewToDo("Run");
            toDoItems3.NewToDo("Jump");
            toDoItems3.NewToDo("Land"); // Unassigned
            toDoItems3.NewToDo("Duck");
            toDoItems3.NewToDo("Zach"); // Unassigned

            People people3 = new People();
            people3.NewPerson("Tom", "Armstrong");
            people3.NewPerson("Mark", "Bonanno");
            people3.NewPerson("Broden", "Kelly");

            toDoItems3.Assign(2, new Person("Mark", "Bonanno"));
            toDoItems3.Assign(3, new Person("Tom", "Armstrong"));
            toDoItems3.Assign(5, new Person("Broden", "Kelly"));

            ToDo[] todoResults = toDoItems3.FindUnassignedTodoItems();

            Assert.Equal(1, todoResults[0].ToDoId);
            Assert.Equal(4, todoResults[1].ToDoId);
            Assert.Equal(6, todoResults[2].ToDoId);

        }

        [Fact]
        public void RemoveItems()
        {
            ToDoItems toDoItems2 = new ToDoItems();
            ToDo[] toDos = toDoItems2.FindAll();
            Assert.Empty(toDos);

            toDoItems2.NewToDo("Walk");
            toDoItems2.NewToDo("Run"); // to be removed
            toDoItems2.NewToDo("Jump");
            toDoItems2.NewToDo("Land");
            toDoItems2.NewToDo("Duck");
            toDoItems2.NewToDo("Zach");

            toDos = toDoItems2.FindAll();
            Assert.Equal(6, toDos.Length);

            toDoItems2.Remove(2); // Run

            toDos = toDoItems2.FindAll();
            Assert.Equal(5, toDos.Length);

            var exception = Record.Exception(() => toDoItems2.FindById(2)); // it is gone
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("There is no ToDo with that ID among the ToDoItems (Parameter 'toDoId')", exception.Message);


        }
    }
}
