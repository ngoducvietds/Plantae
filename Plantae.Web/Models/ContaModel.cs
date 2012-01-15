using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Plantae.Core;

namespace Plantae.Web.Models
{
    public class ContaModel : ICONTA
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

        [Required, Display(Name="nome da conta")]
        public String Nome { get; set; }

        [Required, Display(Name="data inicial")]
        public DateTime DataInicial { get; set; }

        [Required, Display(Name="saldo inicial")]
        public decimal SaldoInicial { get; set; }
    }
}