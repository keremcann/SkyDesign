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
        [HttpPut("updatePageDetail")]
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
        [HttpDelete("deletePageDetail")]
        public async Task<IActionResult> DeletePageDetail([FromQuery] DeletePageDetailCommandRequest request)
        {
            CommonResponse<DeletePageDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getColumnList")]
        public async Task<IActionResult> GetColumnList([FromQuery] GetColumnListRequest request)
        {
            CommonResponse<List<GetColumnListResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createColumnList")]
        public async Task<IActionResult> CreateColumnList([FromBody] CreateColumnListRequest request)
        {
            CommonResponse<CreateColumnListResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("updateColumnList")]
        public async Task<IActionResult> UpdateColumnList([FromBody] UpdateColumnListRequest request)
        {
            CommonResponse<UpdateColumnListResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("deleteColumnList")]
        public async Task<IActionResult> DeleteColumnList([FromBody] DeleteColumnListRequest request)
        {
            CommonResponse<DeleteColumnListResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        // TODO: 1. kısım
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("defineColumnToTable")]
        public async Task<IActionResult> DefineColumnToTable([FromBody] CreateColumnListRequest request)
        {
            CommonResponse<CreateColumnListResponse> response = await _mediator.Send(request);
            return Ok(response);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getAllColumnListByPageId")]
        public async Task<IActionResult> GetAllColumnListByPageId([FromQuery] GetAllColumnListByPageIdRequest request)
        {
            CommonResponse<List<GetAllColumnListByPageIdResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("addColumnToTable")]
        public async Task<IActionResult> AddColumnToTable([FromBody] AddColumnToTableRequest request)
        {
            CommonResponse<AddColumnToTableResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("dropColumnFromTable")]
        public async Task<IActionResult> DropColumnFromTable([FromBody] DropColumnFromTableRequest request)
        {
            CommonResponse<DropColumnFromTableResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
