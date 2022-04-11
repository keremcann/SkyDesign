using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.Diagram;
using SkyDesign.Application.Contract.Queries.Diagram;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public DiagramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createDiagram")]
        public async Task<IActionResult> CreateDiagram([FromQuery] CreateDiagramCommandRequest request)
        {
            CommonResponse<CreateDiagramCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updateDiagram")]
        public async Task<IActionResult> UpdateCatalog([FromQuery] UpdateDiagramCommandRequest request)
        {
            CommonResponse<UpdateDiagramCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("deleteDiagram")]
        public async Task<IActionResult> DeleteCatalog([FromQuery] DeleteDiagramCommandRequest request)
        {
            CommonResponse<DeleteDiagramCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllDiagram")]
        public async Task<IActionResult> GetAllDiagram([FromQuery] GetDiagramQueryRequest request)
        {
            CommonResponse<List<GetDiagramQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllDiagramByPageId")]
        public async Task<IActionResult> getAllDiagramByPageId([FromQuery] GetAllByPageIdQueryRequest request)
        {
            CommonResponse<List<GetAllByPageIdQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
