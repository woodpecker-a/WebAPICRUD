using AutoMapper;
using Infrastructure.BusinessObjects;
using Web.Areas.Admin.Models;

namespace Web.Profiles
{
    public class WebProfile :Profile
    {
        public WebProfile()
        {
            CreateMap<CustomerCreateModel, Customer>()
                .ReverseMap();
            CreateMap<CustomerEditModel, Customer>()
                .ReverseMap();
        }
    }
}
