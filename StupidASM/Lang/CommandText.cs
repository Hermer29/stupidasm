using System.Text.RegularExpressions;

namespace StupidASM.Lang
{
    public class CommandText
    {
        private string? _command;
        private string[]? _args;
        private string[] _delimitedLine;

        private CommandText(string[] delimitedLine)
        {
            _delimitedLine = delimitedLine;
        }
        
        public static CommandText Parse(string line)
        {
            var pattern = @"s+";
            var filtered = Regex.Replace(line, pattern, " ");
            var deleteInStart = Regex.Replace(filtered, @"^s+", "");
            var text = new CommandText(deleteInStart.Split(' '));
            return text;
        }

        public string GetCommand()
        {
            if(_command != null)
                return _command;
            
            _command = _delimitedLine[0];
            return _command;
        }
        
        public string[] GetArguments()
        {
            if(_args != null)
                return _args;
            
            _args = _delimitedLine.Skip(1).ToArray();
            return _args;
        }
    }
}