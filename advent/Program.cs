using System.Runtime.InteropServices;
using System.Security.Cryptography;

string filename = "datafile.txt";
string filePath = Path.Combine("C:\\Users\\lubis\\Documents\\GitHub\\AdventOfCode\\advent", filename);

string[] dataFromFile = File.ReadAllLines(filePath);
//assigns each row to list
List<string> list = [.. dataFromFile];
int diff = 0;
int SafeTotal = 0;
bool safe = true;

//true = inc, false = dec.
bool incOrDec = true;


foreach(string row in list)
{

    List<int> Numbers = row.Split(' ').Select(int.Parse).ToList();
    for (int i = 0; i < Numbers.Count; i++)
    {
        if(i == 0)
        {
            diff = Numbers[i] - Numbers[i++];
            if (diff > 0)
            {
                incOrDec = false;
            }else if (diff < 0)
            {
                incOrDec = true;
            }
        }
        
        if(incOrDec && diff > 0)
        {
            safe = false;
        } else if (incOrDec == false && diff < 0)
        {
            safe = false;
        }
        if (diff > 3 || diff < -3)
        {
            safe = false;
        }
    }
    if (safe)
    {
        SafeTotal++;
    }
    safe = true;
    
}

Console.WriteLine(SafeTotal);

//foreach row in list
//foreach number in Row
//do the check thingy
