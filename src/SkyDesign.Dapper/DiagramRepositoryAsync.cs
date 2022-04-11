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
                data.Value = connection.db.QueryAsync<Diagram>("INSERT INTO Diagram(PageId, Nodes, Edges, Name, CreateUser, CreateDate) VALUES(@PageId, @Nodes, @Edges, @Name, @CreateUser, @CreateDate)", new
                {
                    PageId = request.PageId,
                    Nodes = request.Nodes,
                    Edges = request.Edges,
                    Name = request.Name,
                    CreateUser = "krmcn",
                    CreateDate = DateTime.Now
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
                data.Value = connection.db.QueryAsync<Diagram>("UPDATE Diagram SET DeleteUser=@DeleteUser, DeleteDate=@DeleteDate, IsActive=@IsActive, where DiagramId=@DiagramId", new Diagram
                {
                    DiagramId = request.DiagramId,
                    DeleteUser = "krmcn",
                    DeleteDate = DateTime.Now,
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
                data.Value = connection.db.QueryAsync<List<Diagram>>("SELECT * FROM Diagram WHERE IsActive = 1", commandType: CommandType.Text).Result.FirstOrDefault();
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
        public async Task<CommonResponse<List<Diagram>>> GetAllByPageIdAsync(int pageId)
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
                data.Value = connection.db.QueryAsync<List<Diagram>>("SELECT * FROM Diagram WHERE PageId=@PageId and IsActive = 1", new { PageId = pageId }, commandType: CommandType.Text).Result.FirstOrDefault();
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
                data.Value = connection.db.QueryAsync<Diagram>("UPDATE Diagram SET PageId=@PageId, Name=@Name, Nodes=@Nodes, Edges=@Edges, RoteUrl=@RoteUrl, UpdateUser=@UpdateUser, UpdateDate=@UpdateDate WHERE DiagramId=@DiagramId", new
                {
                    DiagramId = request.DiagramId,
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
