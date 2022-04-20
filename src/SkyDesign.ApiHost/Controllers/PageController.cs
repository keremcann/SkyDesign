using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.Page;
using SkyDesign.Application.Contract.Queries.Page;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        IMediator _mediator;
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createPage")]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageCommandRequest request)
        {
            CommonResponse<CreatePageCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updatePage")]
        public async Task<IActionResult> UpdatePage([FromBody] UpdatePageCommandRequest request)
        {
            CommonResponse<UpdatePageCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("deletePage")]
        public async Task<IActionResult> DeleteCatalog([FromQuery] DeletePageCommandRequest request)
        {
            CommonResponse<DeletePageCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllPages")]
        public async Task<IActionResult> GetAllPages([FromQuery] GetPageQueryRequest request)
        {
            CommonResponse<List<GetPageQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getPageDetail")]
        public async Task<IActionResult> GetPageDetail([FromQuery] GetPageDetailQueryRequest request)
        {
            CommonResponse<GetPageDetailQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createPageDetail")]
        public async Task<IActionResult> CreatePageDetail([FromBody] CreatePageDetailCommandRequest request)
        {
            CommonResponse<CreatePageDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("updatePageDetail")]
        public async Task<IActionResult> UpdatePageDetail([FromBody] UpdatePageDetailCommandRequest request)
        {
            CommonResponse<UpdatePageDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("deletePageDetail")]
        public async Task<IActionResult> DeletePageDetail([FromBody] DeletePageDetailCommandRequest request)
        {
            CommonResponse<DeletePageDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
