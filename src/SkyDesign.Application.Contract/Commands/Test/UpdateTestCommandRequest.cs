using MediatR;

namespace SkyDesign.Application.Contract.Commands.Test
{
    public class UpdateTestCommandRequest : IRequest<UpdateTestCommandResponse>
    {
        public bool IsActive { get; set; }
    }
}
