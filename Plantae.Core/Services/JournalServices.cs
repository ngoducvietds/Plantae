using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core.Services
{
    public class JournalServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journal"></param>
        /// <param name="dataLimite"></param>
        public void GerarTransacoes(JOURNAL journal, DateTime dataLimite)
        {
            DateTime dataUltimaAtualizacao = journal.UltimaAtualizacao;


            if (journal.TempoIndeterminado)
            {
                if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Transferencia)
                    GerarTransacoesTransferencia(journal, dataUltimaAtualizacao, dataLimite);
                else
                    GerarTransacoesCreditoDebito(journal, dataUltimaAtualizacao, dataLimite);
            }
            else
            {
                if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Transferencia)
                    GerarParceladoTransferencia(journal);
                else
                    GerarParceladoCreditoDebito(journal);
            }
        }

        /// <summary>
        /// Gera transações de débito e crédito para um Journal do tipo Transferência, 
        /// bem como os objetos de transferência relacionados à essas transações.
        /// </summary>
        /// <param name="journal">Objeto Journal onde as parcelas serão geradas.</param>
        public void GerarParceladoTransferencia(JOURNAL journal)
        {
            DateTime data = journal.Data;

            for (int parcela = 1; parcela <= journal.ParcelaTotal; parcela++)
            {
                // Transação de débito
                TRANSACAO transacao_debito = new TRANSACAO()
                {
                    JOURNAL = journal,
                    CONTA = journal.CONTADEBITO,
                    CATEGORIA = journal.CATEGORIA,
                    Nome = journal.Nome,
                    Data = data,
                    Valor = journal.Valor * -1,
                    NumParcela = parcela
                };

                // Transação de crédito
                TRANSACAO transacao_credito = new TRANSACAO()
                {
                    JOURNAL = journal,
                    CONTA = journal.CONTACREDITO,
                    CATEGORIA = journal.CATEGORIA,
                    Nome = journal.Nome,
                    Data = data,
                    Valor = journal.Valor,
                    NumParcela = parcela
                };

                // Objeto de transferência
                TRANSFERENCIA transferencia = new TRANSFERENCIA()
                {
                    JOURNAL = journal,
                    DEBITO = transacao_debito,
                    CREDITO = transacao_credito
                };

                // Incrementa a data
                data += GetTimeSpan(journal);
            }
        }

        /// <summary>
        /// Gera transações de débito ou crédito para um Journal do tipo com um destes tipos de transação, 
        /// bem como os objetos de transferência relacionados à essas transações.
        /// </summary>
        /// <param name="journal">Objeto Journal onde as parcelas serão geradas.</param>
        public void GerarParceladoCreditoDebito(JOURNAL journal)
        {
            CONTA conta = GetConta(journal);
            DateTime data = journal.Data;

            for (int parcela = 1; parcela <= journal.ParcelaTotal; parcela++)
            {
                TRANSACAO transacao = new TRANSACAO()
                {
                    JOURNAL = journal,
                    CONTA = conta,
                    CATEGORIA = journal.CATEGORIA,
                    Nome = journal.Nome,
                    Data = data,
                    Valor = journal.Valor,
                    NumParcela = parcela,
                    Owner = journal.Owner
                };

                // Incrementa a data
                data += GetTimeSpan(journal);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journal"></param>
        /// <param name="dataUltimaAtualizacao"></param>
        /// <param name="dataLimite"></param>
        private void GerarTransacoesCreditoDebito(JOURNAL journal, DateTime dataUltimaAtualizacao, DateTime dataLimite)
        {
            while (dataUltimaAtualizacao <= dataLimite)
            {
                dataUltimaAtualizacao += GetTimeSpan(journal);

                CONTA conta = GetConta(journal);

                TRANSACAO transacao = new TRANSACAO()
                {
                    JOURNAL = (JOURNAL)journal,
                    CONTA = conta,
                    CATEGORIA = journal.CATEGORIA,
                    Nome = journal.Nome,
                    Data = dataUltimaAtualizacao,
                    Valor = journal.Valor
                };

                journal.UltimaAtualizacao = dataUltimaAtualizacao;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journal"></param>
        /// <param name="dataUltimaAtualizacao"></param>
        /// <param name="dataLimite"></param>
        private void GerarTransacoesTransferencia(JOURNAL journal, DateTime dataUltimaAtualizacao, DateTime dataLimite)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transacao"></param>
        public void AtualizarJournal(ITRANSACAO transacao)
        {
        }

        /// <summary>
        /// Retorna a conta de acordo com o tipo de transação do journal.
        /// </summary>
        /// <param name="journal">O journal onde a conta será obtida.</param>
        /// <returns>A conta referente ao tipo da transação.</returns>
        public CONTA GetConta(JOURNAL journal)
        {
            if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Debito)
                return journal.CONTADEBITO;
            else if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Credito)
                return journal.CONTACREDITO;
            else
                throw new InvalidOperationException("O journal não é do tipo crédito ou débito.");
        }

        /// <summary>
        /// Retorna um TimeSpan de acordo com o tipo da periodicidade do journal.
        /// </summary>
        /// <param name="journal">O journal de onde o TimeSpan será obtido.</param>
        /// <returns>O TimeSpan de acordo com a periodicidade do Journal.</returns>
        private TimeSpan GetTimeSpan(IJOURNAL journal)
        {
            PLANTAEUTILS.Periodicidade periodicidade = (PLANTAEUTILS.Periodicidade)journal.Periodicidade;

            switch (periodicidade)
            {
                case PLANTAEUTILS.Periodicidade.Unico:
                    return new TimeSpan(0);
                case PLANTAEUTILS.Periodicidade.Semanal:
                    return new TimeSpan(7, 0, 0, 0);
                case PLANTAEUTILS.Periodicidade.Mensal:
                    return new TimeSpan(30, 0, 0, 0);
                case PLANTAEUTILS.Periodicidade.Anual:
                    return new TimeSpan(365, 0, 0, 0);
                default:
                    return new TimeSpan(0);
            }
        }
    }
}
