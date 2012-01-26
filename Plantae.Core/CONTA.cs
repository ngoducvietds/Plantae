using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class CONTA : ICONTA, IOwnable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="dataInicial"></param>
        /// <param name="saldoInicial"></param>
        /// <param name="owner"></param>
        public CONTA(string nome, DateTime dataInicial, decimal saldoInicial, string owner) : base()
        {
            Nome = nome;
            DataInicial = dataInicial;
            SaldoInicial = saldoInicial;
            Owner = owner;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="owner"></param>
        public CONTA(ICONTA conta, string owner) : this(conta.Nome, conta.DataInicial, conta.SaldoInicial, owner)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="dataInicial"></param>
        /// <param name="saldoInicial"></param>
        public void Update(string nome, DateTime dataInicial, decimal saldoInicial)
        {
            Nome = nome;
            DataInicial = dataInicial;
            SaldoInicial = saldoInicial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conta"></param>
        public void Update(ICONTA conta)
        {
            Update(conta.Nome, conta.DataInicial, conta.SaldoInicial);
        }
    }
}
