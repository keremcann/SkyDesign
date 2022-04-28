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
    public class AddColumnToTableRequestHandler : IRequestHandler<AddColumnToTableRequest, CommonResponse<AddColumnToTableResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepositoryAsync _pageRepositoryAsync;

        public AddColumnToTableRequestHandler(IMapper mapper, IPageRepositoryAsync pageRepositoryAsync)
        {
            _mapper = mapper;
            _pageRepositoryAsync = pageRepositoryAsync;
        }
        public async Task<CommonResponse<AddColumnToTableResponse>> Handle(AddColumnToTableRequest request, CancellationToken cancellationToken)
        {
            var result = await _pageRepositoryAsync.AddColumnToTable(
                pageId: request.PageId,
                columnName: request.ColumnName,
                dataType: request.DataType,
                hasRelationship: request.HasRelation,
                nullable: request.Nullable,
                joinedTableName: request.TableName);

            return await Task.FromResult(new CommonResponse<AddColumnToTableResponse>
            {
                Success = result.Success,
                InfoMessage = result.InfoMessage,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
