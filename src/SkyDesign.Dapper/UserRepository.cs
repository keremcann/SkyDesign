using Dapper;
using SkyDesign.Core.Base;
using SkyDesign.Core.Connection;
using SkyDesign.Core.LogHelper;
using SkyDesign.Domain.Entities;
using SkyDesign.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SkyDesign.Dapper
{
    public class UserRepository : DbConnection, IUserRepository
    {
        public async Task<CommonResponse<User>> AddAsync(User request)
        {
            string query = String.Format("");
            var data = new CommonResponse<User>();
            data.Value = new User();
            try
            {
                data.Value = db.QueryAsync<User>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                db.Close();
                return await Task.FromResult(data);
            }
        }

        public Task<CommonResponse<User>> DeleteAsync(User request)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CommonResponse<List<User>>> GetAsync(User request)
        {
            string query = String.Format("");
            var data = new CommonResponse<List<User>>();
            data.Value = new List<User>();
            try
            {
                data.Value = db.QueryAsync<User>(query, CommandType.Text).Result.ToList();
                data.Success = true;
                db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                db.Close();
                return await Task.FromResult(data);
            }
        }

        public async Task<CommonResponse<User>> GetItemAsync(User request)
        {
            string query = String.Format("SELECT * FROM [dbo].[User] WHERE UserName='{0}' AND Password='{1}'", request.UserName, request.Password);
            var data = new CommonResponse<User>();
            data.Value = new User();
            try
            {
                data.Value = db.QueryAsync<User>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                db.Close();
                return await Task.FromResult(data);
            }
        }

        public Task<CommonResponse<User>> UpdateAsync(User request)
        {
            throw new NotImplementedException();
        }
    }
}
