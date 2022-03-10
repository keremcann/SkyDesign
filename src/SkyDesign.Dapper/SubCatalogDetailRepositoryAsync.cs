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
    public class SubCatalogDetailRepositoryAsync : DbConnection, ISubCatalogDetailRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<SubCatalogDetail>> AddAsync(SubCatalogDetail request)
        {
            string query = String.Format(
                @"insert into SubCatalogDetail (SubCatalogId, Name, [Description], [Type], [Status], CreateUser, CreateDate, IsActive)
					                    values (@SubCatalogId, @Name, @Description, 'Sample type', 'Sample status', 'krmcn', @Date, 1)");
            var data = new CommonResponse<SubCatalogDetail>();
            data.Value = new SubCatalogDetail();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, new
                {
                    SubCatalogId = request.SubCatalogId,
                    Name = request.Name,
                    Description = request.Description,
                    Date = DateTime.Now
                }, commandType: CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<SubCatalogDetail>> DeleteAsync(SubCatalogDetail request)
        {
            string query = String.Format("update SubCatalogDetail set IsActive = 0 where SubCatalogDetailId = @SubCatalogDetailId");
            var data = new CommonResponse<SubCatalogDetail>();
            data.Value = new SubCatalogDetail();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, new
                {
                    SubCatalogDetailId = request.SubCatalogDetailId
                }, commandType: CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<List<SubCatalogDetail>>> GetAllAsync()
        {
            string query = String.Format("");
            var data = new CommonResponse<List<SubCatalogDetail>>();
            data.Value = new List<SubCatalogDetail>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<List<SubCatalogDetail>>> GetAllBySubCatalogIdAsync(int subCatalogId)
        {
            string query = String.Format("select * from SubCatalogDetail where SubCatalogId = @SubCatalogId and IsActive = 1");
            var data = new CommonResponse<List<SubCatalogDetail>>();
            data.Value = new List<SubCatalogDetail>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query,new
                {
                    SubCatalogId = subCatalogId
                }, commandType: CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<List<SubCatalogDetail>>> GetAsync(SubCatalogDetail request)
        {
            string query = String.Format("");
            var data = new CommonResponse<List<SubCatalogDetail>>();
            data.Value = new List<SubCatalogDetail>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<SubCatalogDetail>> GetItemAsync(SubCatalogDetail request)
        {
            string query = String.Format("");
            var data = new CommonResponse<SubCatalogDetail>();
            data.Value = new SubCatalogDetail();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<SubCatalogDetail>> UpdateAsync(SubCatalogDetail request)
        {
            string query = String.Format(@"update SubCatalogDetail set SubCatalogId = @SubCatalogId, Name = @Name, Description = @Description where SubCatalogDetailId = @SubCatalogDetailId");
            var data = new CommonResponse<SubCatalogDetail>();
            data.Value = new SubCatalogDetail();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<SubCatalogDetail>(query, new
                {
                    SubCatalogId = request.SubCatalogId,
                    Name = request.Name,
                    Description = request.Description,
                    SubCatalogDetailId = request.SubCatalogDetailId,

                }, commandType: CommandType.Text).Result.FirstOrDefault();
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
