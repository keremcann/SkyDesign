using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDesign.Domain.CatalogBaseTypes
{
    public class CatalogContentItem
    {
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string PropertyValue { get; set; }
    }
}
