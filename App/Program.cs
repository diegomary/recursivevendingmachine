using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> coins = new List<int>();
        List<int> amounts = new List<int>() { 1, 5, 10, 20, 50,100 };        
        Change(coins, amounts, 0, 0, 7);
        Console.ReadLine();
    }

    static void Change(List<int> coins, List<int> amounts, int highest, int sum, int goal)
    {        
        if (sum == goal)
        {
            Display(coins, amounts);
            return;
        }
      
        if (sum > goal)
        {
            return;
        }
       
        foreach (int value in amounts)
        {
           
            if (value >= highest)
            {
                List<int> copy = new List<int>(coins);
                copy.Add(value);
                Change(copy, amounts, value, sum + value, goal);
            }
        }
    }

    static void Display(List<int> coins, List<int> amounts)
    {
        Console.WriteLine("Next result");

        foreach (int amount in amounts)
        {
            int count = coins.Count(value => value == amount);
            Console.WriteLine("{0}: {1}", amount, count);
        }
        Console.WriteLine();
        
    }
}

