using System;
using System.Collections.Generic;
using System.Text;
using Tools.Mappers;

namespace TestMappers
{
    public class Mappers : MappersService
    {
        protected override void ConfigureMappers(IMappersService service)
        {
            service.Register<Source, Result>((s) => new Result() { Id = s.Id, Nom = s.LastName, Prenom = s.FirstName, Tels = s.Phones });
        }
    }
}
