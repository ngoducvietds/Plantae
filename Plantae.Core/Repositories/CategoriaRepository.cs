using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plantae.Core.Exceptions;

namespace Plantae.Core.Repositories
{
    public class CategoriaRepository : Repository<CATEGORIA>, ICategoriaRepository
    {
        public CategoriaRepository(IContextFactory contextFactory)
            : base(contextFactory) { }

        public override CATEGORIA FindById(long id, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner == owner).Where(c => c.CategoriaID == id).SingleOrDefault();
        }

        public void Update(CATEGORIA categoria, string nome)
        {
            categoria.Nome = nome;
        }
    }
}
