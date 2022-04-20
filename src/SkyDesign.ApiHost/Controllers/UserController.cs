using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.User;
using SkyDesign.Core.Base;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateRole([FromBody] CreateUserCommandRequest request)
        {
            CommonResponse<CreateUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPatch("updateUser")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateUserCommandRequest request)
        {
            CommonResponse<UpdateUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteCatalog([FromQuery] DeleteUserCommandRequest request)
        {
            CommonResponse<DeleteUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
