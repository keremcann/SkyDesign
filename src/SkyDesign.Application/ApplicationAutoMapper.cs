using AutoMapper;
using SkyDesign.Application.Contract.Commands.Catalog;
using SkyDesign.Application.Contract.Commands.SubCatalog;
using SkyDesign.Application.Contract.Commands.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Application.Contract.Queries.SubCatalog;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Domain.Entities;
using SkyDesign.Application.Contract.Queries.Role;
using SkyDesign.Application.Contract.Queries.Page;

namespace SkyDesign.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            CreateMap<User, GetUserQueryResponse>();
            CreateMap<Role, GetRoleQueryResponse>();
            CreateMap<Page, GetPageQueryResponse>();
            CreateMap<Catalog, GetCatalogQueryResponse>();
            CreateMap<SubCatalog, GetSubCatalogQueryResponse>();
            CreateMap<CreateSubCatalogCommandRequest, SubCatalog>();
            CreateMap<UpdateSubCatalogCommandRequest, SubCatalog>();
            CreateMap<DeleteSubCatalogCommandRequest, SubCatalog>();
            CreateMap<SubCatalogDetail, GetSubCatalogDetailQueryResponse>();
            CreateMap<CreateSubCatalogDetailCommandRequest, SubCatalogDetail>();
            CreateMap<UpdateSubCatalogDetailCommandRequest, SubCatalogDetail>();
            CreateMap<DeleteSubCatalogDetailCommandRequest, SubCatalogDetail>();

            CreateMap<Catalog, GetCatalogQueryResponse>();
            CreateMap<SubCatalogDetail, GetSubCatalogDetailBySubCatalogIdQueryResponse>();
        }
    }
}