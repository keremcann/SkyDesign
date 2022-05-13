using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Domain.Entities
{
    public class ColumnDefinition : IEquatable<ColumnDefinition>
    {
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsInColumn { get; set; } = false;
        public int ColumnListId { get; set; }
        public string HasRelation { get; set; }
        public string Nullable { get; set; }
        public List<RelationalData> RelationalDataList { get; set; } = new List<RelationalData>();
        public object CurrentData { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ColumnDefinition);
        }

        public bool Equals(ColumnDefinition other)
        {
            return other != null && ColumnName == other.ColumnName;
        }

        public static bool operator ==(ColumnDefinition left, ColumnDefinition right)
        {
            return EqualityComparer<ColumnDefinition>.Default.Equals(left, right);
        }

        public static bool operator !=(ColumnDefinition left, ColumnDefinition right)
        {
            return !(left == right);
        }
    }

    public class RelationalData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}