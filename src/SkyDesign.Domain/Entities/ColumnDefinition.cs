using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Entities
{
    public class ColumnDefinition
    {
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }

    }
}