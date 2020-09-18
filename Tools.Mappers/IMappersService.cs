using System;

namespace Tools.Mappers
{
    public interface IMappersService
    {
        void Register<TSource, TResult>(Func<TSource, TResult> mapper)
            where TSource : class
            where TResult : class;
    }
}