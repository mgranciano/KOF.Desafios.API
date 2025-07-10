using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KOF.Desafios.Application.Common.Mappings.Interfaces;

namespace KOF.Desafios.Application.Common.Mappings
{
    public class ExpressionTreeMapper<TSource, TDestination> : IMapper<TSource, TDestination>
        where TSource : class, new()
        where TDestination : class, new()
    {
        private static readonly Func<TSource, TDestination> _mapFunc = CreateMapFunc();
        private static readonly Func<TDestination, TSource> _mapBackFunc = CreateMapBackFunc();

        public TDestination Map(TSource source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return _mapFunc(source);
        }

        public TSource MapBack(TDestination destination)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            return _mapBackFunc(destination);
        }

        private static Func<TSource, TDestination> CreateMapFunc()
        {
            var sourceParameter = Expression.Parameter(typeof(TSource), "source");
            var bindings = new List<MemberBinding>();

            foreach (var destProp in typeof(TDestination).GetProperties().Where(p => p.CanWrite))
            {
                var sourceProp = typeof(TSource).GetProperty(destProp.Name);
                if (sourceProp == null || !sourceProp.CanRead || destProp.PropertyType != sourceProp.PropertyType)
                    continue;

                var sourceAccess = Expression.Property(sourceParameter, sourceProp);
                var binding = Expression.Bind(destProp, sourceAccess);
                bindings.Add(binding);
            }

            var body = Expression.MemberInit(Expression.New(typeof(TDestination)), bindings);
            return Expression.Lambda<Func<TSource, TDestination>>(body, sourceParameter).Compile();
        }

        private static Func<TDestination, TSource> CreateMapBackFunc()
        {
            var destParameter = Expression.Parameter(typeof(TDestination), "destination");
            var bindings = new List<MemberBinding>();

            foreach (var sourceProp in typeof(TSource).GetProperties().Where(p => p.CanWrite))
            {
                var destProp = typeof(TDestination).GetProperty(sourceProp.Name);
                if (destProp == null || !destProp.CanRead || sourceProp.PropertyType != destProp.PropertyType)
                    continue;

                var destAccess = Expression.Property(destParameter, destProp);
                var binding = Expression.Bind(sourceProp, destAccess);
                bindings.Add(binding);
            }

            var body = Expression.MemberInit(Expression.New(typeof(TSource)), bindings);
            return Expression.Lambda<Func<TDestination, TSource>>(body, destParameter).Compile();
        }
    }
}