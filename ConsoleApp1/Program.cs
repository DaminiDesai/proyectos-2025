using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si los paréntesis están balanceados
    static bool AreParenthesesBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in expression)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();
                if ((ch == ')' && top != '(') ||
                    (ch == '}' && top != '{') ||
                    (ch == ']' && top != '['))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    // Función para resolver las Torres de Hanói
    static void SolveTowersOfHanoi(int n, Stack<int> source, Stack<int> auxiliary, Stack<int> target)
    {
        Stack<(int, Stack<int>, Stack<int>, Stack<int>)> stack = new Stack<(int, Stack<int>, Stack<int>, Stack<int>)>();
        stack.Push((n, source, auxiliary, target));

        while (stack.Count > 0)
        {
            var (disks, src, aux, tgt) = stack.Pop();

            if (disks == 1)
            {
                tgt.Push(src.Pop());
                Console.WriteLine($"Mover disco de {GetName(src)} a {GetName(tgt)}");
            }
            else
            {
                stack.Push((disks - 1, aux, src, tgt));
                stack.Push((1, src, aux, tgt));
                stack.Push((disks - 1, src, tgt, aux));
            }
        }
    }

    static string GetName(Stack<int> stack)
    {
        if (stack == A) return "A";
        if (stack == B) return "B";
        if (stack == C) return "C";
        return "Desconocido";
    }

    static Stack<int> A = new Stack<int>();
    static Stack<int> B = new Stack<int>();
    static Stack<int> C = new Stack<int>();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Verificación de paréntesis balanceados ===");
        string operation = "(5 + 3) * {(2 + 1) * [4 - (3 + 2)]}";
        Console.WriteLine($"Operación: {operation}");
        bool balanced = AreParenthesesBalanced(operation);
        Console.WriteLine(balanced ? "Los paréntesis están balanceados." : "Los paréntesis no están balanceados.");

        Console.WriteLine("\n=== Torres de Hanói ===");
        int numDisks = 3;
        Console.WriteLine($"Resolviendo Torres de Hanói para {numDisks} discos...");
        for (int i = numDisks; i >= 1; i--)
        {
            A.Push(i);
        }
        SolveTowersOfHanoi(numDisks, A, B, C);
    }
}
