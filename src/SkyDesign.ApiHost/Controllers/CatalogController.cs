using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyDesign.Application.Contract.Commands.Catalog;
using System.Threading.Tasks;

namespace SkyDesign.ApiHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        IMediator _mediator;

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
            CreateCatalogCommandResponse response = await _mediator.Send(request);
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
            UpdateCatalogCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
