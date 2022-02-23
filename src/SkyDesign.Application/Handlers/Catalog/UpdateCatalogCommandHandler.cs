﻿using MediatR;
using SkyDesign.Application.Contract.Commands.Catalog;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Catalog
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommandRequest, UpdateCatalogCommandResponse>
    {
        ICatalogRepositoryAsync _catalogRepository;

        public UpdateCatalogCommandHandler(ICatalogRepositoryAsync catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpdateCatalogCommandResponse> Handle(UpdateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCatalogCommandResponse();
            var req = new Domain.Entities.Catalog
            {
                CatalogId = request.CatalogId,
                CatalogName = request.CatalogName,
                UpdateUser = "krmcn"
            };
            var catalogs = _catalogRepository.UpdateAsync(req);

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
