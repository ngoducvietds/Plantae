using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Plantae.Core;

namespace Plantae.Web.Models
{
    public class ContaModel
    {
        public ContaModel(CONTA conta)
        {
            ContaId = conta.ContaID;
            Nome = conta.Nome;
            DataInicial = conta.DataInicial;
            SaldoInicial = conta.SaldoInicial;
        }

        public ContaModel()
        {
        }

        [Key, ScaffoldColumn(false)]
        public long ContaId { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public DateTime DataInicial { get; set; }

        [Required]
        public decimal SaldoInicial { get; set; }
    }
}