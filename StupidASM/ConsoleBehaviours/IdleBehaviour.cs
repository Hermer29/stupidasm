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

            var command = parser.Parse(input);
            command.Execute();
        }
    }
}
