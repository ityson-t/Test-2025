namespace Chapter8
{
    internal class MyStack<T>
    {
        const int MaxStack = 10;
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        bool IsStackEmpty { get { return StackPointer <= 0; } }
        T[] StackArray;
        int StackPointer = 0;
        public void Push(T x)
        {
            if (!IsStackFull)
            {
                StackArray[StackPointer++] = x;
            }
        }
        public T Pop()
        {
            return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
        }
        public MyStack()
        {
            StackArray = new T[MaxStack];
        }
        public void Print()
        {
            for (int i = StackPointer - 1; i >= 0; i--)
            {
                Console.WriteLine($"  Value:{StackArray[i]}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            MyStack<int> myIntStack = new MyStack<int>();
            myIntStack.Push(1);
            myIntStack.Push(3);
            myIntStack.Push(5);
            myIntStack.Push(7);
            myIntStack.Push(9);
            myIntStack.Print();
            myIntStack.Pop();
            myIntStack.Pop();
            Console.WriteLine();
            myIntStack.Print();
        }
    }
}


