using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plantae.Core;

namespace Plantae.Web.Models
{
    public class JournalModel : IJOURNAL
    {
        public int TipoTransacao { get; set; }
        public long JournalID { get; set; }
        public CONTA CONTADEBITO { get; set; }
        public CONTA CONTACREDITO { get; set; }
        public CATEGORIA CATEGORIA { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int Periodicidade { get; set; }
        public int ParcelaInicial { get; set; }
        public int ParcelaTotal { get; set; }
        public bool TempoIndeterminado { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}