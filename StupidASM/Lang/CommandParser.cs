using StupidASM.Lang.Commands;
using System.Text.RegularExpressions;

namespace StupidASM.Lang
{
    public class CommandParser
    {
        private Memory _memory;

        public CommandParser(Memory memory)
        {
            _memory = memory;
        }

        private string[] GetArgs(string line, int commandStart)
        {
            return line.Remove(0, commandStart + 4)
                .Split(' ')
                .Where(x => (string.IsNullOrEmpty(x) || x == " ") == false)
                .ToArray();
        }

        public Command Parse(string line, int? number = null)
        {
            var commandStart = Regex.Match(line, $"\\w").Index;
            Console.WriteLine(GetArgs(line, commandStart));
            var command = line.Substring(commandStart, 3);
            if (command.ToLower() == "add")
            {
                var args = GetArgs(line, commandStart);
                return new AddCommand(args, _memory);
            }
            if (command.ToLower() == "mov")
            {
                var args = GetArgs(line, commandStart);
                return new MovCommand(args, _memory);
            }
            if (command.ToLower() == "prt")
            {
                var args = GetArgs(line, commandStart);
                return new PrtCommand(args, _memory);
            }
            if(Regex.IsMatch(line, "^\\s{0,}[{}]\\s{0,}$"))
            {
                return new EmptyCommand();
            }
            if(number != null)
            {
                throw new Exceptions.InvalidSyntax(number.Value, "Command not found");
            }
            throw new Exceptions.InvalidSyntax("Command not found");
        }
    }
}