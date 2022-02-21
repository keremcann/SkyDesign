using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class SubCatalogRepository : EntityRepositoryBase<SubCatalog>, ISubCatalogRepository
    {
        public SubCatalogRepository(ApplicationContext context) : base(context) { }
    }
}
