using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

string filename = "datafile.txt";
string filePath = Path.Combine("C:\\Users\\lubis\\Documents\\GitHub\\AdventOfCode\\advent", filename);

string[] dataFromFile = File.ReadAllLines(filePath);

string pattern = @"mul\((\d+),(\d+)\)";
//mul\(   =>   "mul("
//( (\d+) =>   "[int]" of one or more digits
//,       =>   ","
//  (\d+) =>   "[int]" of one or more digits
// \)     =>   ")"

//so overall, it looks for "mul([int],[int])", what we want!!!
//the parentesis around (\d+) makes groups that can then be called as variables, so we can call our mult function


int total = 0;

foreach (string record in dataFromFile)
{
    MatchCollection matches = Regex.Matches(record, pattern);    //collects every match in each record

    foreach (Match match in matches)                             //iterates thru it
    {
        Console.WriteLine(match.Value);                     
        total += mult(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));     //multiplies the two values from the group
    }
}


static int mult(int a, int b)
{
    return a * b;
}


Console.WriteLine(total);