using SkyDesign.Core.Configuration;
using SkyDesign.Core.Cryptography;
using System.Data;
using System.Data.SqlClient;

namespace SkyDesign.Core.Connection
{
    public abstract class DbConnection
    {
        public IDbConnection db;

        /// <summary>
        /// 
        /// </summary>
        public DbConnection()
        {
            db = OpenConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IDbConnection OpenConnection()
        {
            IDbConnection _db = new SqlConnection(EditConnectionString(AppSettings.GetConnectionString()));
            _db.Open();
            return _db;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            if (db.State == ConnectionState.Open)
            {
                db.Close();
            }
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
            string password = Encryption.EncryptWithDefaultKey(secretPassword);
            connectionString = connectionString.Replace("#password#", password);
            return connectionString;
        }
    }
}
