using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class JOURNAL : IJOURNAL, IOwnable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="contaDebito"></param>
        /// <param name="contaCredito"></param>
        /// <param name="categoria"></param>
        /// <param name="nome"></param>
        /// <param name="data"></param>
        /// <param name="valor"></param>
        /// <param name="owner"></param>
        /// <param name="periodicidade"></param>
        /// <param name="parcelaInicial"></param>
        /// <param name="parcelaTotal"></param>
        /// <param name="tempoIndeterminado"></param>
        public JOURNAL(int tipo, CONTA contaDebito, CONTA contaCredito, CATEGORIA categoria,
            string nome, DateTime data, decimal valor, string owner, int periodicidade = (int)PLANTAEUTILS.Periodicidade.Unico, 
            int parcelaInicial = 1, int parcelaTotal = 1, bool tempoIndeterminado = false)
        {
            TipoTransacao = tipo;
            CONTADEBITO = contaDebito;
            CONTACREDITO = contaCredito;
            CATEGORIA = categoria;
            Nome = nome;
            Data = data;
            Valor = valor;
            Owner = owner;
            Periodicidade = periodicidade;
            ParcelaInicial = parcelaInicial;
            ParcelaTotal = ParcelaTotal;
            TempoIndeterminado = tempoIndeterminado;
        }


        public JOURNAL(IJOURNAL journal, string owner) : this(journal.TipoTransacao, journal.CONTADEBITO, journal.CONTACREDITO, journal.CATEGORIA,
            journal.Nome, journal.Data, journal.Valor, owner, journal.Periodicidade, journal.ParcelaInicial, journal.ParcelaTotal, journal.TempoIndeterminado)
        {
        }

        public JOURNAL(TRANSACAO transacao, string owner)
        {
            int tipoTransacao = 0;
            CONTA contaDebito = null;
            CONTA contaCredito = null;

            if (transacao.Valor > 0)
            {
                tipoTransacao = (int)PLANTAEUTILS.TipoTransacao.Credito;
                contaCredito = transacao.CONTA;
            }
            if (transacao.Valor < 0)
            {
                tipoTransacao = (int)PLANTAEUTILS.TipoTransacao.Debito;
                contaDebito = transacao.CONTA;
            }

            TipoTransacao = tipoTransacao;
            CONTADEBITO = contaDebito;
            CONTACREDITO = contaCredito;
            CATEGORIA = transacao.CATEGORIA;
            Nome = transacao.Nome;
            Data = transacao.Data;
            Valor = transacao.Valor;
            Owner = owner;
            Periodicidade = (int)PLANTAEUTILS.Periodicidade.Unico;
            ParcelaInicial = 1;
            ParcelaTotal = 1;
            TempoIndeterminado = false;


        }

        public void Update(int tipo, CONTA contaDebito, CONTA contaCredito, CATEGORIA categoria,
            string nome, DateTime data, decimal valor, string owner)
        {
            TipoTransacao = tipo;
            CONTADEBITO = contaDebito;
            CONTACREDITO = contaCredito;
            CATEGORIA = categoria;
            Nome = nome;
            Data = data;
            Valor = valor;
            Owner = owner;
        }
    }
}
