namespace SGA.Infra.CrossCutting.Response
{
    public class CommandResponse
    {
        private readonly bool success;

        public CommandResponse(bool value = false)
        {
            success = value;
        }

        public static CommandResponse Ok => new CommandResponse(true);
        public static CommandResponse Fail => new CommandResponse();

        public bool HasSuccess()
        {
            return success;
        }
    }
}