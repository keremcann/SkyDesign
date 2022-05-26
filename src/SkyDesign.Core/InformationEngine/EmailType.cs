using Microsoft.AspNetCore.Http;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;

namespace SkyDesign.Core.InformationEngine
{
    [Serializable]
    public class EmailType : BaseType
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
