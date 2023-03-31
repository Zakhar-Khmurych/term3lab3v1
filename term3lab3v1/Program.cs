using System;
using System.IO;
using term3lab3v1;

var websterDict = new Dictionary();
var path = "C:/Users/HP/RiderProjects/term3lab3v1/term3lab3v1/dictionary.txt";
var allData = File.ReadAllLines(path);
var cnt = 0;
foreach (string line in allData)
{
    var lineSeparated = line.Split(";");
    websterDict.Add(lineSeparated[0], lineSeparated[1]);
   if (cnt++ > 100) break;
}

//Console.Write(websterDict.Get("ABACINATE"));

LinkedList ll_test = new LinkedList();
KeyValuePair a = new KeyValuePair("sky", "rim");
KeyValuePair b = new KeyValuePair("rum", "death");
KeyValuePair c = new KeyValuePair("monty", "python");
KeyValuePair d = new KeyValuePair("holy", "graile");
KeyValuePair e = new KeyValuePair("chat", "gpt");

KeyValuePair to_be_inserted = new KeyValuePair("work", "pls");
ll_test.Add(a);
ll_test.Add(b);
ll_test.Add(c);
ll_test.Add(d);
ll_test.Add(e);
ll_test.AddExactlyAfterKeyPair(to_be_inserted, "sky");

ll_test.PrintAll();


//Console.WriteLine(5/2);
//Console.WriteLine(5/2);