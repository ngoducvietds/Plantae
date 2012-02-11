using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plantae.Core;
using System.ComponentModel.DataAnnotations;

namespace Plantae.Web.Models
{
    public class JournalModel : IJOURNAL
    {
        [Key, ScaffoldColumn(false)]
        public long JournalID { get; set; }

        [Display(Name = "Conta de débito")]
        public CONTA CONTADEBITO { get; set; }

        public long? ContaDebitoID { get; set; }

        [Display(Name = "Conta de crédito")]
        public CONTA CONTACREDITO { get; set; }

        public long? ContaCreditoID { get; set; }

        [Required, Display(Name = "Categoria")]
        public CATEGORIA CATEGORIA { get; set; }

        public long CategoriaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int Periodicidade { get; set; }

        [ScaffoldColumn(false)]
        public int TipoTransacao { get; set; }

        [Required, Display(Name = "Parcela inicial")]
        public int ParcelaInicial { get; set; }

        [Required, Display(Name = "Total de parcelas")]
        public int ParcelaTotal { get; set; }

        [Required, Display(Name = "Tempo indeterminado")]
        public bool TempoIndeterminado { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UltimaAtualizacao { get; set; }
    }
}