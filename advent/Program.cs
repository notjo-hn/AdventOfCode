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

List<int> unsafeIndexes = new List<int>();



for (int i = 0; i < list.Count; i++)
{
    CheckRow(i);
    
}

foreach (int i in unsafeIndexes.ToList())
{
    CheckRow(i);
}


void CheckRow(int i)
{
    if (SingleDirectionChecker(i, false) && DifferenceChecker(i, false))
    {
        SafeTotal++;
    }
    else
    {
        unsafeIndexes.Add(i);
    }
}



bool SingleDirectionChecker(int x, bool Unsafe)  //make sure its all incrmementing or decremenitngnngrnhgrkh
{
    bool isSafe = true;
    bool isIncrementing = true;
    bool Possible = false;

    List<int> Numbers = list[x].Split(' ').Select(int.Parse).ToList();

    if (Unsafe == false)
    {
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
    else
    {
        for (int ignore = 0; ignore < Numbers.Count; ignore++)
        {
            for (int i = 0; i < Numbers.Count - 1; i++)
            {
                if (i != ignore)
                {
                    if (Numbers[0] > Numbers[1])
                    {
                        isIncrementing = false;
                    }
                    else if (Numbers[0] < Numbers[1])
                    {
                        isIncrementing = true;
                    }

                    for (int I = 1; I < Numbers.Count - 1; I++)
                    {
                        //check here and once it Fails a check then it will change the IsSafe flag to false
                        if (isIncrementing)
                        {
                            if (Numbers[I] > Numbers[I + 1])
                            {
                                isSafe = false;

                            }
                        }
                        else
                        {
                            if (Numbers[I] < Numbers[I + 1])
                            {
                                isSafe = false;

                            }
                        }
                    }
                    return isSafe;
                }

            }

        }
        if (Possible)
        {
            Console.WriteLine("if you remove something from " + Numbers.ToString() + " Then it works");
            return true;

        }
    }
    

    
}

bool DifferenceChecker(int x, bool Unsafe)  //check difference to make sure difference is >= 1 & <4   1=<d<4
{
    bool isSafe = true;
    int indexToIgnore = 0;
    bool Possible = false;

    List<int> Numbers = list[x].Split(' ').Select(int.Parse).ToList();

    if (Unsafe == false)
    {
        for (int i = 0; i < Numbers.Count - 1; i++)
        {
            if (Math.Abs((Numbers[i] - Numbers[i + 1])) > 3 || Math.Abs((Numbers[i] - Numbers[i + 1])) == 0)
            {
                return false;
            }
        }
        return true;
    }
    else      //checking if maybe you can make an unsafe list safe
    {
        //have an ignore index, starts at 0 and ends at the end of the list
        //have a for loop that counts as the ignore index, [it goes thru all the diff. kinds of list depending on what index is skipped
        //have a for loop in that that actually iterates through the list
        //if in ANY scenario it suddenly passes fully, then break and increment saftetotal
        
        for(int ignore = 0; ignore < Numbers.Count; ignore++)
        {
            for (int i = 0; i < Numbers.Count-1; i++)
            {
                if (i != ignore)
                {
                    if (Math.Abs((Numbers[i] - Numbers[i + 1])) > 3 || Math.Abs((Numbers[i] - Numbers[i + 1])) == 0)    //this flags for if its a fail
                    {
                        Possible = false;
                        break;
                    }
                    Possible = true;
                }
                
            }
            
        }
        if (Possible)
        {
            Console.WriteLine("if you remove something from " + Numbers.ToString() + " Then it works");
            return true;
            
        }

        
    }
    return false;
    
}


Console.WriteLine(SafeTotal);






//foreach row in list
//foreach number in Row
//do the check thingy
