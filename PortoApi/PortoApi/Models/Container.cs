﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PortoApi.Models
{
    public partial class Container
    {
        public Container()
        {
            ItemViagem = new HashSet<ItemViagem>();
        }

        public int ContainerId { get; set; }
        public string Descricao { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }
        public decimal? Capacidade { get; set; }
        public DateTime? DtRecord { get; set; }
        public DateTime? DtUpdate { get; set; }
        public DateTime? DtVencimento { get; set; }
        public short? Tipo { get; set; }

        [JsonIgnore]
        public ICollection<ItemViagem> ItemViagem { get; set; }
    }
}
