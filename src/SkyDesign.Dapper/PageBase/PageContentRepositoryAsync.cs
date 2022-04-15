using Dapper;
using SkyDesign.Core.Connection;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SkyDesign.Dapper.PageBase
{
    public class PageContentRepositoryAsync: DbConnection, IPageContentRepositoryAsync
    {
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
    }
}
