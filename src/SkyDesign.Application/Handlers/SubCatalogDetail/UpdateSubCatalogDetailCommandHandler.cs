﻿using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Commands.SubCatalogDetail;
using SkyDesign.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.SubCatalogDetail
{
    public class UpdateSubCatalogDetailCommandHandler : IRequestHandler<UpdateSubCatalogDetailCommandRequest, UpdateSubCatalogDetailCommandResponse>
    {
        ISubCatalogDetailRepositoryAsync _subCatalogDetailRepository;
        IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subCatalogDetailRepository"></param>
        /// <param name="mapper"></param>
        public UpdateSubCatalogDetailCommandHandler(ISubCatalogDetailRepositoryAsync subCatalogDetailRepository, IMapper mapper)
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
        public async Task<UpdateSubCatalogDetailCommandResponse> Handle(UpdateSubCatalogDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateSubCatalogDetailCommandResponse();
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
