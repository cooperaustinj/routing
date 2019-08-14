namespace Requests.Fish
{
    public class Ping : IRequest<string>
    {
        public string Name { get; set; }

        public string Handle()
        {
            return $"fish pong - {Name}";
        }
    }
}