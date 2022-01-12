namespace StupidASM.Lang
{
    public class CommandText
    {
        private string _line;
        private string? _command;
        private string[] _args;
        private string[] _delimitedLine;

        private CommandText(string line)
        {
            _line = line;
        }
        
        public static CommandText Parse(string line)
        {
            var pattern = @"s+";
            var filtered = Regex.Replace(line, pattern, " ");
            var deleteInStart = Regex.Replace(line, @"^s+", "");
            var text = new CommandText(line);
            text._delimitedLine = deleteInStart.Split(' ');
        }

        public string GetCommand()
        {
            if(_command != null)
                return _command;
            
            _command = _delimitedLine[0];
            return _command;
        }
        
        public string[] GetArgs()
        {
            if(_args != null)
                return _args;
            
            _args = _delimitedLine.Skip(GetCommand()).ToArray();
            return _args;
        }
    }
}