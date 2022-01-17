using StupidASM.Lang;

public class IdleBehaviour
{
    public void Start()
    {
        var memory = new Memory();
        var parser = new CommandParser(memory);

        while(true)
        {
            Console.Write(">>> ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                continue;
            }
            var command = parser.Parse(input);
            command.Execute();
        }
    }

    private void WriteDebug(CommandText commandText)
    {
        Console.WriteLine("Args: ");
        foreach(var arg in commandText.GetArguments())
        {
            Console.WriteLine(arg);
        }
        Console.WriteLine($"\nCommand: {commandText.GetCommand()}");
    }
}
