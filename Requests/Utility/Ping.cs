namespace Requests.Utility
{
    public class Ping : IRequest<string>
    {
        public string Name { get; set; }

        public string Handle()
        {
            return $"pong - {Name}";
        }
    }
}