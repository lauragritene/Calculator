using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack st = new Stack();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nStack MENU");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. See the Top values.");
                Console.WriteLine("3. Pop");
                Console.WriteLine("4. Add");
                Console.WriteLine("5. Sub");
                Console.WriteLine("6. Display values");
                Console.WriteLine("7. Exit");
                Console.Write("Select your choice: ");
                int choice = 0;
                string choice_case = Console.ReadLine();
                if(!string.IsNullOrEmpty(choice_case))
                {
                    choice = Convert.ToInt32(choice_case);
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter an value : ");
                        string value_string = Console.ReadLine();
                        int elem;
                        if (int.TryParse(value_string, out elem))
                        {
                            st.Push(elem);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Value is not correct type.");
                            break;
                        }

                    case 2:
                        Console.WriteLine("Top value is: {0}", st.Peek());
                        break;

                    case 3:
                        Console.WriteLine("Value removed: {0}", st.Pop());
                        break;

                    case 4:
                       st.Add();
                        break;

                    case 5:
                        st.Sub();
                        break;
                    case 6:
                        st.Display();
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;

                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }
    interface StackADT
    {
        Boolean isEmpty();
        void Push(Object element);
        Object Pop();
        Object Peek();
        void Add();
        void Sub();
        void Display();
    }
    class Stack : StackADT
    {
        private int StackSize;
        public int StackSizeSet
        {
            get { return StackSize; }
            set { StackSize = value; }
        }
        public int top;
        Object[] item;
        public Stack()
        {
            StackSizeSet = 5;
            item = new Object[StackSizeSet];
            top = -1;
        }
        public Stack(int capacity)
        {
            StackSizeSet = capacity;
            item = new Object[StackSizeSet];
            top = -1;
        }
        public bool isEmpty()
        {
            if (top == -1) return true;

            return false;
        }
        public void Push(object element)
        {
            if (top == (StackSize - 1))
            {
                Console.WriteLine("Stack is full!");
            }
            else
            {

                item[++top] = element;
                Console.WriteLine("Item pushed successfully!");
            }
        }
        public object Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return "No values";
            }
            else
            {
                return item[top--];
            }
        }
        public void Add()
        {
            if (isEmpty())
            {

                Console.WriteLine("Stack is empty! No values");
            }
            else if (top < 1)
            {
                Console.WriteLine("Not enough values in Stack");

            }
            else
            {
                int sum = Convert.ToInt32(item[top]) + Convert.ToInt32(item[top - 1]);
                Pop();
                Pop();
                Push(sum);
                Console.WriteLine(sum);
            }
            
        }

        public object Peek()
        {
            if (isEmpty())
            {

                Console.WriteLine("Stack is empty!");
                return "No values";
            }
            else
            {
                return item[top];
            }
        }
        public void Display()
        {
            for (int i = top; i > -1; i--)
            {

                Console.WriteLine("Item {0}: {1}", (i + 1), item[i]);
            }
        }
        public void Sub()
        {
            if (isEmpty())
            {

                Console.WriteLine("Stack is empty! No values");
            }
            else if(top < 1 )
            {
                Console.WriteLine("Not enough values in Stack");
                
            }
            else
            {
                int sub = Convert.ToInt32(item[top]) - Convert.ToInt32(item[top - 1]);
                Pop();
                Pop();
                Push(sub);
                Console.WriteLine(sub);
            }
            
        }
    }
}
