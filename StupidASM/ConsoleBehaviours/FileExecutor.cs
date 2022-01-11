using StupidASM.Lang;
using StupidASM.Lang.Structures;

public class FileExecutor
{
    private string _path;

    public FileExecutor(string path)
    {
        _path = path;
    }

    public void Execute()
    {
        var memory = new Memory();
        var parser = new CommandParser(memory);

        var path = Environment.CurrentDirectory + "\\" + _path;
        string? code;

        try
        {
            code = File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Specified file not found");
            return;
        }

        var data = new DataBlock(code, memory);
        data.ExtractData();
        var codeBlock = new ExtractedCodeBlock(code);
        var lines = codeBlock.Value().Split('\n');


        for (int i = 0; i < lines.Length; i++)
        {
            var command = parser.Parse(lines[i], codeBlock.StartedAtIndex + i + 1);
            command.Execute();
        }
    }
}
