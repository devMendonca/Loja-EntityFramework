using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int NumeroPedido { get; set; }
        public string DescricaoPedido { get; set; }
        public double ValorTotalPedido { get; set; }
        public string NomeCliente { get; set; }
        public Lanche Lanches {get; set;}
        public Bebida Bebidas { get; set;}
    }
}