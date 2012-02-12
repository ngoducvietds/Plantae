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
        public CONTA(string nome, DateTime dataInicial, decimal saldoInicial, string owner) : this()
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
        public decimal SaldoAtual
        {
            get
            {
                return GetSaldoEm(DateTime.Now);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public decimal GetSaldoEm(DateTime data)
        {
            decimal saldo = 0;

            saldo = this.TRANSACOES.Where(t => t.Data <= data && t.ContaID == this.ContaID).Sum(t => (decimal?)t.Valor) ?? 0.0M;

            return saldo;
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

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
