//using System.Collections;
//using System.Text;

////int[,] data = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

////string bin = "01101100";

////BitArray test = new BitArray(bin.Select(c => c == '1').ToArray());

////for (int i = 0; i < 3; i++)
////{
////    Console.WriteLine($"{data[i, 0]} {data[i, 1]} {data[i, 2]}");
////}

////data = MirrorVertically(data);
////Console.WriteLine();
////for (int i = 0; i < 3; i++)
////{
////    Console.WriteLine($"{data[i, 0]} {data[i, 1]} {data[i, 2]}");
////}
//////List<Byte[]> diagnosticReport = new();


////static T[,] RotateClockwise<T>(T[,] src)
////{
////    int width = src.GetUpperBound(0) + 1;
////    int height = src.GetUpperBound(1) + 1;
////    T[,] dst = new T[height, width];

////    for (int row = 0; row < height; row++)
////    {
////        for (int col = 0; col < width; col++)
////        {
////            int newRow = col;
////            int newCol = height - (row + 1);

////            dst[newRow, newCol] = src[row, col];
////        }
////    }

////    return dst;
////}

////static T[,] MirrorVertically<T>(T[,] src)
////{
////    int width = src.GetUpperBound(0) + 1;
////    int height = src.GetUpperBound(1) + 1;
////    T[,] dst = new T[width, height];

////    for (int row = 0; row < height; row++)
////    {
////        for (int col = 0; col < width; col++)
////        {
////            dst[row, col] = src[row, (width - 1) - col];
////            dst[row, col + (width - 1)] = src[row, col];
////        }
////    }

////    return dst;
////}

//BitArray gammaRate = new BitArray(12);
//BitArray epsilonRate = new BitArray(12);
//int sum = 0;

//List<BitArray> readings = new();
//using (StreamReader sr = new StreamReader(@"Input.txt"))
//{
//    string line = "";

//    while ((line = sr.ReadLine()) != null)
//    {
//        readings.Add(new BitArray(line.Select(c => c == '1').ToArray()));
//    }


//    for (int i = 0; i < 12; i++)
//    {
//        sum = 0;
//        for(int j = 0; j < readings.Count; j++)
//        {
//            if (((BitArray)readings[j])[i] == true)
//            {
//                sum++;
//            }
//        }
//        //double test = ((double)sum / readings.Count) * 100;
//       // Console.WriteLine(test.ToString());
//        if (((double)sum / readings.Count) * 100 > 50)
//        {
//            gammaRate[i] = true;
//        }
//    }

//    epsilonRate = (global::System.Collections.BitArray)gammaRate.Clone();
//    epsilonRate.Not();


//    int[] gamma = new int[1];
//    int[] epsilon = new int[1];

//    gammaRate.CopyTo(gamma, 0);
//    epsilonRate.CopyTo(epsilon, 0);

//    int total = gamma[0] * epsilon[0];

//    Console.WriteLine($"Gamma: {gamma[0]}  Epsilon: {epsilon[0]}  Total: {total}");


//}

string[] input = File.ReadAllLines("Input.txt");
int total;
string gammaString = "";
string epsilonString = "";

for (int i = 0; i < 12; i++)
{
    total = 0;

    for (int j = 0; j < input.Length; j++)
    {
        int.TryParse(input[j].Substring(i, 1), out int value);

        total += value;
    }

    if (((double)total / input.Length) * 100 > 50)
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
Console.WriteLine(gammaRate.ToString());
Console.WriteLine(epsilonRate.ToString());
Console.WriteLine($"Total: {gammaRate * epsilonRate}");