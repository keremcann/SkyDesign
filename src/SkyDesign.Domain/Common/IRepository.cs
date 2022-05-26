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
        CommonResponse<T> Get(object id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommonResponse<T> Delete(object id);

        #endregion
    }
}
