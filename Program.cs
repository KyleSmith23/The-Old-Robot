Robot robot = new Robot();
robot.IsPowered = true;
RobotCommand command1;
RobotCommand command2;

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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
     public abstract void Run(Robot robot);      
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}