using AutoMapper;
using BO = Infrastructure.BusinessObjects;
using EO = Infrastructure.Entities;

namespace Infrastructure.Profiles
{
    public class ISProfile : Profile
    {
        public ISProfile()
        {
            CreateMap<BO.Customer, EO.Customer>()
                .ReverseMap();
        }
    }
}
