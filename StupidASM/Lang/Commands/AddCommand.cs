namespace StupidASM.Lang.Commands
{
    public class AddCommand : Command
    {
        private string[] _args;
        private Memory _memory;

        public AddCommand(string[] args, Memory memory)
        {
            if (args.Length != 2)
                throw new Exceptions.InvalidSyntax("Expected \"ADD <RECEIVER> <SOURCE>\"");

            _memory = memory;
            _args = args;
        }

        public override void Execute()
        {
            var resourceValue = _memory.GetResource(_args[0]);
            if(string.IsNullOrEmpty(resourceValue.ToString()))
            {
                throw new Exceptions.VariableIsEmpty(_args[0]);
            }
            var result = int.Parse(resourceValue.ToString()) + int.Parse(_args[1]);
            _memory.SetResource(_args[0], result);
        }
    }
}
