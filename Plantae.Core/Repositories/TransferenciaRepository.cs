using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plantae.Core.Exceptions;

namespace Plantae.Core.Repositories
{
    public class TransferenciaRepository : Repository<TRANSFERENCIA>, ITransferenciaRepository
    {
        public TransferenciaRepository(IContextFactory contextFactory)
            : base(contextFactory) { }

        public override TRANSFERENCIA FindById(long id, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner == owner).Where(c => c.TransferenciaID == id).SingleOrDefault();
        }
    }
}
