using AutoMapper;
using MediatR;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Core.Base;
using SkyDesign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkyDesign.Application.Handlers.User
{
    public class GetUserInformationByIdQueryRequestHandler : IRequestHandler<GetUserInformationByIdQueryRequest, CommonResponse<GetUserInformationByIdQueryResponse>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;

        public GetUserInformationByIdQueryRequestHandler(IUserRepositoryAsync userRepositoryAsync,
                                                         IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<CommonResponse<GetUserInformationByIdQueryResponse>> Handle(GetUserInformationByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepositoryAsync.GetUserInformationByIdAsync(request.UserId);

            return await Task.FromResult(new CommonResponse<GetUserInformationByIdQueryResponse>
            {
                ErrorMessage = result.ErrorMessage,
                InfoMessage = result.InfoMessage,
                Success = result.Success,
                Value = _mapper.Map<GetUserInformationByIdQueryResponse>(result.Value)
            });
        }
    }
}
