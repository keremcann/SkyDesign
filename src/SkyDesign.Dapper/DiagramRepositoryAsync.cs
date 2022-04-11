using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyDesign.Dapper
{
    public class DiagramRepositoryAsync : DbConnection, IDiagramRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Diagram>> AddAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Diagram>> DeleteAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<CommonResponse<List<Diagram>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<List<Diagram>>> GetAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Diagram>> GetItemAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Diagram>> UpdateAsync(Diagram request)
        {
            throw new NotImplementedException();
        }
    }
}
