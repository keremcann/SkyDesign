using SkyDesign.Core.Configuration;
using SkyDesign.Core.Cryptography;
using SkyDesign.Core.LogHelper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SkyDesign.Core.Connection
{
    public abstract class DbConnection
    {
        public DbConnectionResult connection;

        /// <summary>
        /// 
        /// </summary>
        public DbConnection()
        {
            connection = OpenConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DbConnectionResult OpenConnection()
        {
            var response = new DbConnectionResult();
            try
            {
                IDbConnection _db = new SqlConnection(EditConnectionString(AppSettings.GetConnectionString()));
                _db.Open();
                response.db = _db;
                response.Success = true;
                response.ErrorMessage = "Success";                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static string DecryptPassword(string connectionString)
        {
            int indexStart = connectionString.IndexOf("Password") + "Password".Length;
            int indexEnd = connectionString.IndexOf(";", indexStart);
            return connectionString.Substring(indexStart, indexEnd - indexStart);
        }

        /// <summary>
        /// ConnectionString'teki Encrypt'li DB kullanıcı şifresini çözer ve ConnectionString'e geri ekler.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static string EditConnectionString(string connectionString)
        {
            string secretPassword = AppSettings.GetConnectionStringPassword();
            string password = Decryption.DecryptWithDefaultKey(secretPassword);
            connectionString = connectionString.Replace("#password#", password);
            return connectionString;
        }
    }
}
