using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tools.Mappers;

namespace TestMappers
{
    class Result
    {
        public int Id { get; set; }
        [Map("LastName")]
        public string Nom { get; set; }
        public string FirstName { get; set; }

        public IEnumerable<string> Phones { get; set; }
    }
}
