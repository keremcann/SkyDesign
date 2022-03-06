using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.Role;
using SkyDesign.Application.Contract.Queries.Role;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole([FromQuery] CreateRoleCommandRequest request)
        {
            CommonResponse<CreateRoleCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updateRole")]
        public async Task<IActionResult> UpdateRole([FromQuery] UpdateRoleCommandRequest request)
        {
            CommonResponse<UpdateRoleCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("deleteRole")]
        public async Task<IActionResult> DeleteCatalog([FromQuery] DeleteRoleCommandRequest request)
        {
            CommonResponse<DeleteRoleCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllRoles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetRoleQueryRequest request)
        {
            CommonResponse<List<GetRoleQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
