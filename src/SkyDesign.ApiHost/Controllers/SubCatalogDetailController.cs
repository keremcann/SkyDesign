using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.SubCatalogDetail;
using SkyDesign.Application.Contract.Queries.SubCatalogDetail;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCatalogDetailController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public SubCatalogDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createSubCatalogDetail")]
        public async Task<IActionResult> CreateSubCatalogDetail([FromBody] CreateSubCatalogDetailCommandRequest request)
        {
            CommonResponse<CreateSubCatalogDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updateSubCatalogDetail")]
        public async Task<IActionResult> UpdateSubCatalogDetail([FromBody] UpdateSubCatalogDetailCommandRequest request)
        {
            CommonResponse<UpdateSubCatalogDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("deleteSubCatalogDetail")]
        public async Task<IActionResult> DeleteSubCatalogDetail([FromQuery] DeleteSubCatalogDetailCommandRequest request)
        {
            CommonResponse<DeleteSubCatalogDetailCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllSubCatalogDetail")]
        public async Task<IActionResult> GetAllSubCatalogDetail([FromQuery] GetSubCatalogDetailQueryRequest request)
        {
            CommonResponse<List<GetSubCatalogDetailQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllSubCatalogDetailBySubCatalogId")]
        public async Task<IActionResult> GetAllSubCatalogDetailBySubCatalogId([FromQuery] GetSubCatalogDetailBySubCatalogIdQueryRequest request)
        {
            CommonResponse<List<GetSubCatalogDetailBySubCatalogIdQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
