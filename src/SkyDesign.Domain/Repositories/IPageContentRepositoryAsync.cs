using SkyDesign.Core.Base;
using SkyDesign.Domain.BaseTypes;
using SkyDesign.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageContentRepositoryAsync
    {
        Task<CommonResponse<ColumnInfo<object>>> GetPageDetail(string pageUrl);
        Task<CommonResponse<object>> AddPageDetail(CatalogContent catalogContent);
        Task<CommonResponse<object>> UpdatePageDetail(CatalogContent catalogContent);
    }
}