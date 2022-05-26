using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class CatalogRepository : EntityRepositoryBase<Catalog>, ICatalogRepository
    {
        public CatalogRepository(ApplicationContext context) : base(context) { }
    }
}
