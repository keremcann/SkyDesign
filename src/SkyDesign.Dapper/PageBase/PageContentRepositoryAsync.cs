using Dapper;
using Newtonsoft.Json;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.CatalogBaseTypes;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Dapper.PageBase
{
    /// <summary>
    /// 
    /// </summary>
    public class PageContentRepositoryAsync : DbConnection, IPageContentRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogContent"></param>
        /// <returns></returns>
        public async Task<CommonResponse<object>> CreatePageDetail(CatalogContent catalogContent)
        {
            var data = new CommonResponse<object>();
            try
            {
                StringBuilder queryBuilder = new StringBuilder($"INSERT INTO [dbo].[{catalogContent.TableName}] (");
                for (int columnNameIndex = 1; columnNameIndex <= catalogContent.Items.Count; columnNameIndex++)
                {
                    if (catalogContent.Items.Count == columnNameIndex)
                        queryBuilder.Append(catalogContent.Items[columnNameIndex - 1].PropertyName + ", CreateUser, CreateDate, IsActive)");
                    else
                        queryBuilder.Append(catalogContent.Items[columnNameIndex - 1].PropertyName + ",");
                }

                queryBuilder.Append(" VALUES (");

                for (int columnValueIndex = 1; columnValueIndex <= catalogContent.Items.Count; columnValueIndex++)
                {
                    if (catalogContent.Items.Count == columnValueIndex)
                        queryBuilder.Append("@" + catalogContent.Items[columnValueIndex - 1].PropertyName + $", '{"krmcn"}', '{DateTime.Now}', {1})");
                    else
                        queryBuilder.Append("@" + catalogContent.Items[columnValueIndex - 1].PropertyName + ",");
                }

                var properties = typeof(CatalogContentItem).GetProperties();

                IList<KeyValuePair<string, object>> propertyValues = new List<KeyValuePair<string, object>>();

                catalogContent.Items.ForEach(item =>
                {
                    propertyValues.Add(new KeyValuePair<string, object>(item.PropertyName, item.PropertyValue));
                });

                if (!connection.Success)
                {
                    data.Success = false;
                    data.ErrorMessage = connection.ErrorMessage;
                    return await Task.FromResult(data);
                }

                await connection.db.ExecuteAsync(queryBuilder.ToString(), propertyValues, commandType: CommandType.Text);

                data.Success = true;
                data.InfoMessage = "Successfull";
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
        /// <param name="catalogContent"></param>
        /// <returns></returns>
        public async Task<CommonResponse<object>> DeletePageDetail(string tableName, int id)
        {
            var data = new CommonResponse<object>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                await connection.db.ExecuteAsync($"DELETE FROM [dbo].[{tableName}] WHERE {tableName}Id = {id}");

                data.Success = true;
                data.InfoMessage = "Successfull";
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
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public async Task<CommonResponse<ColumnInfo<object>>> GetPageDetail(string pageUrl)
        {
            var data = new CommonResponse<ColumnInfo<object>>();
            try
            {
                if (!connection.Success)
                {
                    data.Success = false;
                    data.ErrorMessage = connection.ErrorMessage;
                    return await Task.FromResult(data);
                }

                string tableQuery = "SELECT TableName FROM [dbo].[Page] WHERE PageUrl = @PageUrl";
                var tableName = connection.db.QueryFirstOrDefaultAsync<string>(tableQuery, new
                {
                    PageUrl = pageUrl
                }, commandType: CommandType.Text).Result;


                string columnQuery = $@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
                                     FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                var tableColumnList = connection.db.QueryAsync<ColumnDefinition>(columnQuery, new
                {
                    TableName = tableName
                }, commandType: CommandType.Text).Result.ToList();

                var tableColumnDefinitionList = connection.db.QueryAsync<ColumnDefinition>($"SELECT * FROM [dbo].[ColumnList]").Result.ToList();

                StringBuilder selectBuilder = new(@$"
                                    mainTable.{tableName + "Id"},
                                    mainTable.Name,
                                    mainTable.Description,
                                    mainTable.CreateUser,
                                    mainTable.CreateDate,
                                    mainTable.UpdateUser,
                                    mainTable.UpdateDate,
                                    mainTable.DeleteUser,
                                    mainTable.DeleteDate,
                                    mainTable.IsActive");

                StringBuilder dataQueryBuilder = new($"SELECT {{{{SELECT_DATA}}}} FROM [dbo].[{tableName}] mainTable");

                foreach (var tableColumnItem in tableColumnList.ToList())
                {
                    if (tableColumnDefinitionList.Exists(tcd => tcd.ColumnName == tableColumnItem?.ColumnName))
                    {
                        selectBuilder.Append($",{tableColumnItem.ColumnName}");
                        continue;
                    }

                    if (
                        tableColumnItem == null ||
                        tableColumnItem.ColumnName == tableName + "Id" ||
                        !tableColumnItem.ColumnName.EndsWith("Id") ||
                        !tableColumnDefinitionList.Exists(tcd =>tcd.ColumnName != tableColumnItem.ColumnName))
                        continue;

                    var tableColumnDefinition = tableColumnDefinitionList.Find(tcd => tcd.ColumnName == tableColumnItem.ColumnName?[0..^2]);

                    if (tableColumnDefinition is not null)
                    {
                        dataQueryBuilder.AppendLine(@$"
                                LEFT OUTER JOIN {tableColumnDefinition.TableName} as {tableColumnItem.ColumnName[0..^2]}
                                ON mainTable.{tableColumnItem.ColumnName} = {tableColumnItem.ColumnName[0..^2]}.{tableColumnDefinition.TableName + "Id"}");

                        selectBuilder.Append($",{tableColumnItem.ColumnName[0..^2]}.Name as {tableColumnItem.ColumnName[0..^2]}");

                        tableColumnList.Add(new ColumnDefinition
                        {
                            ColumnName = tableColumnDefinition.ColumnName
                        });

                        tableColumnList.Remove(tableColumnList.Find(tcl => tcl.ColumnName == tableColumnDefinition.ColumnName + "Id"));
                    }
                }

                var query = dataQueryBuilder.ToString().Replace("{{SELECT_DATA}}", selectBuilder.ToString());

                var tableData = connection.db.QueryAsync<dynamic>(query, commandType: CommandType.Text).Result.ToList();

                data.Value = new ColumnInfo<object>
                {
                    Data = tableData,
                    ColumnList = tableColumnList
                };
                data.Success = true;
                data.InfoMessage = "Successfull";
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
        /// <param name="catalogContent"></param>
        /// <returns></returns>
        public async Task<CommonResponse<object>> UpdatePageDetail(CatalogContent catalogContent)
        {
            var data = new CommonResponse<object>();
            try
            {
                StringBuilder queryBuilder = new StringBuilder($"UPDATE [dbo].[{catalogContent.TableName}] SET ");
                for (int columnNameIndex = 1; columnNameIndex <= catalogContent.Items.Count; columnNameIndex++)
                {
                    if (catalogContent.Items.Count == columnNameIndex)
                        queryBuilder.Append($"CreateUser = 'krmcn', CreateDate = '{DateTime.Now}', IsActive = 1 WHERE {catalogContent.TableName}Id = {catalogContent.Items[0].PropertyValue}");
                    else
                        queryBuilder.Append(catalogContent.Items[columnNameIndex].PropertyName + " = @" + catalogContent.Items[columnNameIndex].PropertyName + ", ");
                }

                var properties = typeof(CatalogContentItem).GetProperties();

                IList<KeyValuePair<string, object>> propertyValues = new List<KeyValuePair<string, object>>();

                catalogContent.Items.ForEach(item =>
                {
                    propertyValues.Add(new KeyValuePair<string, object>(item.PropertyName, item.PropertyValue));
                });

                if (!connection.Success)
                {
                    data.Success = false;
                    data.ErrorMessage = connection.ErrorMessage;
                    return await Task.FromResult(data);
                }

                await connection.db.ExecuteAsync(queryBuilder.ToString(), propertyValues);

                data.Success = true;
                data.InfoMessage = "Successfull";
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
