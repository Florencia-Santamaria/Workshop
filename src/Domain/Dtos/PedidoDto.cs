using pruebaworkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaworkshop.Domain.Dtos
{
    public record struct PedidoDto
   (
        Guid id,
        Int64 numeroDePedido ,
        string cicloDelPedido ,
        Int64 codigoDeContratoInterno ,
        int estadoDelPedido ,
        Int64 cuentaCorriente ,
        DateTime cuando
    )
    { }
}
