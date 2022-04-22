using MediatR;
using SkyDesign.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Application.Contract.Queries.Login
{
    public class GetUserInformationByIdQueryRequest : IRequest<CommonResponse<GetUserInformationByIdQueryResponse>>
    {
        public int UserId { get; set; }
    }

    public class GetUserInformationByIdQueryResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CreateUser { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public List<GetUserInformationByIdQueryResponse_Role> Roles { get; set; }
    }

    public class GetUserInformationByIdQueryResponse_Role
    {
        public int RoleId { get; set; }
    }
}