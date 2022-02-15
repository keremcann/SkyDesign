using System.Threading.Tasks;

namespace SkyDesign.Core.Auth
{
    public interface IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AuthenticationType> Authenticate(string username, string password);
    }
}
