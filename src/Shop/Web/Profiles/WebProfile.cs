using AutoMapper;
using Infrastructure.BusinessObjects;
using Web.Models;

namespace Web.Profiles
{
    public class WebProfile :Profile
    {
        public WebProfile()
        {
            CreateMap<CustomerCreateModel, Customer>()
                .ReverseMap();

        }
    }
}
