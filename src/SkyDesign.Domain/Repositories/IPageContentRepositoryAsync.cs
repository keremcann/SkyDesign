using SkyDesign.Core.Base;
using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageContentRepositoryAsync
    {
        Task<CommonResponse<ColumnInfo<object>>> GetPageDetail(string pageUrl);
    }
}