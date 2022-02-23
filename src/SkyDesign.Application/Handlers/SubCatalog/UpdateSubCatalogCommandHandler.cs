using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.SubCatalog;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalog
{
    public class UpdateSubCatalogCommandHandler : IRequestHandler<UpdateSubCatalogCommandRequest, UpdateSubCatalogCommandResponse>
    {
        ISubCatalogRepositoryAsync _subCatalogRepository;
        IMapper _mapper;

        public UpdateSubCatalogCommandHandler(ISubCatalogRepositoryAsync subCatalogRepository, IMapper mapper)
        {
            _subCatalogRepository = subCatalogRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpdateSubCatalogCommandResponse> Handle(UpdateSubCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateSubCatalogCommandResponse();
            var req = _mapper.Map<Domain.Entities.SubCatalog>(request);
            var catalogs = _subCatalogRepository.AddAsync(req);

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
