using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Tools.Mappers
{
    public abstract partial class MappersService : IMappersService
    {
        private Dictionary<Binder, Func<object, object>> _mappers;

        public MappersService()
        {
            _mappers = new Dictionary<Binder, Func<object, object>>();
            ConfigureMappers(this);
        }

        protected abstract void ConfigureMappers(IMappersService service);

        private static TResult DefaultMapper<TSource, TResult>(TSource source)
            where TSource : class
        {
            Type sourceType = source.GetType();
            Type resultType = typeof(TResult);

            if (resultType.IsInterface)
                throw new InvalidOperationException("TResult must be a class");

            IEnumerable<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToArray();
            TResult result = (TResult)Activator.CreateInstance(resultType);

            foreach (PropertyInfo propertyInfo in resultType.GetProperties())
            {
                string propertyName = propertyInfo.Name;

                MapAttribute mapAttribute = propertyInfo.GetCustomAttribute<MapAttribute>();
                if (!(mapAttribute is null))
                    propertyName = mapAttribute.PropertyName;

                PropertyInfo sourceProperty = sourceProperties.Where(p => p.Name == propertyName).SingleOrDefault();
                if (!(sourceProperty is null))
                {
                    propertyInfo.SetMethod.Invoke(result, new object[] { sourceProperty.GetMethod.Invoke(source, null) });
                }
            }

            return result;
        }

        public TResult Map<TSource, TResult>(TSource source)
            where TSource : class
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            Binder binder = new Binder(source.GetType(), typeof(TResult));

            if (_mappers.ContainsKey(binder))
            {
                return (TResult)_mappers[binder].Invoke(source);
            }
            else
            {
                return DefaultMapper<TSource, TResult>(source);
            }
        }

        void IMappersService.Register<TSource, TResult>(Func<TSource, TResult> mapper)
        {
            if (mapper is null)
                throw new ArgumentNullException();

            _mappers.Add(new Binder(typeof(TSource), typeof(TResult)), (source) => mapper((TSource)source));
        }
    }
}
