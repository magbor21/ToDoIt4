using System;
using ToDoIt4.Model;
using ToDoIt4.Data;


namespace ToDoIt4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            People pople = new People();
            ToDoItems tdi = new ToDoItems();

            pople.NewPerson("Tom", "Armstrong");
            pople.NewPerson("Mark", "Bonanno");
            pople.NewPerson("Broden", "Kelly");
            new Person("Samuel", "Lingham");
            pople.NewPerson("Max", "Miller");
            pople.NewPerson("Zachary", "Ruane");

            tdi.NewToDo("Walk");
            tdi.NewToDo("Run");
            tdi.NewToDo("Jump");
            tdi.NewToDo("Land");
            tdi.NewToDo("Duck");
            tdi.NewToDo("Zach");

            Person[] utd = pople.FindAll();

            for(int i = 0; i<utd.Length;i++)
            {
                Console.WriteLine("{0} {1} {2}", utd[i].FirstName, utd[i].LastName, utd[i].PersonId);

            }

            tdi.Assign(1, utd[0]);
            tdi.Assign(2, utd[1]);
            tdi.Assign(3, utd[2]);
            tdi.Assign(4, utd[3]);
            tdi.Assign(5, utd[4]);

            Person foundPerson = pople.FindById(3);
            Console.WriteLine(foundPerson.FirstName);







        }
    }
}
