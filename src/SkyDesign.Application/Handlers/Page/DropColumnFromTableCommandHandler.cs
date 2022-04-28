using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.Page
{
    public class DropColumnFromTableCommandHandler : IRequestHandler<DropColumnFromTableRequest, CommonResponse<DropColumnFromTableResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepositoryAsync _pageRepositoryAsync;

        public DropColumnFromTableCommandHandler(IMapper mapper, IPageRepositoryAsync pageRepositoryAsync)
        {
            _mapper = mapper;
            _pageRepositoryAsync = pageRepositoryAsync;
        }
        public async Task<CommonResponse<DropColumnFromTableResponse>> Handle(DropColumnFromTableRequest request, CancellationToken cancellationToken)
        {
            var result = await _pageRepositoryAsync.DropColumnFromTable(
                pageId: request.PageId,
                columnName: request.ColumnName,
                hasRelationship: request.HasRelation,
                joinedTableName: request.TableName

                );

            return await Task.FromResult(new CommonResponse<DropColumnFromTableResponse>
            {
                ErrorMessage = result.ErrorMessage,
                InfoMessage = result.InfoMessage,
                Success = result.Success
            });
        }
    }
}
