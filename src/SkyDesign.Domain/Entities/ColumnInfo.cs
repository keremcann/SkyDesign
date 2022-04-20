using System.Collections.Generic;

namespace SkyDesign.Domain.Entities
{
    public class ColumnInfo<TData>
    {
        public IEnumerable<ColumnDefinition> ColumnList { get; set; }
        public IEnumerable<TData> Data { get; set; }
    }
}