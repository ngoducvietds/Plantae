using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface IJOURNAL
    {
        long JournalID { get; set; }
        CONTA CONTADEBITO { get; set; }
        long? ContaDebitoID { get; set; }
        CONTA CONTACREDITO { get; set; }
        long? ContaCreditoID { get; set; }
        CATEGORIA CATEGORIA { get; set; }
        long CategoriaID { get; set; }
        string Nome { get; set; }
        DateTime Data { get; set; }
        decimal Valor { get; set; }
        int Periodicidade { get; set; }
        int TipoTransacao { get; set; }
        int ParcelaInicial { get; set; }
        int ParcelaTotal { get; set; }
        bool TempoIndeterminado { get; set; }
        DateTime UltimaAtualizacao { get; set; }
    }
}
