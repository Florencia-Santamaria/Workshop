using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using MediatR;
using pruebaworkshop.Domain.Dtos;
using pruebaworkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pruebaworkshop.Application.UseCase.V2.PedidoOperation.Queries
{
    public record struct ListPedido : IRequest<Response<List<PedidoDto>>>
    {
    }

    public class ListPedidoHandler : IRequestHandler<ListPedido, Response<List<PedidoDto>>>
    {
        private readonly IReadOnlyQuery _query;

        public ListPedidoHandler(IReadOnlyQuery query)
        {
            _query = query;
        }

        public async Task<Response<List<PedidoDto>>> Handle(ListPedido request, CancellationToken cancellationToken)
        {
            var result = await _query.GetAllAsync<PedidoDto>(nameof(Pedido));

            return new Response<List<PedidoDto>>
            {
                Content = result.ToList(),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }

}
