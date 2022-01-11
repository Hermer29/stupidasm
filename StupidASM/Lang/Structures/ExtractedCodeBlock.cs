using System.Text.RegularExpressions;

namespace StupidASM.Lang.Structures
{
    public class ExtractedCodeBlock
    {
        private readonly string _text;
        private ExtractedBlock? _block;
        private int _startedAtIndex;

        public ExtractedCodeBlock(string text)
        {
            _text = text;
        }

        public int StartedAtIndex => _startedAtIndex;

        public string Value()
        {
            if (_block != null)
                return _block.Value();

            var lines = _text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(".Code"))
                {
                    _block = new ExtractedBlock(_text, i);
                    var block = _block;
                    var blockString = block.Value();
                    _startedAtIndex = block.StartedAtIndex;
                    var allLetters = Regex.Matches(blockString, $"[a-zA-Z]", RegexOptions.ECMAScript);
                    var startOfFirstCommand = allLetters.First().Index;
                    var endOfLastCommand = allLetters.Last().Index;
                    return blockString.Substring(startOfFirstCommand, endOfLastCommand - startOfFirstCommand + 1);
                }
            }
            throw new Exceptions.InvalidSyntax("Code block not found");
        }
    }
}
