using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ITRANSFERENCIA
    {
        long TransferenciaId { get; set; }
        JOURNAL Journal { get; set; }
        TRANSACAO Debito { get; set; }
        TRANSACAO Credito { get; set; }
    }
}
