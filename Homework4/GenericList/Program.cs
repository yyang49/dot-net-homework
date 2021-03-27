using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (Node<T> node = head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);list.Add(2);list.Add(3);list.Add(4);list.Add(5);
            list.ForEach(s => Console.WriteLine(s));
            int max = list.Head.Data;
            list.ForEach(i => max = i > max ? i : max);
            Console.WriteLine("最大值是" + max);
            int min = list.Head.Data;
            list.ForEach(i => min = min > i ? i : min);
            Console.WriteLine("最小值是" + min);
            int sum = 0;
            list.ForEach(i => sum += i);
            Console.WriteLine("和为" + sum);
            Console.ReadLine();
        }
    }
}
