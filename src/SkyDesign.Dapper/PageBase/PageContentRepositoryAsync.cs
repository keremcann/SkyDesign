﻿using Dapper;
using SkyDesign.Core.Base;
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
