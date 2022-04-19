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
                var tableName = connection.db.QueryAsync<string>(tableQuery, new
                {
                    PageUrl = pageUrl
                }, commandType: CommandType.Text).Result.FirstOrDefault().ToString();

                string dataQuery = $"SELECT * FROM [dbo].[{tableName}]";
                var tableData = connection.db.QueryAsync<dynamic>(dataQuery, commandType: CommandType.Text).Result.ToList();
                string columnQuery = $@"SELECT TABLE_SCHEMA TableSchema, TABLE_NAME TableName, COLUMN_NAME ColumnName, DATA_TYPE DataType
                                     FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                var tableColumnList = connection.db.QueryAsync<ColumnDefinition>(columnQuery, new
                {
                    TableName = tableName
                }, commandType: CommandType.Text).Result.ToList();

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
    }
}
