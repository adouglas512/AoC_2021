List<Command> Commands = new List<Command>();
int horizontalPosition = 0;
int verticalPosition = 0;
int aim = 0;
int finalPosition = 0;

using (StreamReader sr = new StreamReader(@"Day2Input.txt"))
{
    string line = "";

    while ((line = sr.ReadLine()) != null)
    {
        string[] parts = line.Split(new char[] { ' ' });
        Commands.Add(new Command() { Direction = parts[0], Distance = int.Parse(parts[1]) });
    }

    foreach (Command command in Commands)
    {
        switch (command.Direction)
        {
            case "forward":
                horizontalPosition += command.Distance;
                verticalPosition += command.Distance * aim;
                break;
            case "down":
                aim += command.Distance;
                break;
            case "up":
                aim -= command.Distance;
                break;
        }
    }

    finalPosition = horizontalPosition * verticalPosition;
    Console.WriteLine($"Horizontal: {horizontalPosition}  Vertitcal: {verticalPosition}  Final: {finalPosition}");
}

public class Command
{
    public string Direction { get; set; } = "";
    public int Distance { get; set; } = 0;
}
