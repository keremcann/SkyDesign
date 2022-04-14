using System;

namespace SkyDesign.Application.Contract.Queries.Page
{
    [Serializable]
    public class GetPageQueryResponse
    {
        public int PageId { get; set; }
        public int? ParentId { get; set; }
        public bool IsCustom { get; set; }
        public string PageName { get; set; }
        public string PageIcon { get; set; }
        public string PageUrl{ get; set; }
    }
}
