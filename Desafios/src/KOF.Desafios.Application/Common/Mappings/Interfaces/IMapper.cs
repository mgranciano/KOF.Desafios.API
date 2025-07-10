namespace KOF.Desafios.Application.Common.Mappings.Interfaces
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TSource MapBack(TDestination destination);
    }
}