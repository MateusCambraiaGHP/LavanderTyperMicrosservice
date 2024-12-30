namespace LavanderTyperWeb.Core.Messages.CommonMessages
{
    public class BaseHandlerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ValidationErrors { get; set; } = new List<string>();

        public BaseHandlerResponse() => Success = true;

        public BaseHandlerResponse(string message = "")
        {
            Success = true;
            Message = message;
        }

        public BaseHandlerResponse(bool success, string message = "")
        {
            Success = success;
            Message = message;
            ValidationErrors = new List<string>();
        }
    }
}
