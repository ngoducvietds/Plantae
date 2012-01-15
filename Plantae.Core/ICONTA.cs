using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ICONTA
    {
        public long ContaId { get; set; }
        public String Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public decimal SaldoInicial { get; set; }
    }
}
