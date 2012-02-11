using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public interface IOwnable
    {
        String Owner { get; set; }

        DateTime DataAlteracao { get; set; }
    }
}
