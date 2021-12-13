// See https://aka.ms/new-console-template for more information
using System.IO;

Console.WriteLine("Hello, World!");

string[] input = File.ReadAllLines(@"Day1Input.txt");

int counter = 0;

//for (int i = 0; i < input.Length - 1; i++)
//{
//    if (int.Parse(input[i + 1]) > int.Parse(input[i])) counter++;    
//}

int windowA = 0;
int windowB = 0;

for (int i = 0; i < input.Length - 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        windowA += int.Parse(input[i + j]);
        windowB += int.Parse(input[(i + 1) + j]);
    }

    Console.WriteLine("{0} : {1}", windowA, windowB);

    if (windowB > windowA) counter++;

    windowA = 0;
    windowB = 0;
}

Console.WriteLine(counter);