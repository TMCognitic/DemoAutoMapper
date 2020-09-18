using System;

namespace Tools.Mappers
{
    public struct Binder
    {
        public Type SourceType { get; private set; }
        public Type ResultType { get; private set; }

        public Binder(Type sourceType, Type resultType)
        {
            SourceType = sourceType;
            ResultType = resultType;
        }
    }
}
