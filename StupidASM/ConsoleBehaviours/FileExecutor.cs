using StupidASM.Lang;
using StupidASM.Lang.Structures;

public class FileExecutor
{
    private string _path;
    private Memory _memory;
    private CommandParser _parser;

    public FileExecutor(string path)
    {
        _path = path;
        _memory = new Memory();
        _parser = new CommandParser(_memory);
    }

    public void Execute()
    {
        string code = ExtractFile();
        if(string.IsNullOrEmpty(code))
        {
            Console.WriteLine($"Specified file not found");
            return;
        }
        ParseDataBlock(code);
        

        
        var codeBlock = new ExtractedCodeBlock(code);
        var lines = codeBlock.Value().Split('\n');


        for (int i = 0; i < lines.Length; i++)
        {
            var command = _parser.Parse(lines[i], codeBlock.StartedAtIndex + i + 1);
            command.Execute();
        }
    }

    private string ExtractFile()
    {
        var path = Environment.CurrentDirectory + "\\" + _path;
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            return string.Empty;
        }
    }

    private void ParseDataBlock(string code)
    {
        var data = new DataBlock(code, _memory);
        data.ExtractData();
    }
}