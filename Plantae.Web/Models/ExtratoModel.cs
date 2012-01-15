using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plantae.Core;

namespace Plantae.Web.Models
{
    public class ExtratoModel
    {
        public DateTime Data { get; set; }
        public CONTA Conta { get; set; }
        public CATEGORIA Categoria { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}