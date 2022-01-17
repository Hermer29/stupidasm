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

            var command = GetCommand(commandText);

            if(!(command is EmptyCommand))
            {
                return command;
            }
            ThrowInvalidSyntax(number);
            return new EmptyCommand();
        }

        private Command GetCommand(CommandText text)
        {
            switch(text.GetCommand())
            {
                case "prt":
                    return new PrtCommand(text.GetArguments(), _memory);
                case "mov":
                    return new MovCommand(text.GetArguments(), _memory);
                case "add":
                    return new AddCommand(text.GetArguments(), _memory);
                default:
                    return new EmptyCommand();
            }
        }

        
        private void ThrowInvalidSyntax(int? atLine)
        {
            if(atLine != null)
            {
                throw new Exceptions.InvalidSyntax(atLine.Value, "Command not found");
            }
            throw new Exceptions.InvalidSyntax("Command not found");
        }
    }
}