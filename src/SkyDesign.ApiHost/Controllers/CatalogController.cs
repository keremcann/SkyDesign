using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.Catalog;
using SkyDesign.Application.Contract.Queries.Catalog;
using SkyDesign.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("createCatalog")]
        public async Task<IActionResult> CreateCatalog([FromQuery] CreateCatalogCommandRequest request)
        {
            CommonResponse<CreateCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("updateCatalog")]
        public async Task<IActionResult> UpdateCatalog([FromQuery] UpdateCatalogCommandRequest request)
        {
            CommonResponse<UpdateCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("deleteCatalog")]
        public async Task<IActionResult> DeleteCatalog([FromQuery] DeleteCatalogCommandRequest request)
        {
            CommonResponse<DeleteCatalogCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getAllCatalog")]
        public async Task<IActionResult> GetAllCatalog([FromQuery] GetCatalogQueryRequest request)
        {
            CommonResponse<List<GetCatalogQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
