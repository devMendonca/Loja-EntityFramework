using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Models
{
    public class Bebida
    {
        public int BebidaId { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}