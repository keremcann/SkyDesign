using MediatR;
using SkyDesign.Application.Contract.Commands.Test;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommandRequest, UpdateTestCommandResponse>
    {
        public UpdateTestCommandHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpdateTestCommandResponse> Handle(UpdateTestCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.IsActive)
                return await Task.FromResult(new UpdateTestCommandResponse { Success = true, InfoMessage = "Okdir" });
            return await Task.FromResult(new UpdateTestCommandResponse { Success = false, ErrorMessage = "Hata" });
        }
    }
}
