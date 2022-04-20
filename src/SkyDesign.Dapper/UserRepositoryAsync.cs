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
    public class UserRepositoryAsync : DbConnection, IUserRepositoryAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<User>> AddAsync(User request)
        {
            string query = String.Format("INSERT INTO [dbo].[User](FullName, UserName, Password, Email, CreateUser, CreateDate, IsActive) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6})", request.FullName, request.UserName, request.Password, request.Email, "krmcn", DateTime.Now, 1);
            var data = new CommonResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                #region insert new user
                data.Value = connection.db.QueryAsync<User>(query, CommandType.Text).Result.FirstOrDefault();
                #endregion

                #region select new user id (last user)
                int userId = connection.db.QueryAsync<int>("SELECT TOP 1 UserId FROM [dbo].[User] ORDER BY 1 DESC", CommandType.Text).Result.FirstOrDefault();
                #endregion

                #region insert user role
                var userRole = connection.db.QueryAsync<dynamic>(String.Format("INSERT INTO [dbo].[UserRole](UserId, RoleId, CreateUser, CreateDate, IsActive) VALUES({0}, {1}, {2}, {3}, {4})", userId, request.RoleId, "krmcn", DateTime.Now, 1), CommandType.Text).Result.FirstOrDefault();
                #endregion

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
        public Task<CommonResponse<User>> DeleteAsync(User request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse<List<User>>> GetAllAsync()
        {
            string query = String.Format("SELECT * FROM [dbo].[User] WHERE IsActive=1");
            var data = new CommonResponse<List<User>>();
            data.Value = new List<User>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<User>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<List<User>>> GetAsync(User request)
        {
            string query = String.Format("");
            var data = new CommonResponse<List<User>>();
            data.Value = new List<User>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<User>(query, CommandType.Text).Result.ToList();
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
        public async Task<CommonResponse<User>> GetItemAsync(User request)
        {
            string query = String.Format("SELECT * FROM [dbo].[User] WHERE UserName=@UserName AND Password=@Password AND IsActive=1");
            var data = new CommonResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection.db.QueryAsync<User>(query, new
                {
                    request.UserName,
                    request.Password
                }, commandType: CommandType.Text).Result.FirstOrDefault();

                if (data.Value != null)
                {
                    data.Success = true;
                    data.InfoMessage = "Kullanıcı bulundu";
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "Kullanıcı bulunamadı";
                }
                connection.db.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
                connection.db.Close();
                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CommonResponse<User>> UpdateAsync(User request)
        {
            throw new NotImplementedException();
        }
    }
}
