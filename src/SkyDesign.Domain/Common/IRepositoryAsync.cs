using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Common
{
    public interface IRepositoryAsync<T>
    {
        #region Async Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<CommonResponse<List<T>>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonResponse<List<T>>> GetAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonResponse<T>> GetItemAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonResponse<T>> AddAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonResponse<T>> UpdateAsync(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonResponse<T>> DeleteAsync(T request);

        #endregion
    }
}
