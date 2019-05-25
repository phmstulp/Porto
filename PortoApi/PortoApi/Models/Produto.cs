using System;
using System.Collections.Generic;

namespace PortoApi.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ItemViagem = new HashSet<ItemViagem>();
        }

        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public DateTime? DtRecord { get; set; }
        public DateTime? DtUpdate { get; set; }

        public ICollection<ItemViagem> ItemViagem { get; set; }
    }
}
