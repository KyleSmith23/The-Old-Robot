Robot robot = new Robot();
robot.IsPowered = true;
IRobotCommand command1;
IRobotCommand command2;

Console.WriteLine("Move North or South");
string yAxis = Console.ReadLine().ToLower();

if (yAxis == "north")
{
    command1 = new NorthCommand();
} else
{
    command1 = new SouthCommand();
}

Console.WriteLine("Move East or West");
string xAxis = Console.ReadLine().ToLower();

if (xAxis == "East")
{
    command2 = new EastCommand();
}
else
{
    command2 = new WestCommand();
}

robot.Commands[0] = command1;
robot.Commands[1] = command2;
robot.Run();



// Classes
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
     public abstract void Run(Robot robot);      
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}