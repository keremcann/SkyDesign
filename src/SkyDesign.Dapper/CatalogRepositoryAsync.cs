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
    public class CatalogRepositoryAsync : DbConnection, ICatalogRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<Catalog>> AddAsync(Catalog request)
        {
            string query = String.Format("INSERT INTO [dbo].[Catalog](CatalogName, CreateUser, CreateDate, IsActive) VALUES('{0}','{1}', '{2}', 1)", request.CatalogName, request.CreateUser, DateTime.Now);
            var data = new CommonResponse<Catalog>();
            data.Value = new Catalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<Catalog>> DeleteAsync(Catalog request)
        {
            string query = String.Format("UPDATE [dbo].[Catalog] SET DeleteUser='{0}', DeleteDate ='{1}', IsActive=0 WHERE CatalogId={2}", request.DeleteUser, DateTime.Now, request.CatalogId);
            var data = new CommonResponse<Catalog>();
            data.Value = new Catalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<List<Catalog>>> GetAllAsync()
        {
            string query = String.Format("SELECT * FROM [dbo].[Catalog]");
            var data = new CommonResponse<List<Catalog>>();
            data.Value = new List<Catalog>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<List<Catalog>>> GetAsync(Catalog request)
        {
            string query = String.Format("SELECT * FROM [dbo].[Catalog] WHERE...");
            var data = new CommonResponse<List<Catalog>>();
            data.Value = new List<Catalog>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<Catalog>> GetItemAsync(Catalog request)
        {
            string query = String.Format("SELECT * FROM [dbo].[Catalog] WHERE CatalogId={0}", request.CatalogId);
            var data = new CommonResponse<Catalog>();
            data.Value = new Catalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<Catalog>> UpdateAsync(Catalog request)
        {
            string query = String.Format("UPDATE [dbo].[Catalog] SET CatalogName='{0}', UpdateUser='{1}', UpdateDate ='{2}' WHERE CatalogId={3}", request.CatalogName, request.UpdateUser, DateTime.Now, request.CatalogId);
            var data = new CommonResponse<Catalog>();
            data.Value = new Catalog();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Catalog>(query, CommandType.Text).Result.FirstOrDefault();
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
