using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using pruebaworkshop.Application.UseCase.V1.PersonOperation.Queries.GetList;
using pruebaworkshop.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using pruebaworkshop.Application.UseCase.V2.PedidoOperation.Queries;
using pruebaworkshop.Application.UseCase.V2.PedidoOperation.Commands;
using System;

namespace WebApi.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PedidoController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<PedidoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPedido()));

    [HttpPost]
    [ProducesResponseType(typeof(CreatePedidoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult>Create (CreatePedidoCommand body )=>Result(await Mediator.Send(body));

}
