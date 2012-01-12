using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class CONTA : IOwnable
    {
        public CONTA(string nome, DateTime dataInicial, decimal saldoInicial, string owner) : base()
        {
            Nome = nome;
            DataInicial = dataInicial;
            SaldoInicial = saldoInicial;
            Owner = owner;
        }

        public void Update(string nome, DateTime dataInicial, decimal saldoInicial)
        {
            Nome = nome;
            DataInicial = dataInicial;
            SaldoInicial = saldoInicial;
        }
    }
}
