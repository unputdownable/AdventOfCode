namespace AoC2021.Common.Navigation;

public class Command
{
    public const string Forward = "forward";
    public const string Down = "down";
    public const string Up = "up";

    private Command(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public int Value { get; set; }

    public static Command Parse(string raw)
    {
        var parts = raw.Trim().Split(" ");
        if (parts.Length != 2)
            throw new System.Exception("Command could not be parsed");

        if (!int.TryParse(parts[1], out int value))
            throw new System.Exception("Command could not be parsed");

        if (parts[0] is Forward or Down or Up)
            return new Command(parts[0], value);
        else
            throw new System.Exception("Command could not be parsed");
    }
}