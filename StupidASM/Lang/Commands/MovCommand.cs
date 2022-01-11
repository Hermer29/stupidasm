using StupidASM.Lang;

namespace StupidASM.Lang.Commands
{
    public class MovCommand : Command
    {
        private Memory _memory;
        private string[] _args;

        public MovCommand(string[] args, Memory memory)
        {
            _memory = memory;
            _args = args;
        }

        public override void Execute()
        {
            if (int.TryParse(_args[1], out _) == false)
            {
                var valueToSet = _memory.GetResource(_args[1]);
                _memory.SetResource(_args[0], valueToSet);
                return;
            }
            var value = _args[1];
            _memory.SetResource(_args[0], value);
        }
    }
}