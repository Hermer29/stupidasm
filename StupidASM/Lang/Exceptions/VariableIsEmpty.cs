namespace StupidASM.Lang.Exceptions
{
    public class VariableIsEmpty : LangException
    {
        public VariableIsEmpty(string name) : base($"Variable \"{name}\" is empty")
        {

        }
    }
}
