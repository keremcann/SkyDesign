using Dapper;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.Dtos;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SkyDesign.Dapper
{
    public class PageRepositoryAsync : DbConnection, IPageRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<Page>> AddAsync(Page request)
        {
            string query = String.Format("INSERT INTO [dbo].[Page](PageName, Description, PageIcon, PageUrl, CreateUser, CreateDate, IsActive) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',1)", request.PageName, request.Description, request.PageIcon, request.PageUrl, request.CreateUser, DateTime.Now);
            var data = new CommonResponse<Page>();
            data.Value = new Page();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<Page>> AddRolePageAsync(Page request)
        {
            string query = String.Format("INSERT INTO [dbo].[RolePage](RoleId, PageId, CreateUser, CreateDate, IsActive) VALUES('{0}','{1}', '{2}', '{3}', 1)", request.RoleId, request.PageId, request.CreateUser, DateTime.Now);
            var data = new CommonResponse<Page>();
            data.Value = new Page();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<Page>> DeleteAsync(Page request)
        {
            string query = String.Format("UPDATE [dbo].[Page] SET DeleteUser='{0}', DeleteDate ='{1}', IsActive=0 WHERE PageId={2}", request.DeleteUser, DateTime.Now, request.RoleId);
            var data = new CommonResponse<Page>();
            data.Value = new Page();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<List<Page>>> GetAllAsync()
        {
            string query = String.Format("SELECT * FROM [dbo].[Page]");
            var data = new CommonResponse<List<Page>>();
            data.Value = new List<Page>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<List<Page>>> GetAsync(Page request)
        {
            string query = String.Format("SELECT * FROM [dbo].[Page] WHERE ...");
            var data = new CommonResponse<List<Page>>();
            data.Value = new List<Page>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<Page>> GetItemAsync(Page request)
        {
            string query = String.Format("SELECT * FROM [dbo].[Page] WHERE PageId={0}", request.PageId);
            var data = new CommonResponse<Page>();
            data.Value = new Page();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Page>(query, CommandType.Text).Result.FirstOrDefault();
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

        public async Task<ColumnInfo<object>> GetPageDetail(string pageUrl)
        {
            var data = new ColumnInfo<object>();
            try
            {
                var tableName = connection.db.QueryAsync<string>("select TableName from Page where PageUrl = @PageUrl", new
                {
                    PageUrl = pageUrl
                }, commandType: CommandType.Text).Result.FirstOrDefault().ToString();

                var tableData = connection.db.QueryAsync<dynamic>($"select * from {tableName}", commandType: CommandType.Text).Result.ToList();

                var tableColumnList = connection.db.QueryAsync<ColumnDefinition>($@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName", new
                {
                    TableName = tableName
                }, commandType: CommandType.Text).Result.ToList();

                

                data = new ColumnInfo<object>
                {
                    Data = tableData,
                    ColumnList = tableColumnList
                };

                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                connection.db.Close();
                return await Task.FromResult(data);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Page>> UpdateAsync(Page request)
        {
            throw new NotImplementedException();
        }
    }
}
