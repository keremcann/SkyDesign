using MediatR;
using SkyDesign.Application.Contract.Commands.Catalog;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommandRequest, DeleteCatalogCommandResponse>
    {
        ICatalogRepositoryAsync _catalogRepository;

        public DeleteCatalogCommandHandler(ICatalogRepositoryAsync catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeleteCatalogCommandResponse> Handle(DeleteCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCatalogCommandResponse();
            var req = new Domain.Entities.Catalog
            {
                CatalogId = request.CatalogId,
                DeleteUser = "krmcn"
            };
            var catalogs = _catalogRepository.DeleteAsync(req);

            if (!catalogs.Result.Success)
            {
                response.Success = catalogs.Result.Success;
                response.ErrorMessage = catalogs.Result.ErrorMessage;
                return await Task.FromResult(response);
            }

            response.Success = catalogs.Result.Success;
            response.InfoMessage = catalogs.Result.InfoMessage;
            return await Task.FromResult(response);
        }
    }
}
