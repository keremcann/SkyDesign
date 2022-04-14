using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Dtos
{
    public class ColumnInfo<TData>
    {
        public List<ColumnDefinition> ColumnList { get; set; }
        public List<TData> Data { get; set; }
    }

    public class ColumnDefinition
    {
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }

    }
}
