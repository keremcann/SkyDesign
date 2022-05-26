using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IUserRepositoryAsync : IRepositoryAsync<User>
    {
        Task<CommonResponse<User>> GetUserInformationByIdAsync(int userId);
    }
}
