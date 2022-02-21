using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class SubCatalogDetailRepository : EntityRepositoryBase<SubCatalogDetail>, ISubCatalogDetailRepository
    {
        public SubCatalogDetailRepository(ApplicationContext context) : base(context) { }
}
}
