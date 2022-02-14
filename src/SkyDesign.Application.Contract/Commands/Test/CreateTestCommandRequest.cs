using MediatR;

namespace SkyDesign.Application.Contract.Commands.Test
{
    public class CreateTestCommandRequest : IRequest<CreateTestCommandResponse>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
