using SkyDesign.Core.Base;
using System.Collections.Generic;

namespace SkyDesign.Domain.Common
{
    public interface IRepository<T>
    {
        #region Not Async Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        CommonResponse<List<T>> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<List<T>> Get(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> GetItem(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Add(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Update(T request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Delete(T request);

        #endregion
    }
}
