namespace StupidASM.Lang.Structures
{
    public class DataBlock
    {
        private Memory _memory;
        private string _text;
        private bool _extracted = false;

        public DataBlock(string text, Memory memory)
        {
            _memory = memory;
            _text = text;
        }

        public void ExtractData()
        {
            if(_extracted)
            {
                throw new InvalidOperationException("Data already extracted");
            }
            string? block;
            var lines = _text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(".Data"))
                {
                    block = new ExtractedBlock(_text, i).Value();
                    FillData(block);
                    return;
                }
            }
        }

        private void FillData(string block)
        {
            foreach(var line in block.Split('\n'))
            {
                string[] dataLine = line.Split(' ');
                if(dataLine.Length != 2)
                {
                    throw new Exceptions.InvalidSyntax("Expected key-value pair");
                }
                _memory.SetResource(dataLine[0], dataLine[1]);
            }
        }
    }
}
