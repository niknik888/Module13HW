using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\Administrator\\Downloads\\text.txt";

        string[] lines = File.ReadAllLines(filePath);

        List<string> list = new List<string>();
        LinkedList<string> linkedList = new LinkedList<string>();

        // Измеряем время для вставки текста в List
        Stopwatch listStopwatch = Stopwatch.StartNew();
        list.AddRange(lines);
        listStopwatch.Stop();
        Console.WriteLine($"Время вставки в List: {listStopwatch.ElapsedMilliseconds} ms");

        // Измеряем время для вставки текста в LinkedList
        Stopwatch linkedListStopwatch = Stopwatch.StartNew();
        foreach (string line in lines)
        {
            linkedList.AddLast(line);
        }
        linkedListStopwatch.Stop();
        Console.WriteLine($"Время вставки в LinkedList: {linkedListStopwatch.ElapsedMilliseconds} ms");
    }
}