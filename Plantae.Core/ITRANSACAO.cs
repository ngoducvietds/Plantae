using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ITRANSACAO
    {
        long TransacaoId { get; set; }
        JOURNAL Journal { get; set; }
        CONTA Conta { get; set; }
        CATEGORIA Categoria { get; set; }
        string Nome { get; set; }
        DateTime Data { get; set; }
        decimal Valor { get; set; }
    }
}
