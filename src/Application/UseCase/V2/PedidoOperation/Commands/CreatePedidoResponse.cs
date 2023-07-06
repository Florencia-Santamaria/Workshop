using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaworkshop.Application.UseCase.V2.PedidoOperation.Commands
{
    public record struct CreatePedidoResponse(Guid id, string mensaje)
    {
    }
}
