using Dapper;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Core.Helpers;
using SkyDesign.Domain.BaseTypes;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Dapper.PageBase
{
    public class PageContentRepositoryAsync : DbConnection, IPageContentRepositoryAsync
    {
        public async Task<CommonResponse<object>> AddPageDetail(CatalogContent catalogContent)
        {
            var data = new CommonResponse<object>();
            try
            {
                //INSERT INTO [dbo].[{catalogContent.TableName}] (Name, Description, Environment, BackupPolicy)
                StringBuilder queryBuilder = new StringBuilder($"INSERT INTO [dbo].[{catalogContent.TableName}] (");
                for (int columnNameIndex = 1; columnNameIndex <= catalogContent.Items.Count; columnNameIndex++)
                {
                    if (catalogContent.Items.Count == columnNameIndex)
                    {
                        queryBuilder.Append(catalogContent.Items[columnNameIndex - 1].PropertyName + ", CreateUser, CreateDate, IsActive)");
                    }
                    else
                    {
                        queryBuilder.Append(catalogContent.Items[columnNameIndex - 1].PropertyName + ",");
                    }
                }

                queryBuilder.Append(" VALUES (");

                //@'SD-VKDB', 'SD-VKDB Veritabani sunucusu', 'Development', ''
                for (int columnValueIndex = 1; columnValueIndex <= catalogContent.Items.Count; columnValueIndex++)
                {
                    if (catalogContent.Items.Count == columnValueIndex)
                    {
                        queryBuilder.Append("@" + catalogContent.Items[columnValueIndex - 1].PropertyName + $", '{"krmcn"}', '{DateTime.Now}', {1})");
                    }
                    else
                    {
                        queryBuilder.Append("@" + catalogContent.Items[columnValueIndex - 1].PropertyName + ",");
                    }
                }

                var properties = typeof(CatalogContentItem).GetProperties();

                IList<KeyValuePair<string, object>> propertyValues = new List<KeyValuePair<string, object>>();

                catalogContent.Items.ForEach(item =>
                {
                    propertyValues.Add(new KeyValuePair<string, object>(item.PropertyName, item.PropertyValue));
                });

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
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public async Task<CommonResponse<ColumnInfo<object>>> GetPageDetail(string pageUrl)
        {
            var data = new CommonResponse<ColumnInfo<object>>();
            try
            {
                string tableQuery = "SELECT TableName FROM [dbo].[Page] WHERE PageUrl = @PageUrl";
                var tableName = await connection.db.QueryFirstOrDefaultAsync<string>(tableQuery, new
                {
                    PageUrl = pageUrl
                }, commandType: CommandType.Text);

                string dataQuery = $"SELECT * FROM [dbo].[{tableName}]";
                var tableData = await connection.db.QueryAsync<object>(dataQuery, commandType: CommandType.Text);

                string columnQuery = $@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
                                     FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                var tableColumnList = await connection.db.QueryAsync<ColumnDefinition>(columnQuery, new
                {
                    TableName = tableName
                }, commandType: CommandType.Text);

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

        public async Task<CommonResponse<object>> UpdatePageDetail(CatalogContent catalogContent)
        {
            var data = new CommonResponse<object>();
            try
            {
                //UPDATE [dbo].[DataType] SET Name = @Name, Description = @Description, CreateUser = 'krmcn', CreateDate = '19.04.2022 22:11:57', IsActive = 1 where DataTypeId = 3
                StringBuilder queryBuilder = new StringBuilder($"UPDATE [dbo].[{catalogContent.TableName}] SET ");
                for (int columnNameIndex = 1; columnNameIndex <= catalogContent.Items.Count; columnNameIndex++)
                {
                    if (catalogContent.Items.Count == columnNameIndex)
                    {
                        queryBuilder.Append($"CreateUser = 'krmcn', CreateDate = '{DateTime.Now}', IsActive = 1 where {catalogContent.TableName}Id = {catalogContent.Items[0].PropertyValue}");
                    }
                    else
                    {
                        queryBuilder.Append(catalogContent.Items[columnNameIndex].PropertyName + " = @" + catalogContent.Items[columnNameIndex].PropertyName + ", ");
                    }
                }

                var properties = typeof(CatalogContentItem).GetProperties();

                IList<KeyValuePair<string, object>> propertyValues = new List<KeyValuePair<string, object>>();

                catalogContent.Items.ForEach(item =>
                {
                    propertyValues.Add(new KeyValuePair<string, object>(item.PropertyName, item.PropertyValue));
                });

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
