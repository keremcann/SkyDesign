using System.Collections.Generic;

namespace SkyDesign.Domain.BaseTypes
{
    public class CatalogContent
    {
        public string TableName { get; set; }
        public List<CatalogContentItem> Items { get; set; }
    }

    public class CatalogContentItem
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}