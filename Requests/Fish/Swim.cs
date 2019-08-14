namespace Requests.Fish
{
    public class Swim : IRequest<string>
    {
        public string BodyOfWater { get; set; }

        public string Handle()
        {
            return $"swimming in the {BodyOfWater}";
        }
    }
}