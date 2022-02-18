using SkyDesign.Core.Base;
using System;
using System.Data;

namespace SkyDesign.Core.Connection
{
    [Serializable]
    public class DbConnectionResult : BaseType
    {
        public IDbConnection db { get; set; }
    }
}
