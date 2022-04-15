using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageContentRepositoryAsync
    {
        Task<ColumnInfo<object>> GetPageDetail(string pageUrl);
    }
}