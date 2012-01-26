using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ICONTA
    {
        long ContaID { get; set; }
        string Nome { get; set; }
        DateTime DataInicial { get; set; }
        decimal SaldoInicial { get; set; }
    }
}
