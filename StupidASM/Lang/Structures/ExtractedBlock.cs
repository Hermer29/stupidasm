namespace StupidASM.Lang.Structures
{
    public class ExtractedBlock
    {
        private int _from;
        private string _text;
        private string? _cache;
        private int _startedAtLine;

        public ExtractedBlock(string text, int from)
        {
            _from = from;
            _text = text;
        }

        public int StartedAtIndex => _startedAtLine;

        public string Value()
        {
            if(_cache != null)
            {
                return _cache;
            }
            var start = _text.IndexOf('{', _from);
            if (start == -1)
            {
                throw new Exceptions.InvalidSyntax(_from + 1, "Expected start of block");
            }
            _startedAtLine = _text.Substring(0, start).Count((x) => x == '\n') - 1;
            var end = _text.IndexOf('}', _from);
            if (end == -1)
            {
                throw new Exceptions.InvalidSyntax(_text.Split('\n').Length, "Expected end of block");
            }
            _cache = _text.Substring(start, end - start + 1);
            if (string.IsNullOrEmpty(_cache))
            {
                throw new Exceptions.InvalidSyntax("Expected code block");
            }
            return _cache;
        }
    }
}
