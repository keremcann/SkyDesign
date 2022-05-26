namespace SkyDesign.Application.Contract.Queries.Page
{
    public class GetAllColumnListByPageIdResponse
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsInColumn { get; set; }
        public int ColumnListId { get; set; }
        public string HasRelation { get; set; }
        public string Nullable { get; set; }
        public string TableName { get; set; }
    }
}
