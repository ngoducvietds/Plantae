using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class JOURNAL : IOwnable
    {
        public JOURNAL(int tipo, CONTA contaDebito, CONTA contaCredito, CATEGORIA categoria,
            string nome, DateTime data, decimal valor, string owner, int periodicidade = (int)PLANTAEUTILS.Periodicidade.Unico, 
            int parcelaInicial = 1, int parcelaTotal = 1, bool tempoIndeterminado = false)
        {

        }

        public JOURNAL(TRANSACAO transacao)
        {
            int tipo;

            if (transacao.Valor < 0)
                tipo = (int)PLANTAEUTILS.TipoTransacao.Debito;
            else
                tipo = (int)PLANTAEUTILS.TipoTransacao.Credito;
        }

        public void Update()
        {
        }
    }
}
