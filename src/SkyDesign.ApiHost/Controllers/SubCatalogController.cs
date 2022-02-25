using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.SubCatalog;
using SkyDesign.Application.Contract.Queries.SubCatalog;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCatalogController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public SubCatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createSubCatalog")]
        public async Task<IActionResult> CreateSubCatalog([FromQuery] CreateSubCatalogCommandRequest request)
        {
            CommonResponse<CreateSubCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updateSubCatalog")]
        public async Task<IActionResult> UpdateSubCatalog([FromQuery] UpdateSubCatalogCommandRequest request)
        {
            CommonResponse<UpdateSubCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("deleteSubCatalog")]
        public async Task<IActionResult> DeleteSubCatalog([FromQuery] DeleteSubCatalogCommandRequest request)
        {
            CommonResponse<DeleteSubCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllSubCatalog")]
        public async Task<IActionResult> GetAllSubCatalog([FromQuery] GetSubCatalogQueryRequest request)
        {
            List<GetSubCatalogQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
