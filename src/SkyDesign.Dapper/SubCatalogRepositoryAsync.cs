using Dapper;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SkyDesign.Dapper
{
    public class SubCatalogRepositoryAsync : DbConnection, ISubCatalogRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<SubCatalog>> AddAsync(SubCatalog request)
        {
            string query = String.Format("INSERT INTO [dbo].[SubCatalog](SubCatalogName, CreateUser, CreateDate, IsActive) VALUES('{0}','{1}', '{2}', 1)", request.SubCatalogName, request.CreateUser, DateTime.Now);
            var data = new CommonResponse<SubCatalog>();
            data.Value = new SubCatalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<SubCatalog>> DeleteAsync(SubCatalog request)
        {
            string query = String.Format("UPDATE [dbo].[SubCatalog] SET DeleteUser='{0}', DeleteDate ='{1}', IsActive=0 WHERE SubCatalogId={2}", request.DeleteUser, DateTime.Now, request.SubCatalogId);
            var data = new CommonResponse<SubCatalog>();
            data.Value = new SubCatalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse<List<SubCatalog>>> GetAllAsync()
        {
            string query = String.Format("SELECT * FROM [dbo].[SubCatalog]");
            var data = new CommonResponse<List<SubCatalog>>();
            data.Value = new List<SubCatalog>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.ToList();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<SubCatalog>>> GetAsync(SubCatalog request)
        {
            string query = String.Format("SELECT * FROM [dbo].[SubCatalog] WHERE ...");
            var data = new CommonResponse<List<SubCatalog>>();
            data.Value = new List<SubCatalog>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.ToList();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<SubCatalog>> GetItemAsync(SubCatalog request)
        {
            string query = String.Format("SELECT * FROM [dbo].[SubCatalog] WHERE SubCatalogId={0}", request.SubCatalogId);
            var data = new CommonResponse<SubCatalog>();
            data.Value = new SubCatalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<SubCatalog>> UpdateAsync(SubCatalog request)
        {
            string query = String.Format("UPDATE [dbo].[SubCatalog] SET SubCatalogName='{0}', UpdateUser='{1}', UpdateDate ='{2}' WHERE SubCatalogId={3}", request.SubCatalogName, request.UpdateUser, DateTime.Now, request.SubCatalogId);
            var data = new CommonResponse<SubCatalog>();
            data.Value = new SubCatalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalog>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }
    }
}
