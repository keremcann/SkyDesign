using System;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class GetColumnListResponse
    {
        public int ColumnListId { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string Nullable { get; set; }
        public string Description { get; set; }

        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}