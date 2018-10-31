using AutoMapper;
using AppliTest.Data.Entities;

namespace AppliTest.DTOs
{

    public class DTOsProfile : Profile
    {
        public DTOsProfile()
        {
            RegisterPersonne();
        }

        private void RegisterPersonne()
        {
            CreateMap<Personne, PersonneDTO>()
                .ReverseMap();
        }

    }

}
