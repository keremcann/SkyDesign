using System.Collections.Generic;

namespace SkyDesign.Domain.CatalogBaseTypes
{
    public class CatalogContent
    {
        public string TableName { get; set; }
        public List<CatalogContentItem> Items { get; set; }
    }
}
