using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.SubCatalog;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalog
{
    public class DeleteSubCatalogCommandHandler : IRequestHandler<DeleteSubCatalogCommandRequest, CommonResponse<DeleteSubCatalogCommandResponse>>
    {
        ISubCatalogRepositoryAsync _subCatalogRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subCatalogRepository"></param>
        /// <param name="mapper"></param>
        public DeleteSubCatalogCommandHandler(ISubCatalogRepositoryAsync subCatalogRepository, IMapper mapper)
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
        public async Task<CommonResponse<DeleteSubCatalogCommandResponse>> Handle(DeleteSubCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CommonResponse<DeleteSubCatalogCommandResponse>();
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
