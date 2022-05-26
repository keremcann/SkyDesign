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
            var data = new CommonResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            using var transaction = connection.db.BeginTransaction();
            try
            {
                #region insert new user
                await connection.db.ExecuteAsync(
                    sql: @"
                            INSERT INTO [dbo].[User] (FullName, UserName, Password, Email, CreateUser, CreateDate, IsActive) VALUES
                                                     (@FullName, @UserName, @Password, @Email, @CreateUser, @CreateDate, @IsActive)",
                    param: new
                    {
                        FullName = request.FullName,
                        UserName = request.UserName,
                        Password = request.Password,
                        Email = request.Email,
                        CreateUser = "krmcn",
                        CreateDate = DateTime.Now,
                        IsActive = true
                    },
                    commandType: CommandType.Text,
                    transaction: transaction);
                #endregion

                #region select new user id (last user)
                int registeredUserId = await connection.db.QueryFirstOrDefaultAsync<int>("SELECT TOP 1 UserId FROM [dbo].[User] ORDER BY 1 DESC", CommandType.Text, transaction);
                #endregion

                #region insert user role
                await connection.db.ExecuteAsync(
                    sql: "INSERT INTO [dbo].[UserRole] (UserId, RoleId, CreateUser, CreateDate, IsActive) VALUES(@UserId, @RoleId, @CreateUser, @CreateDate, @IsActive)",
                    new
                    {
                        UserId = registeredUserId,
                        RoleId = request.Roles[0].RoleId,
                        CreateUser = "krmcn",
                        CreateDate = DateTime.Now,
                        IsActive = true,
                    },
                    commandType: CommandType.Text,
                    transaction: transaction);
                #endregion

                transaction.Commit();
                connection.db.Close();
                data.Success = true;
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;

                transaction.Rollback();
                transaction.Dispose();
                connection.db.Close();

                return await Task.FromResult(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommonResponse<User>> DeleteAsync(User request)
        {
            string query = String.Format("DELETE FROM [dbo].[User] WHERE UserId={0}", request.UserId);
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
                data.Value = connection.db.QueryAsync<User>(query, CommandType.Text).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Successfully";
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

        public async Task<CommonResponse<User>> GetUserInformationByIdAsync(int userId)
        {
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
                var result = await connection.db.QueryAsync<User, Role, User>(
                    sql: @"
                                SELECT * FROM [DBO].[User] u
                                inner join [DBO].[UserRole] ur on u.UserId = ur.UserId
                                where u.UserId = @UserId",
                    map: (user, role) =>
                    {
                        user.Roles ??= new List<Role>();
                        user.Roles?.Add(role);
                        return user;
                    }, splitOn: "UserRoleId",
                    param: new
                    {
                        UserId = userId
                    });

                data.Value = result.FirstOrDefault();
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
        public async Task<CommonResponse<User>> UpdateAsync(User request)
        {
            string query = String.Format("UPDATE [dbo].[User] SET FullName='{0}', UserName='{1}', Password='{2}', Email='{3}', UpdateUser='{4}', UpdateDate='{5}'  WHERE UserId={6}", request.FullName, request.UserName, request.Password, request.Email, "krmcn", DateTime.Now, request.UserId);
            var data = new CommonResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            using var transaction = connection.db.BeginTransaction();
            try
            {
                await connection.db.ExecuteAsync(
                    sql: @"
                            UPDATE [dbo].[User] SET FullName=@FullName, UserName=@UserName, Password=@Password, Email=@Email, UpdateUser=@UpdateUser, UpdateDate=@UpdateDate WHERE UserId=@UserId",
                    param: request,
                    commandType: CommandType.Text,
                    transaction: transaction);

                await connection.db.ExecuteAsync(
                    sql: @"
                            UPDATE [dbo].[UserRole] SET RoleId=@RoleId WHERE UserId=@UserId",
                    param: new
                    {
                        UserId = request.UserId,
                        RoleId = request.Roles[0].RoleId
                    },
                    commandType: CommandType.Text,
                    transaction: transaction);

                data.Success = true;
                data.InfoMessage = "Successfully";

                transaction.Commit();
                connection.db.Close();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;

                FileLog log = new FileLog();
                log.Error(ex.Message);

                transaction.Rollback();
                transaction.Dispose();
                connection.db.Close();

                return await Task.FromResult(data);
            }
        }
    }
}
