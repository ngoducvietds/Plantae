using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class TRANSFERENCIA : IOwnable
    {
        public TRANSFERENCIA(JOURNAL journal, TRANSACAO debito, TRANSACAO credito, string owner) : this()
        {
        }

        public void Update()
        {
        }
    }
}
