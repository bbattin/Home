using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> numbers = new LinkedList<int>();

            numbers.AddLast(1); // вставляем узел со значением 1 на последнее место
            // так как в списке нет узлов, то последнее будет также и первым
            numbers.AddFirst(2); // вставляем узел со значением 2 на первое место
            numbers.AddAfter(numbers.Last, 3); // вставляем после последнего узла новый узел со значением 3
            // теперь у нас список имеет следующую последовательность: 2, 1, 3
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            LinkedList<Person> persons = new LinkedList<Person>();

            // добавляем person в список и получим объект LinkedListNode<Person>, в котором хранится имя Tom
            LinkedListNode<Person> tom = persons.AddLast(new Person() { Name = "Tom" });

            persons.AddLast(new Person() { Name = "John" });
            persons.AddFirst(new Person() { Name = "Bill" });

            Console.WriteLine(tom.Previous.Value.Name); // получаем узел перед томом и его значение
            Console.WriteLine(tom.Next.Value.Name); // получаем узел после тома и его значение

            Console.ReadLine();
        }
    }
}

