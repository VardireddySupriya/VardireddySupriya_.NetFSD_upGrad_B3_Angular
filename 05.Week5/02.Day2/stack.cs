using System;

class UndoSystem
{
    static void Main()
    {
        string[] stack = new string[10]; // array-based stack
        int top = -1;

        // Sample Actions
        PerformAction("Type A", stack, ref top);
        PerformAction("Type B", stack, ref top);
        PerformAction("Type C", stack, ref top);
        Undo(stack, ref top);
        Undo(stack, ref top);

        // Final Output
        Display(stack, top);
    }

    // PUSH operation
    static void PerformAction(string action, string[] stack, ref int top)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow!");
            return;
        }

        top++;
        stack[top] = action;

        Console.WriteLine("After Action: " + action);
        Display(stack, top);
    }

    // POP operation (Undo)
    static void Undo(string[] stack, ref int top)
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow! Nothing to undo.");
            return;
        }

        Console.WriteLine("Undo: " + stack[top]);
        top--;

        Display(stack, top);
    }

    // Display current state
    static void Display(string[] stack, int top)
    {
        if (top == -1)
        {
            Console.WriteLine("Current State: Empty\n");
            return;
        }

        Console.Write("Current State: ");
        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine("\n");
    }
}