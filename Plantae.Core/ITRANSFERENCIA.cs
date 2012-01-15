using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface ITRANSFERENCIA
    {
        public long TransferenciaId { get; set; }
        public JOURNAL Journal { get; set; }
        public TRANSACAO Debito { get; set; }
        public TRANSACAO Credito { get; set; }
    }
}
