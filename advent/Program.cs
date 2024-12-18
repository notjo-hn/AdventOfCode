using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

string filename = "datafile.txt";
string filePath = Path.Combine("C:\\Users\\lubis\\Documents\\GitHub\\AdventOfCode\\advent", filename);

string[] dataFromFile = File.ReadAllLines(filePath);
//assigns each row to list
List<string> list = [.. dataFromFile];
int SafeTotal = 0;



void CheckRow(int i)
{
    if (SingleDirectionChecker(i) && DifferenceChecker(i))
    {
        SafeTotal++;
    }
}

for (int i = 0; i < list.Count; i++)
{
    CheckRow(i);
    
}




bool SingleDirectionChecker(int x)  //make sure its all incrmementing or decremenitngnngrnhgrkh
{
    bool isSafe = true;
    bool isIncrementing = true;

    List<int> Numbers = list[x].Split(' ').Select(int.Parse).ToList();

    if (Numbers[0] > Numbers[1])
    {
        isIncrementing = false;
    }
    else if (Numbers[0] < Numbers[1])
    {
        isIncrementing = true;
    }

    for (int i = 1; i < Numbers.Count - 1; i++)
    {
        //check here and once it Fails a check then it will change the IsSafe flag to false
        if (isIncrementing)
        {
            if (Numbers[i] > Numbers[i + 1])
            {
                isSafe = false;

            }
        }
        else
        {
            if (Numbers[i] < Numbers[i + 1])
            {
                isSafe = false;

            }
        }
    }
    return isSafe;
}

bool DifferenceChecker(int x)  //check difference to make sure difference is >= 1 & <4   1=<d<4
{
    bool isSafe = true;

    List<int> Numbers = list[x].Split(' ').Select(int.Parse).ToList();
    for (int i = 0; i < Numbers.Count - 1; i++)
    {
        if (Math.Abs((Numbers[i] - Numbers[i + 1])) > 3 || Math.Abs((Numbers[i] - Numbers[i + 1])) == 0)
        {
            return false;
        }
    }
    return true;
}


Console.WriteLine(SafeTotal);






//foreach row in list
//foreach number in Row
//do the check thingy
