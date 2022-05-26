using Dapper;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
                    sql: $@"INSERT INTO [dbo].[Page](ParentId, IsCustom, PageName, PageIcon, Description, PageUrl, CreateUser, CreateDate, IsActive, TableName)
                                              VALUES(@ParentId, @IsCustom, @PageName, @PageIcon, @Description, @PageUrl, @CreateUser, @CreateDate, @IsActive, @TableName)",
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
                        TableName = request.TableName,
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
        /// <param name="pageId"></param>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        /// <param name="hasRelationship"></param>
        /// <param name="nullable"></param>
        /// <param name="joinedTableName">table to be joined</param>
        /// <returns></returns>
        public async Task<CommonResponse<object>> AddColumnToTable(int pageId,
                                                                   string columnName,
                                                                   string dataType,
                                                                   string hasRelationship,
                                                                   string nullable,
                                                                   string joinedTableName)
        {
            var data = new CommonResponse<object>();
            data.Value = new object();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var tableName = await connection.db.QueryFirstOrDefaultAsync<string>("SELECT TableName FROM [dbo].[Page] WHERE PageId = @PageId", new
                {
                    PageId = pageId
                }, commandType: CommandType.Text);

                var query = @$"ALTER TABLE {tableName} 
                                ADD {(hasRelationship == "1" ? $"{columnName}Id" : $"{columnName}")} 
                                    {(hasRelationship == "1" ? "INT" : dataType)} 
                                    {(nullable == "#NULL#" ? "NULL" : "NOT NULL")}";
                await connection.db.ExecuteAsync(
                    sql: query,
                    commandType: CommandType.Text
                    );

                data.Success = true;
                data.InfoMessage = "İşlem başarılı!";
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
        /// <param name="pageId"></param>
        /// <param name="columnName"></param>
        /// <param name="hasRelationship"></param>
        /// <param name="joinedTableName"></param>
        /// <returns></returns>
        public async Task<CommonResponse<object>> DropColumnFromTable(int pageId,
                                                                      string columnName,
                                                                      string hasRelationship,
                                                                      string joinedTableName)
        {
            var data = new CommonResponse<object>();
            data.Value = new object();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var tableName = await connection.db.QueryFirstOrDefaultAsync<string>("SELECT TableName FROM [dbo].[Page] WHERE PageId = @PageId", new
                {
                    PageId = pageId
                }, commandType: CommandType.Text);

                await connection.db.ExecuteAsync(
                    sql: @$"
                                ALTER TABLE {tableName} 
                                DROP COLUMN {(hasRelationship == "1" ? $"{columnName}Id" : $"{columnName}")}
                           ",
                    commandType: CommandType.Text
                    );

                data.Success = true;
                data.InfoMessage = "İşlem başarılı!";
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

        public async Task<CommonResponse<dynamic>> GetAddOrUpdateModalDetailPage(string selectedPage, int? id)
        {
            var data = new CommonResponse<dynamic>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var tableName = connection.db.QueryFirstOrDefault<string>("SELECT TableName FROM [dbo].[Page] WHERE PageUrl = @PageUrl", new
                {
                    PageUrl = selectedPage
                }, commandType: CommandType.Text);


                IDictionary<string, object> selectedItem = null;

                if (id != null)
                    selectedItem = connection.db.QueryFirstOrDefault(
                        sql: $"SELECT * FROM [dbo].[{tableName}] WHERE {tableName}Id = @Id",
                        param: new { Id = id },
                        commandType: CommandType.Text);

                string columnQuery = $@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
                                     FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                var genericTableColumnList = (List<ColumnDefinition>)connection.db.Query<ColumnDefinition>(columnQuery, new
                {
                    TableName = tableName
                }, commandType: CommandType.Text);
                genericTableColumnList.ForEach(gtc => gtc.IsInColumn = true);

                genericTableColumnList.AddRange(new List<ColumnDefinition> {
                    new ColumnDefinition { ColumnName = "Name" },
                    new ColumnDefinition { ColumnName = "Description" },
                });

                var definedTableColumnList = (List<ColumnDefinition>)await connection.db.QueryAsync<ColumnDefinition>(
                    sql: $@"SELECT * FROM [dbo].[ColumnList]",
                    commandType: CommandType.Text
                    );

                definedTableColumnList.AddRange(new List<ColumnDefinition> {
                    new ColumnDefinition { ColumnName = "Name" },
                    new ColumnDefinition { ColumnName = "Description" },
                });

                definedTableColumnList.ForEach((definedTableColumn) =>
                {
                    if (genericTableColumnList.Contains(definedTableColumn))
                    {
                        definedTableColumn.IsInColumn = true;
                        definedTableColumn.CurrentData = selectedItem?[definedTableColumn.ColumnName] ?? "";

                        return;
                    }

                    definedTableColumn.ColumnName += "Id";
                    if (genericTableColumnList.Contains(definedTableColumn))
                    {
                        definedTableColumn.IsInColumn = true;
                        definedTableColumn.CurrentData = selectedItem?[definedTableColumn.ColumnName] ?? "";
                    }
                    definedTableColumn.ColumnName = definedTableColumn.ColumnName[0..^2];

                });

                definedTableColumnList.ForEach(dtc =>
                {
                    if (dtc.HasRelation != "1") return;

                    var joinedTableData = connection.db.Query<RelationalData>(
                        sql: $"SELECT {dtc.TableName}Id as Id, Name from {dtc.TableName}",
                        commandType: CommandType.Text).ToList();

                    dtc.RelationalDataList.AddRange(joinedTableData);
                });

                bool matchedColumnDefinitions(ColumnDefinition dtc) =>
                                        genericTableColumnList.Exists(gtc => dtc.ColumnName + "Id" == gtc.ColumnName) ||
                                        genericTableColumnList.Exists(gtc => dtc.ColumnName == gtc.ColumnName);

                data.Value = definedTableColumnList.Where(matchedColumnDefinitions);

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <param name="pageId"></param>
        /// <returns></returns>
        public async Task<CommonResponse<List<ColumnDefinition>>> GetAllColumnListByPageId(int pageId)
        {
            var data = new CommonResponse<List<ColumnDefinition>>();
            data.Value = new List<ColumnDefinition>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {

                var tableName = await connection.db.QueryFirstOrDefaultAsync<string>("SELECT TableName FROM [dbo].[Page] WHERE PageId = @PageId", new
                {
                    PageId = pageId
                }, commandType: CommandType.Text);

                string columnQuery = $@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
                                     FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                var genericTableColumnList = (List<ColumnDefinition>)await connection.db.QueryAsync<ColumnDefinition>(columnQuery, new
                {
                    TableName = tableName
                }, commandType: CommandType.Text);
                for (int i = 0; i < genericTableColumnList.Count; i++)
                {
                    genericTableColumnList[i].IsInColumn = true;
                }

                var definedTableColumnList = (List<ColumnDefinition>)await connection.db.QueryAsync<ColumnDefinition>(
                    sql: $@"SELECT * FROM [dbo].[ColumnList]",
                    commandType: CommandType.Text
                    );

                for (int i = 0; i < definedTableColumnList.Count; i++)
                {
                    if (genericTableColumnList.Contains(definedTableColumnList[i]))
                    {
                        definedTableColumnList[i].IsInColumn = true;
                        continue;
                    }

                    definedTableColumnList[i].ColumnName = definedTableColumnList[i].ColumnName + "Id";
                    if (genericTableColumnList.Contains(definedTableColumnList[i]))
                    {
                        definedTableColumnList[i].IsInColumn = true;
                    }
                    definedTableColumnList[i].ColumnName = definedTableColumnList[i].ColumnName[0..^2];
                }

                data.Value = definedTableColumnList;

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
