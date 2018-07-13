namespace SGA.Infra.CrossCutting.Response
{
    public class CommandResponse
    {
        public static CommandResponse Ok => new CommandResponse(true);
        public static CommandResponse Fail => new CommandResponse();

        public CommandResponse(bool value = false)
        {
            success = value;
        }

        private readonly bool success;

        public bool HasSuccess()
        {
            return success;
        }

    }
}