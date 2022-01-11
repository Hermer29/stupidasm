namespace StupidASM.Lang.Exceptions
{
    public class InvalidSyntax : LangException
    {
        private int? _line;
        private string _text;

        public InvalidSyntax(int line, string text) : base($"Invalid Syntax at line {line}: {text}")
        {
            _line = line;
            _text = text;
        }

        public InvalidSyntax(string text) : base($"Invalid Syntax: {text}")
        {
            _text = text;
        }

        public int? Line => _line;
        public string Text => _text;
    }
}
