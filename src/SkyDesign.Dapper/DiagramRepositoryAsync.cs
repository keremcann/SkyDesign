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
    public class DiagramRepositoryAsync : DbConnection, IDiagramRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<Diagram>> AddAsync(Diagram request)
        {
            var data = new CommonResponse<Diagram>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Diagram>("insert into Diagram(PageId, Nodes, Edges, Name, CreateUser) VALUES(@PageId, Nodes, Edges, Name, CreateUser)", new
                {
                    PageId = request.PageId,
                    Nodes = request.Nodes,
                    Edges = request.Edges,
                    Name = request.Name,
                    CreateUser = "krmcn"
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
        public async Task<CommonResponse<Diagram>> DeleteAsync(Diagram request)
        {
            var data = new CommonResponse<Diagram>();

            if (!connection.Success)
            {
                data.Value = connection.db.QueryAsync<Diagram>("update diagram set DeleteUser=@DeleteUser, DeleteDate=@DeleteDate, IsActive=@IsActive, where DiagramId=@DiagramId", new Diagram
                {
                    DiagramId = request.DiagramId,
                    DeleteUser = "krmcn",
                    IsActive = false
                }, commandType: CommandType.Text).Result.FirstOrDefault();
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
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
        public async Task<CommonResponse<List<Diagram>>> GetAllAsync()
        {
            var data = new CommonResponse<List<Diagram>>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<List<Diagram>>("select * from diagram", commandType: CommandType.Text).Result.FirstOrDefault();
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
        public Task<CommonResponse<List<Diagram>>> GetAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<Diagram>> GetItemAsync(Diagram request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<Diagram>> UpdateAsync(Diagram request)
        {
            var data = new CommonResponse<Diagram>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<Diagram>("update diagram set PageId=@PageId, Name=@Name, Nodes=@Nodes, Edges=@Edges, RoteUrl=@RoteUrl, UpdateUser=@UpdateUser, UpdateDate=@UpdateDate", new
                {
                    PageId = request.PageId,
                    Name = request.Name,
                    Nodes = request.Nodes,
                    Edges = request.Edges,
                    RoteUrl = request.PageId,
                    UpdateUser = "krmcn",
                    UpdateDate = DateTime.Now
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
