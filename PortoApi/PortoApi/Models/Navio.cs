using System;
using System.Collections.Generic;

namespace PortoApi.Models
{
    public partial class Navio
    {
        public Navio()
        {
            Viagem = new HashSet<Viagem>();
        }

        public int NavioId { get; set; }
        public string Descricao { get; set; }
        public int? Capacidade { get; set; }
        public DateTime? DtRecord { get; set; }
        public DateTime? DtUpdate { get; set; }

        public ICollection<Viagem> Viagem { get; set; }
    }
}
