namespace KOF.Desafios.Application.Common.Mappings
{
    using KOF.Desafios.Application.Common.Mappings.Interfaces;

    public class GenericMapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        private readonly Func<TSource, TDestination> _map;
        private readonly Func<TDestination, TSource> _mapBack;

        public GenericMapper(
            Func<TSource, TDestination> map,
            Func<TDestination, TSource> mapBack)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
            _mapBack = mapBack ?? throw new ArgumentNullException(nameof(mapBack));
        }

        public TDestination Map(TSource source) => _map(source);

        public TSource MapBack(TDestination destination) => _mapBack(destination);
    }
}