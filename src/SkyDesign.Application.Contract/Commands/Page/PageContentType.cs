using System;

namespace SkyDesign.Application.Contract.Commands.Page
{
    [Serializable]
    public class PageContentType
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}
