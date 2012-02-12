using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core.Repositories
{
    public interface ITransacaoRepository : IRepository<TRANSACAO>
    {
        decimal GetTotalTransacoesEm(DateTime data, string owner);

        IEnumerable<TRANSACAO> GetByConta(CONTA conta, string owner);

        IEnumerable<TRANSACAO> GetByDate(DateTime startDate, DateTime endDate, string owner);

        IEnumerable<TRANSACAO> GetByContaAndDate(CONTA conta, DateTime startDate, DateTime endDate, string owner);
    }
}
