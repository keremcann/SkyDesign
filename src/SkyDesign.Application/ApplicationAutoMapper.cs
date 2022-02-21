using AutoMapper;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Domain.Entities;

namespace SkyDesign.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            CreateMap<Catalog, GetCatalogQueryResponse>(); 
            CreateMap<User, GetUserQueryResponse>();
        }
    }
}
