using System;
using System.Collections.Generic;

namespace PortoApi.Models
{
    public partial class Viagem
    {
        public Viagem()
        {
            ItemViagem = new HashSet<ItemViagem>();
        }

        public int ViagemId { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime? DtPartida { get; set; }
        public DateTime? DtPlanejado { get; set; }
        public DateTime? DtChegada { get; set; }
        public int? NavioId { get; set; }
        public DateTime? DtRecord { get; set; }
        public DateTime? DtUpdate { get; set; }

        public Navio Navio { get; set; }
        public ICollection<ItemViagem> ItemViagem { get; set; }
    }
}
