using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core.Services
{
    public class JournalServices
    {
        public void GerarTransacoes(JOURNAL journal, DateTime dataLimite)
        {
            DateTime dataUltimaAtualizacao = journal.UltimaAtualizacao;

            if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Transferencia)
            {
                GerarTransacoesTransferencia(journal, dataUltimaAtualizacao, dataLimite);
            }
            else
            {
                GerarTransacoesCreditoDebito(journal, dataUltimaAtualizacao, dataLimite);
            }
        }

        private void GerarTransacoesCreditoDebito(JOURNAL journal, DateTime dataUltimaAtualizacao, DateTime dataLimite)
        {
            while (dataUltimaAtualizacao <= dataLimite)
            {
                dataUltimaAtualizacao += GetTimeSpan(journal);

                CONTA conta = null;

                if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Debito)
                    conta = journal.CONTADEBITO;
                else if (journal.TipoTransacao == (int)PLANTAEUTILS.TipoTransacao.Credito)
                    conta = journal.CONTACREDITO;

                TRANSACAO transacao = new TRANSACAO()
                {
                    Journal = journal.JournalID,
                    JOURNAL = (JOURNAL)journal,
                    Nome = journal.Nome,
                    Data = dataUltimaAtualizacao,
                    Valor = journal.Valor
                };

                journal.UltimaAtualizacao = dataUltimaAtualizacao;
            }
        }

        private void GerarTransacoesTransferencia(JOURNAL journal, DateTime dataUltimaAtualizacao, DateTime dataLimite)
        {

        }

        public void AtualizarJournal(ITRANSACAO transacao)
        {
        }

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
