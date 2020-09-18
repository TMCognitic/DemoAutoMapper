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
        [Map("FirstName")]
        public string Prenom { get; set; }
        [Map("Phones")]
        public IEnumerable<string> Tels { get; set; }
    }
}
