namespace ProductClientHub.Communication.Responses
{
    public class ResponseShortProductJson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
