using StupidASM.Lang;

namespace StupidASM.Lang.Commands
{
    public class PrtCommand : Command
    {
        private Memory _memory;
        private string[] _args;

        public PrtCommand(string[] args, Memory memory)
        {
            _memory = memory;
            _args = args;
        }

        public override void Execute()
        {
            if (int.TryParse(_args[0], out _) == false)
            {
                var result = _memory.GetResource(_args[0]);
                Console.WriteLine(result.ToString());
                return;
            }
            Console.WriteLine(_args[0]);
        }
    }
}