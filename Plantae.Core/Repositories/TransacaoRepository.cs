using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plantae.Core.Exceptions;
using Plantae.Core.Services;

namespace Plantae.Core.Repositories
{
    public class TransacaoRepository : Repository<TRANSACAO>, ITransacaoRepository
    {
        JournalServices journalServices;

        public TransacaoRepository(IContextFactory contextFactory)
            : base(contextFactory) 
        {
            journalServices = new JournalServices();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public override TRANSACAO FindById(long id, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner == owner).Where(c => c.TransacaoID == id).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public decimal GetTotalTransacoesEm(DateTime data, string owner)
        {
            return Table.Where(t => t.Owner == owner && t.Data <= data).Sum(t => (decimal?)t.Valor) ?? 0.0M;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public IEnumerable<TRANSACAO> GetByConta(CONTA conta, string owner)
        {
            return Table.Where(t => t.Owner == owner && t.ContaID == conta.ContaID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public IEnumerable<TRANSACAO> GetByDate(DateTime startDate, DateTime endDate, string owner)
        {
            return Table.Where(t => t.Owner == owner && t.Data >= startDate && t.Data <= endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public IEnumerable<TRANSACAO> GetByContaAndDate(CONTA conta, DateTime startDate, DateTime endDate, string owner)
        {
            return Table.Where(t => t.Owner == owner && t.ContaID == conta.ContaID && t.Data >= startDate && t.Data <= startDate);
        }
    }
}
