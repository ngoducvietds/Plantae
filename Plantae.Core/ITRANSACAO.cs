using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ITRANSACAO
    {
        public long TransacaoId { get; set; }
        public JOURNAL Journal { get; set; }
        public CONTA Conta { get; set; }
        public CATEGORIA Categoria { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
