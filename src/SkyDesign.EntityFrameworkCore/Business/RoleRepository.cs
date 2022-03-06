using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class RoleRepository : EntityRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context) { }
    }
}
