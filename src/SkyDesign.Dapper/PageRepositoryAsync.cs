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
    public class PageRepositoryAsync : DbConnection, IPageRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<Page>> AddAsync(Page request)
        {
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
                await connection.db.ExecuteAsync(
                    sql: $@"INSERT INTO [dbo].[Page](ParentId, IsCustom, PageName, PageIcon, Description, PageUrl, CreateUser, CreateDate, IsActive)
                                              VALUES(@ParentId, @IsCustom, @PageName, @PageIcon, @Description, @PageUrl, @CreateUser, @CreateDate, @IsActive)",
                    param: new Page
                    {
                        ParentId = request.ParentId,
                        IsCustom = request.IsCustom,
                        PageName = request.PageName,
                        PageIcon = request.PageIcon,
                        Description = request.Description,
                        PageUrl = request.PageUrl,
                        CreateUser = "krmcn",
                        CreateDate = DateTime.Now,
                        IsActive = true
                    },
                    commandType: CommandType.Text
                    );

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

        public async Task<CommonResponse<string>> CreateDefaultTable(Page request)
        {
            var data = new CommonResponse<string>();
            data.Value = string.Empty;

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                //pageName i SampleTableName
                await connection.db.ExecuteAsync(
                    sql: $@"
                            CREATE TABLE [DBO].{request.TableName} (
                                {request.TableName}Id int IDENTITY(1,1) PRIMARY KEY,
                                Name varchar(100) NOT NULL,
                                Description varchar(150),
                                CreateUser varchar(50) NOT NULL,
                                CreateDate datetime NOT NULL,
                                UpdateUser varchar(50),
                                UpdateDate datetime,
                                DeleteUser varchar(50),
                                DeleteDate datetime,
                                IsActive bit NOT NULL
                            );
                            ",
                    commandType: CommandType.Text
                    );

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
            string query = String.Format("SELECT * FROM [dbo].[Page] WHERE IsActive=1");
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

        public async Task<CommonResponse<List<ColumnList>>> GetAllColumnListAsync()
        {
            var data = new CommonResponse<List<ColumnList>>();
            data.Value = new List<ColumnList>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<ColumnList>(
                    sql: "SELECT * FROM [DBO].[ColumnList]",
                    commandType: CommandType.Text).Result.ToList();
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
