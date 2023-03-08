using System;
using System.Collections.Generic;
 

public class Program
{
    public static List<int> ReplaceValues(List<int> listToReplace, int itemToReplace, int itemToReplaceWith)
    {
        for (int i = 0; i < listToReplace.Count; i++)
        {
            if (listToReplace[i] == itemToReplace)
            {
                listToReplace[i] = itemToReplaceWith;
            }
        }
        return listToReplace;
    }

    public static Tuple<int, bool> Menu()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Menu\n1.Random list\n2.Enter list\n3.Exit\n ");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Choose 1 or 2");
                }
                else if (choice == 1 || choice == 2)
                {
                    return new Tuple<int, bool>(choice, true);
                }
                else if (choice == 3)
                {
                    return new Tuple<int, bool>(choice, true);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not an int type!");
            }
        }
    }

    public static Tuple<List<int>, int> InputL(int choice)
    {
        while (true)
        {
            try
            {
                List<int> list = new List<int>();
                if (choice == 1)
                {
                    Console.Write("Enter n: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("n must be greater");
                        continue;
                    }

                    Console.WriteLine("Generating list...");
                    for (int i = 0; i < n; i++)
                    {
                        int temp = new Random().Next(0, 9);
                        list.Add(temp);
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter n: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("n must be greater");
                        continue;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"{i + 1} - element: ");
                        int elem = int.Parse(Console.ReadLine());
                        list.Add(elem);
                    }
                }
                Console.WriteLine(string.Join(", ", list));
                Console.WriteLine("------------------------------");
                list = ReplaceValues(list, 0, -1);
                return new Tuple<List<int>, int>(list, list.Count);
            }
            catch (FormatException)
            {
                Console.WriteLine("This is not an int type!");
            }
        }
    }

    public static List<int> ResultAfterTransformation(List<int> list, int n)
    {
        List<int> dontTouch = new List<int>();
        int i = 0;
        while (i < n)
        {
            int j = 0;
            int temp = 0;
            while (j < n)
            {
                if (list[i] == list[j])
                {
                    temp++;
                }
                j++;
            }
            if (temp < 2)
            {
                list[i] = 0;
                dontTouch.Add(i);
            }
            i++;
        }
        Console.WriteLine("");
        Console.WriteLine("1. Removing solo numbers...");
        List<int> listCl = ReplaceValues(list, -1, 0);
        Console.WriteLine(string.Join(", ", listCl));
        i = 0;
        while (i < n)
        {
            int j = 0;
            List<int> group = new List<int>();
            while (j < n)
            {
                if (list[i] == list[j])
                {
                    if (!dontTouch.Contains(j))
                    {
                        group.Add(j);
                        dontTouch.Add(j);
                    }
                }
                j++;
            }
            i++;
            if (group.Count != 0)
            {
                list[group[0]] = 1;
                list[group[group.Count - 1]] = 1;
                int c = 1;
                while (c < group.Count - 1)
                {
                    list[group[c]] = 0;
                    c++;
                }
            }
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine(" ");
        Console.WriteLine("2. First & last repeatable number changes to 1, all same numbers between them changes to 0...");

        Console.WriteLine(string.Join(", ", list));

        Console.WriteLine("------------------------------");
        return list;
    }

    public static void Main()
    {
        while (true)
        {
            Tuple<int, bool> choice = Menu();
            if (!choice.Item2)
            {
                break;
            }
            Tuple<List<int>, int> input = InputL(choice.Item1);
            ResultAfterTransformation(input.Item1, input.Item2);
            Console.WriteLine("");
            Console.WriteLine("3. Counting 0 and 1...");
            Console.WriteLine("Number '1' appears - " + input.Item1.Count(x => x == 1) + "  times.");
            Console.WriteLine("Number '0' appears - " + input.Item1.Count(x => x == 0) + "  times.");
            Console.WriteLine("------------------------------");
            Console.WriteLine("  ");
        }
    }
}
