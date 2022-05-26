using MediatR;
using SkyDesign.Core.Base;

namespace SkyDesign.Application.Contract.Queries.Page
{
    public class GetAddOrUpdateModalDetailPageRequest : IRequest<CommonResponse<GetAddOrUpdateModalDetailPageResponse>>
    {
        public string Level1Menu { get; set; }
        public string Level2Menu { get; set; }
        public string Level3Menu { get; set; }

        public int? Id { get; set; }
    }
}