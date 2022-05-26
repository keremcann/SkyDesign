using System;

namespace SkyDesign.Application.Contract.Queries.Catalog
{
    [Serializable]
    public class GetCatalogQueryResponse //: BaseType
    {
        public string CatalogName { get; set; }
        public int CatalogId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
    }
}
