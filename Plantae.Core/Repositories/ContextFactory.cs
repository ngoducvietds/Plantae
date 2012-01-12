using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Plantae.Core.Repositories
{
    public class ContextFactory : Disposable, IContextFactory
    {
        private static DataContext _context;

        public DataContext Get()
        {
            return _context ?? (_context = new PlantaeModelDataContext());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
