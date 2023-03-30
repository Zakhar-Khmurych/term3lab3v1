using System;
using System.IO;
using term3lab3v1;

var websterDict = new Dictionary();
var path = "C:/Users/KHRYSTYNA/RiderProjects/term3lab3v1/term3lab3v1/dictionary.txt";
var all_data = File.ReadAllLines(path);
foreach (string line in all_data)
{ 
    websterDict.Add(line.Split(";")[0], line.Split(";")[1]);
}

Console.Write(websterDict.Get("ABBY"));
