using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.SubCatalogDetail;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalogDetail
{
    public class DeleteSubCatalogDetailCommandHandler : IRequestHandler<DeleteSubCatalogDetailCommandRequest, DeleteSubCatalogDetailCommandResponse>
    {
        ISubCatalogDetailRepositoryAsync _subCatalogDetailRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subCatalogDetailRepository"></param>
        /// <param name="mapper"></param>
        public DeleteSubCatalogDetailCommandHandler(ISubCatalogDetailRepositoryAsync subCatalogDetailRepository, IMapper mapper)
        {
            _subCatalogDetailRepository = subCatalogDetailRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeleteSubCatalogDetailCommandResponse> Handle(DeleteSubCatalogDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteSubCatalogDetailCommandResponse();
            var req = _mapper.Map<Domain.Entities.SubCatalogDetail>(request);
            var catalogs = _subCatalogDetailRepository.AddAsync(req);

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
