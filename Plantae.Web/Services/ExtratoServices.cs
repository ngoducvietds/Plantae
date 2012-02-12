using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plantae.Web.Models;
using Plantae.Core;

namespace Plantae.Web.Services
{
    public class ExtratoServices
    {
        public List<ExtratoModel> BuildExtratoCollection(IEnumerable<TRANSACAO> transacoes, decimal saldoInicial)
        {
            List<ExtratoModel> extrato = new List<ExtratoModel>();

            return extrato;
        }
    }
}