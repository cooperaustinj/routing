public interface IRequest<out T>
{
    T Handle();
}