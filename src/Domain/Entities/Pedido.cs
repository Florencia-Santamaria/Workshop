using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaworkshop.Domain.Entities
{
    public class Pedido
    {
        public Guid id { get; set; }
        public int numeroDePedido { get; set; }
        public string cicloDelPedido { get; set; }
        public Int64 codigoDeContratoInterno { get; set; }
        public int estadoDelPedido { get; set; }
        public int cuentaCorriente { get; set; }
        public DateTime cuando { get; set; }

    }
}
