using MediatR;
using SkyDesign.Application.Contract.Commands.Catalog;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommandRequest, CommonResponse<CreateCatalogCommandResponse>>
    {
        ICatalogRepositoryAsync _catalogRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogRepository"></param>
        public CreateCatalogCommandHandler(ICatalogRepositoryAsync catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<CreateCatalogCommandResponse>> Handle(CreateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<CreateCatalogCommandResponse>();
            var req = new Domain.Entities.Catalog
            {
                CatalogName = request.CatalogName,
                CreateUser = "krmcn"
            };
            var catalogs = _catalogRepository.AddAsync(req);

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
