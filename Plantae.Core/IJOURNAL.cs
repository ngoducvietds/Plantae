using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface IJOURNAL
    {
        public long JournalId { get; set; }
        public CONTA ContaDebito { get; set; }
        public CONTA ContaCredito { get; set; }
        public CATEGORIA Categoria { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Plantae.Core.PLANTAEUTILS.Periodicidade Periodicidade { get; set; }
        public int ParcelaInicial { get; set; }
        public int ParcelaTotal { get; set; }
        public bool TempoIndeterminado { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
