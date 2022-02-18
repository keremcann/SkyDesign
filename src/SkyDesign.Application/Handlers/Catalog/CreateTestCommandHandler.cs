using MediatR;
using SkyDesign.Application.Contract.Commands.Test;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommandRequest, CreateTestCommandResponse>
    {
        public CreateTestCommandHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CreateTestCommandResponse> Handle(CreateTestCommandRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CreateTestCommandResponse() { Id = 3, Value = "Kerem Can" });
        }
    }
}
