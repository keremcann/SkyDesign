using SkyDesign.Core.Base;
using SkyDesign.Domain.Common;
using SkyDesign.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface ISubCatalogDetailRepositoryAsync : IRepositoryAsync<SubCatalogDetail>
    {
        public Task<CommonResponse<List<SubCatalogDetail>>> GetAllBySubCatalogIdAsync(int subCatalogId);
    }
}
