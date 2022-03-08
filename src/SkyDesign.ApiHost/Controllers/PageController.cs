﻿using MediatR;
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
        public async Task<IActionResult> CreatePage([FromQuery] CreatePageCommandRequest request)
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
        public async Task<IActionResult> UpdatePage([FromQuery] UpdatePageCommandRequest request)
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
    }
}