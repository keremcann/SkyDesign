using SkyDesign.Core.Base;
using SkyDesign.Domain.CatalogBaseTypes;
using SkyDesign.Domain.Entities;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Repositories
{
    public interface IPageContentRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        Task<CommonResponse<ColumnInfo<object>>> GetPageDetail(string pageUrl);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogContent"></param>
        /// <returns></returns>
        Task<CommonResponse<object>> CreatePageDetail(CatalogContent catalogContent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogContent"></param>
        /// <returns></returns>
        Task<CommonResponse<object>> UpdatePageDetail(CatalogContent catalogContent);
    }
}