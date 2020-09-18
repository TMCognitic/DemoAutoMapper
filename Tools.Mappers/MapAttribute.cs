using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Mappers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class MapAttribute : Attribute
    {
        public string PropertyName { get; private set; }

        public MapAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
