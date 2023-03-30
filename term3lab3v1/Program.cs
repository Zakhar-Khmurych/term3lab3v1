﻿using System;
using System.IO;
using term3lab3v1;

var websterDict = new Dictionary();
var path = "C:/Users/KHRYSTYNA/RiderProjects/term3lab3v1/term3lab3v1/dictionary.txt";
var allData = File.ReadAllLines(path);
var cnt = 0;
foreach (string line in allData)
{
    var lineSeparated = line.Split(";");
    websterDict.Add(lineSeparated[0], lineSeparated[1]);
   if (cnt++ > 1000) break;
}

Console.Write(websterDict.Get("A-"));
