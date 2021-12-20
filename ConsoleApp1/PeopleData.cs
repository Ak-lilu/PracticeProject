using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;

namespace ConsoleApp1
{
    public class PeopleData : IPeopleData
    {
        private IMapper mapper;
        public PeopleData(IMapper _mapper)
        {
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<string[], Person>()
                .ForMember(a => a.FirstName, source => source.MapFrom(s => s[0]))
                .ForMember(a => a.LastName, source => source.MapFrom(s => s[1]))
                .ForMember(a => a.BirthDate, source => 
                        source.MapFrom(s => DateTime.ParseExact(s[2], new string[] { "dd.MM.yyyy", "d.MM.yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None)
                        ))
                ).CreateMapper();
        }

        public List<Person> Get()
        {
            return File.ReadAllLines(Path.GetFullPath("test.csv"))
                .FromCSV(entries => mapper.Map<Person>(entries)).ToList();
        }
    }
}
