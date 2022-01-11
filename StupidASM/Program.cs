using StupidASM.Lang.Exceptions;

public class Program
{
    static void Main(string[] args)
    {
        switch (args.Length)
        {
            case 0:
                var idleBehaviour = new IdleBehaviour();
                idleBehaviour.Start();
                return;
            case 1:
                ExecuteFile(args);
                return;
            default:
                Console.WriteLine("Unexpected args count");
                return;
        }
    }

    static void ExecuteFile(string[] args)
    {
        try
        { 
            var fileExecutor = new FileExecutor(args[0]);
            fileExecutor.Execute();
        }
        catch (LangException e)
        {
            Console.WriteLine($"Language error occured: {e.Message}");
        }
    }
}