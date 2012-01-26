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

        public override TRANSACAO FindById(long id, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner == owner).Where(c => c.TransacaoID == id).SingleOrDefault();
        }
    }
}
