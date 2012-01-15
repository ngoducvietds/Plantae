using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface IJOURNAL
    {
        long JournalId { get; set; }
        CONTA ContaDebito { get; set; }
        CONTA ContaCredito { get; set; }
        CATEGORIA Categoria { get; set; }
        string Nome { get; set; }
        DateTime Data { get; set; }
        decimal Valor { get; set; }
        Plantae.Core.PLANTAEUTILS.Periodicidade Periodicidade { get; set; }
        int ParcelaInicial { get; set; }
        int ParcelaTotal { get; set; }
        bool TempoIndeterminado { get; set; }
        DateTime UltimaAtualizacao { get; set; }
    }
}
