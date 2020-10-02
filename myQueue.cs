using System;
using System.Collections.Generic;
using System.Collections;

/*
    1. Розробити клас власної узагальненої колекції, використовуючи
стандартні інтерфейси колекцій із бібліотек System.Collections та
System.Collections.Generic. Стандартні колекції при розробці власної
не застосовувати. Для колекції передбачити методи внесення даних
будь-якого типу, видалення, пошуку та ін. (відповідно до типу
колекції).
    2. Додати до класу власної узагальненої колекції підтримку подій та
обробку виключних ситуацій.
    3. Опис класу колекції та всіх необхідних для роботи з колекцією типів
зберегти у динамічній бібліотеці.
    4. Створити консольний додаток, в якому продемонструвати
використання розробленої власної колекції, підписку на події колекції.
 */

namespace myCollection
{
    public class myQueue<T> : IEnumerable<T>
    {
        public delegate void Checking(string message);
        public event Checking Notify;
        private Node<T> Head;
        private Node<T> Tail;
        private Node<T> temp;
        private Node<T> node;
        private static int counter = 0;
        public void AddFirst(T value)
        {
            node = new Node<T>(value);
            temp = this.Head;
            node.Next = temp;
            Head = node;
            if (counter == 0)
                Tail = Head;
            else
                temp.Previous = node;
            Notify?.Invoke($"'{value}' was added to the head.");
            counter++;
        }
        public void AddLast(T value)
        {
            node = new Node<T>(value);
            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Notify?.Invoke($"'{value}' was added to the tail.");
            counter++;
        }
        public T RemoveFirst()
        {
            if (counter == 0)
                throw new InvalidOperationException();
            T output = Head.Value;
            Notify?.Invoke($"'{Head.Value}' was removed from the head.");
            if (counter == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            counter--;
            return output;
        }
        public T RemoveLast()
        {
            if (counter == 0)
                throw new InvalidOperationException();
            T output = Tail.Value;
            Notify?.Invoke($"'{Tail.Value}' was removed from the tail.");
            if (counter == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            counter--;
            return output;
        }
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Head.Value;
            }
        }
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Tail.Value;
            }
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            counter = 0;
        }
        public int Count { get { return counter; } }
        public bool IsEmpty { get { return counter == 0; } }
        public bool Contains(T value)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        public void Read()
        {
            if (counter == 0) Notify?.Invoke("Double Node structure is empty. Create it first.");
            else
            {
                foreach (var node in this)
                {
                    Console.WriteLine(node);
                }

                Console.WriteLine(node);
            }
        }
    }


    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { set; get; }
        public Node<T> Next { set; get; }
        public Node<T> Previous { set; get; }
    }
}
