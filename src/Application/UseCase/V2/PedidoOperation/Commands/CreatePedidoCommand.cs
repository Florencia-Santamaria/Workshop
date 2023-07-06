using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using MediatR;
using pruebaworkshop.Domain.Entities;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pruebaworkshop.Application.UseCase.V2.PedidoOperation.Commands
{
    public class CreatePedidoCommand : IRequest<Response<CreatePedidoResponse>>
    {
        public int cuentaCorriente { get; set; }
        public Int64 codigoDeContratoInterno { get; set; }
    }

    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>> {

        private readonly ITransactionalRepository _repository;
        private readonly Andreani.ARQ.AMQStreams.Interface.IPublisher _publish;
        
        public CreatePedidoCommandHandler(ITransactionalRepository repository, Andreani.ARQ.AMQStreams.Interface.IPublisher publish)
        {
            _repository = repository;
            _publish = publish;
        }

        public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken) {
            
            var pedido = new Domain.Entities.Pedido()
            {
                id = Guid.NewGuid(),
                numeroDePedido = 0,
                codigoDeContratoInterno = request.codigoDeContratoInterno,
                estadoDelPedido = 1,
                cuentaCorriente = request.cuentaCorriente,
                cuando = DateTime.Now
            };

            pedido.cicloDelPedido = pedido.id.ToString();
            _repository.Insert(pedido);
            await _repository.SaveChangeAsync();

            var evento = new Andreani.Scheme.Onboarding.Pedido();
            evento.id = pedido.id.ToString();
            evento.numeroDePedido = pedido.numeroDePedido;
            evento.cicloDelPedido = pedido.cicloDelPedido;
            evento.codigoDeContratoInterno = pedido.codigoDeContratoInterno;
            evento.estadoDelPedido = pedido.estadoDelPedido.ToString();
            evento.cuentaCorriente=pedido.cuentaCorriente;
            evento.cuando = pedido.cuando.ToString();

            await _publish.To<Andreani.Scheme.Onboarding.Pedido>(evento, pedido.id.ToString(), "PedidoCreadoWorkshop");

            return new Response<CreatePedidoResponse>
            {
                Content = new CreatePedidoResponse()
                {
                    mensaje = "Success",
                    id = pedido.id,
                },
                StatusCode=System.Net.HttpStatusCode.OK
            };
        }
    }
}
