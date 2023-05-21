using System;
using System.Collections.Generic;

namespace cs_examples
{
    public static class StackSorting
    {
        public static void Start()
        {
            Stack<int> stack = new Stack<int>();

            // Push elements into the stack
            stack.Push(5);
            stack.Push(3);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);

            Console.WriteLine("Original Stack:");
            PrintStack(stack);

            // Sort the stack in ascending order
            Stack<int> sortedStack = SortStack(stack);

            Console.WriteLine("Sorted Stack:");
            PrintStack(sortedStack);
        }

        static Stack<int> SortStack(Stack<int> stack)
        {
            Stack<int> sortedStack = new Stack<int>();

            while (stack.Count > 0)
            {
                int temp = stack.Pop();

                // Move elements from sortedStack to stack
                while (sortedStack.Count > 0 && sortedStack.Peek() > temp)
                {
                    stack.Push(sortedStack.Pop());
                }

                // Push temp in sorted order to sortedStack
                sortedStack.Push(temp);
            }

            return sortedStack;
        }

        static void PrintStack(Stack<int> stack)
        {
            foreach (int element in stack)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}