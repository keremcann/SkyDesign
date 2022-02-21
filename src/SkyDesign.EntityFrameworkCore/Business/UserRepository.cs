using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Context;
using SkyDesign.EntityFrameworkCore.RepositoryBase;

namespace SkyDesign.EntityFrameworkCore.Business
{
    public class UserRepository : EntityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }
    }
}
