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

        public Command Parse(string line, int? number = null)
        {
            var commandText = CommandText.Parse(line);
            var command = commandText.GetCommand();
            
            if (command.ToLower() == "add")
            {
                return new AddCommand(commandText.GetArguments(), _memory);
            }
            else if (command.ToLower() == "mov")
            {
                return new MovCommand(commandText.GetArguments(), _memory);
            }
            else if (command.ToLower() == "prt")
            {
                return new PrtCommand(commandText.GetArguments(), _memory);
            }
            else if(Regex.IsMatch(line, @"^\s{0,}[{}]\s{0,}$"))
            {
                return new EmptyCommand();
            }
            
            ThrowInvalidSyntax(number);
        }
        
        public void ThrowInvalidSyntax(int? atLine)
        {
            if(atLine != null)
            {
                throw new Exceptions.InvalidSyntax(atLine.Value, "Command not found");
            }
            throw new Exceptions.InvalidSyntax("Command not found");
        }
    }
}