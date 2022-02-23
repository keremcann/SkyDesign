using AutoMapper;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Application.Contract.Queries.SubCatalog;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Domain.Entities;

namespace SkyDesign.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            CreateMap<User, GetUserQueryResponse>();
            CreateMap<Catalog, GetCatalogQueryResponse>();
            CreateMap<SubCatalog, GetSubCatalogQueryResponse>();
            CreateMap<SubCatalogDetail, GetSubCatalogDetailQueryResponse>();
        }
    }
}
