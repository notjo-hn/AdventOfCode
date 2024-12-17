string filename = "datafile.txt";
string filePath = Path.Combine("C:\\Users\\lubis\\Documents\\GitHub\\AdventOfCode\\advent", filename);

string[] dataFromFile = File.ReadAllLines(filePath);

List<int> leftValues = new List<int>();
List<int> rightValues = new List<int>();

int numTimesSeen = 0;
int totalSimilarity = 0;

foreach (string line in dataFromFile)
{
    string[] parts = line.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
    //new[] defines a new array, which holds " " or "tab", this is what split will use to divide the string, weird syntax ik
    //the second parameter ensures that no empty strings or spaces etc. are on the final result.

    int left = int.Parse(parts[0]);  
    int right = int.Parse(parts[1]);

    leftValues.Add(left);   
    rightValues.Add(right); 
    
}

for  (int i = 0; i < leftValues.Count; i++)
{
    numTimesSeen = 0;
    for (int j = 0; j < rightValues.Count; j++)
    {
        
        if (leftValues[i] == rightValues[j])
        {
            numTimesSeen++;
        }
        
    }
    totalSimilarity = totalSimilarity + (leftValues[i] * numTimesSeen);
}

Console.WriteLine(totalSimilarity);
