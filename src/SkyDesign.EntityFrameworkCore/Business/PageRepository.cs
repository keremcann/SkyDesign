using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class PageRepository : EntityRepositoryBase<Page>, IPageRepository
    {
        public PageRepository(ApplicationContext context) : base(context) { }
    }
}
