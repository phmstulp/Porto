using System;
using System.Collections.Generic;

namespace PortoApi.Models
{
    public partial class ItemViagem
    {
        public int ItemViagemId { get; set; }
        public int? ViagemId { get; set; }
        public int? ContainerId { get; set; }
        public int? ProdutoId { get; set; }
        public decimal? Carga { get; set; }
        public DateTime? DtRecord { get; set; }
        public DateTime? DtUpdate { get; set; }

        public Container Container { get; set; }
        public Produto Produto { get; set; }
        public Viagem Viagem { get; set; }
    }
}
