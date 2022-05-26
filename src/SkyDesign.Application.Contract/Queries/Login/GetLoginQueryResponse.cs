using SkyDesign.Core.Base;
using System;

namespace SkyDesign.Application.Contract.Queries.Login
{
    [Serializable]
    public class GetLoginQueryResponse : BaseType
    {
        public string Token { get; set; }
        public string FullName { get; set; }
    }
}
