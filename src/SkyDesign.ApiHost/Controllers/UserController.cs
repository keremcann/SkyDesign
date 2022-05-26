using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.User;
using SkyDesign.Application.Contract.Queries.Login;
using SkyDesign.Core.Base;
using System.Collections.Generic;
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
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            List<GetUserQueryResponse> response = await _mediator.Send(new GetUserQueryRequest());
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getUserInformationById")]
        public async Task<IActionResult> GetUserInformationById([FromQuery] GetUserInformationByIdQueryRequest request)
        {
            CommonResponse<GetUserInformationByIdQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
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
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
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
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommandRequest request)
        {
            CommonResponse<DeleteUserCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
