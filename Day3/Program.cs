string[] input = File.ReadAllLines("Input.txt");
int total;
string gammaString = "";
string epsilonString = "";

for (int i = 0; i < input[0].Length; i++)
{
    total = 0;

    for (int j = 0; j < input.Length; j++)
    {
        int.TryParse(input[j].Substring(i, 1), out int value);

        total += value;
    }

    if (((double)total / input.Length) * 100 >= 50)
    {
        gammaString += "1";
        epsilonString += "0";
    }
    else
    {
        gammaString += "0";
        epsilonString += "1";
    }

}

int gammaRate = Convert.ToInt32(gammaString, 2);
int epsilonRate = Convert.ToInt32(epsilonString, 2);
Console.WriteLine($"{gammaString} Gamma Rate: {gammaRate}");
Console.WriteLine($"{epsilonString} Epsilon Rate: {epsilonRate}");
Console.WriteLine($"Total: {gammaRate * epsilonRate}");

string[] filteredGamma = input;
string[] filteredEpsilon = input;

 for (int i = 0; i < gammaString.Length; i++)
{
    if (filteredGamma.Length > 1)
    {
        if (filteredGamma.Where(x => x.Substring(i, 1) == "1").Count() == filteredGamma.Where(x => x.Substring(i, 1) == "0").Count())
        {
            filteredGamma = filteredGamma.Where(x => x.Substring(i, 1) == "1").ToArray();
        }
        else
        {
            filteredGamma = filteredGamma.Where(x => x.Substring(i, 1) == gammaString.Substring(i, 1)).ToArray();
        }
    }

    if (filteredEpsilon.Length > 1) { 

        if (filteredEpsilon.Where(x => x.Substring(i, 1) == "1").Count() == filteredEpsilon.Where(x => x.Substring(i, 1) == "0").Count())
        {
            filteredEpsilon = filteredEpsilon.Where(x => x.Substring(i, 1) == "0").ToArray();
        }
        else
        {
            filteredEpsilon = filteredEpsilon.Where(x => x.Substring(i, 1) == epsilonString.Substring(i, 1)).ToArray();
        }
    }
}


int oxygenRating = Convert.ToInt32(filteredGamma[0], 2);
int scrubberRating = Convert.ToInt32(filteredEpsilon[0], 2);

Console.WriteLine();
Console.WriteLine($"{filteredGamma[0]} Oxygen Rating: {oxygenRating}");
Console.WriteLine($"{filteredEpsilon[0]} Scrubber Rating: {scrubberRating}");
Console.WriteLine($"Total: {oxygenRating * scrubberRating}");