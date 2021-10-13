using System;
using ToDoIt4.Model;

namespace ToDoIt4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person person = null;
            Person person2 = new Person("Sven", "Olsson");
            person = new Person("Kalle", "Banan");

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.PersonId);
            Console.WriteLine(person2.FirstName);
            Console.WriteLine(person2.PersonId);


        }
    }
}
