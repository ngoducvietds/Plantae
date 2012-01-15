using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class TRANSACAO : IOwnable
    {
        public TRANSACAO(CONTA conta, CATEGORIA categoria, string nome, DateTime data, decimal valor, string owner)
        {
            CONTA = conta;
            CATEGORIA = categoria;
            Nome = nome;
            Data = data;
            Valor = valor;
            Owner = owner;

            JOURNAL = new JOURNAL(this);
        }

        public void Update()
        {
        }
    }
}
