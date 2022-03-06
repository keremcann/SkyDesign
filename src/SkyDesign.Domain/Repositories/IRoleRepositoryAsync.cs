using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IRoleRepositoryAsync : IRepositoryAsync<Role>
    {
        Task<CommonResponse<Role>> AddUserRoleAsync(Role request);
    }
}
