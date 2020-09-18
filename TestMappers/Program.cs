using System;
using Tools.Mappers;

namespace TestMappers
{
    class Program
    {
        static void Main(string[] args)
        {
            MappersService mappersService = new MappersService();
            mappersService.Register<Source, Result>((s) => new Result() { Id = s.Id, Nom = s.LastName, FirstName = s.FirstName, Phones = s.Phones });


            Source source = new Source() { Id = 1, LastName = "Doe", FirstName = "John", Phones = new string[] { "50523219", "50528963", "50516927" } };

            Result result = mappersService.Map<Source, Result>(source);
        }
    }
}
