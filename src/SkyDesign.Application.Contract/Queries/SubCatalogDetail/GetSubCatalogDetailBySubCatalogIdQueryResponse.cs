using System;

namespace SkyDesign.Application.Contract.Queries.SubCatalogDetail
{
    [Serializable]
    public class GetSubCatalogDetailBySubCatalogIdQueryResponse
    {
        public int SubCatalogDetailId { get; set; }
        public int SubCatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}