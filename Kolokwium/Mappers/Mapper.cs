namespace Kolokwium.Mappers
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn data);
    }
}