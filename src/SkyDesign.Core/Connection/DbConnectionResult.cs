using SkyDesign.Core.Base;
using System.Data;

namespace SkyDesign.Core.Connection
{
    public class DbConnectionResult : BaseType
    {
        public IDbConnection db { get; set; }
    }
}
