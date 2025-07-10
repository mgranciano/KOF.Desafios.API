namespace KOF.Desafios.Application.Common.Mappings
{
    using KOF.Desafios.Application.Common.Mappings.Interfaces;

    public static class MapperHelper
    {
        public static TDestination Map<TSource, TDestination>(
            this TSource source,
            IMapper<TSource, TDestination> mapper)
        {
            return mapper.Map(source);
        }

        public static TSource MapBack<TSource, TDestination>(
            this TDestination destination,
            IMapper<TSource, TDestination> mapper)
        {
            return mapper.MapBack(destination);
        }
    }
}