using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loja.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public string NomeLanche { get; set; }
        public string acompanhamento { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}