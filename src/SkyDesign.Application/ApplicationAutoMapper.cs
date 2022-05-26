using AutoMapper;
using SkyDesign.Application.Contract.Commands.SubCatalog;
using SkyDesign.Application.Contract.Commands.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Application.Contract.Queries.SubCatalog;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Domain.Entities;
using SkyDesign.Application.Contract.Queries.Role;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Application.Contract.Queries.Diagram;
using SkyDesign.Application.Contract.Commands.Page;
using SkyDesign.Domain.CatalogBaseTypes;
using SkyDesign.Application.Contract.Commands.Role;
using SkyDesign.Application.Contract.Commands.User;

namespace SkyDesign.Application
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            #region User
            CreateMap<User, GetUserQueryResponse>().ReverseMap();
            CreateMap<CreateUserCommandRequest, User>().ReverseMap();
            CreateMap<UpdateUserCommandRequest, User>().ReverseMap();
            CreateMap<DeleteUserCommandRequest, User>().ReverseMap();
            CreateMap<GetUserInformationByIdQueryResponse, User>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, GetRoleQueryResponse>().ReverseMap();
            CreateMap<Role, CreateRoleCommandRequest>().ReverseMap();
            CreateMap<Role, UpdateRoleCommandRequest>().ReverseMap();
            CreateMap<Role, DeleteRoleCommandRequest>().ReverseMap();
            CreateMap<Role, UpdateUserCommandRequest_UserRoleDto>().ReverseMap();
            CreateMap<Role, CreateUserCommandRequest_UserRoleDto>().ReverseMap();
            CreateMap<Role, GetUserInformationByIdQueryResponse_Role>().ReverseMap();
            #endregion

            #region Page
            CreateMap<Page, GetPageQueryResponse>().ReverseMap();
            CreateMap<CreatePageDetailCommandRequest, CatalogContent>().ReverseMap();
            CreateMap<UpdatePageDetailCommandRequest, CatalogContent>().ReverseMap();
            CreateMap<CreatePageCommandRequest, Page>().ReverseMap();
            CreateMap<ColumnList, GetColumnListResponse>().ReverseMap();
            CreateMap<ColumnDefinition, GetAllColumnListByPageIdResponse>().ReverseMap();
            #endregion

            #region Catalog
            CreateMap<Catalog, GetCatalogQueryResponse>().ReverseMap();
            #endregion

            #region SubCatalog
            CreateMap<SubCatalog, GetSubCatalogQueryResponse>().ReverseMap();
            CreateMap<SubCatalog, CreateSubCatalogCommandRequest>();
            CreateMap<SubCatalog, UpdateSubCatalogCommandRequest>();
            CreateMap<SubCatalog, DeleteSubCatalogCommandRequest>();
            #endregion

            #region SubCatalogDetail
            CreateMap<SubCatalogDetail, GetSubCatalogDetailQueryResponse>().ReverseMap();
            CreateMap<SubCatalogDetail, CreateSubCatalogDetailCommandRequest>().ReverseMap();
            CreateMap<SubCatalogDetail, UpdateSubCatalogDetailCommandRequest>().ReverseMap();
            CreateMap<SubCatalogDetail, DeleteSubCatalogDetailCommandRequest>().ReverseMap();
            CreateMap<SubCatalogDetail, GetSubCatalogDetailBySubCatalogIdQueryResponse>().ReverseMap();
            #endregion

            #region Diagram
            CreateMap<Diagram, GetDiagramQueryResponse>().ReverseMap();
            #endregion
        }
    }
}