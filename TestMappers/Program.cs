using System;
using Tools.Mappers;

namespace TestMappers
{
    class Program
    {
        static void Main(string[] args)
        {
            Mappers mappersService = new Mappers();

            Source source = new Source() { Id = 1, LastName = "Doe", FirstName = "John", Phones = new string[] { "50523219", "50528963", "50516927" } };

            Result result = mappersService.Map<Source, Result>(source);

            Console.WriteLine($"{result.Id} : {result.Nom} {result.Prenom}");
            foreach(string tel in result.Tels)
            {
                Console.WriteLine($"Telephone : {tel}");
            }
        }
    }
}
