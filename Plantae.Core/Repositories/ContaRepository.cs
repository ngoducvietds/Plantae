using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plantae.Core.Exceptions;

namespace Plantae.Core.Repositories
{
    public class ContaRepository : Repository<CONTA>, IContaRepository
    {
        public ContaRepository(IContextFactory contextFactory)
            : base(contextFactory) { }

        public override CONTA FindById(long id, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner == owner).Where(c => c.ContaID == id).SingleOrDefault();
        }
    }
}
