using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IDiagramRepositoryAsync : IRepositoryAsync<Diagram>
    {
        Task<CommonResponse<List<Diagram>>> GetAllByPageIdAsync(int pageId);
    }
}
