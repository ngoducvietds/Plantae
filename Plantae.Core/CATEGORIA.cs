using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae.Core
{
    public partial class CATEGORIA : IOwnable
    {
        public CATEGORIA(string nome, string owner)
        {
            Nome = nome;
            Owner = owner;
        }

        public void Update(string nome) 
        {
            Nome = nome;
        }
    }
}
