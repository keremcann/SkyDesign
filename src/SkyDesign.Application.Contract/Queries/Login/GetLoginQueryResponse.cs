using SkyDesign.Core.Base;

namespace SkyDesign.Application.Contract.Queries.Login
{
    public class GetLoginQueryResponse : BaseType
    {
        public string Token { get; set; }
    }
}
