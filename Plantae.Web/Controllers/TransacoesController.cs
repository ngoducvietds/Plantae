using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plantae.Core;
using Plantae.Core.Repositories;
using Plantae.Web.Models;
using Plantae.Core.Services;
using Plantae.Web.Services;

namespace Plantae.Web.Controllers
{
    [Authorize(Roles="Membros")]
    public class TransacoesController : Controller
    {
        ContaRepository contaRepository;
        CategoriaRepository categoriaRepository;
        JournalRepository journalRepository;
        TransacaoRepository transacaoRepository;
        ExtratoServices extratoServices;

        public TransacoesController()
        {
            contaRepository = new ContaRepository(new ContextFactory());
            categoriaRepository = new CategoriaRepository(new ContextFactory());
            journalRepository = new JournalRepository(new ContextFactory());
            transacaoRepository = new TransacaoRepository(new ContextFactory());
            extratoServices = new ExtratoServices();
        }

        //
        // GET: /Transacoes/

        public ActionResult Index()
        {
            // Recupera os dados de conta e período do extrato
            CONTA selectedConta = null;
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            // Cria o bag de contas
            ViewBag.Contas = contaRepository.GetAll(User.Identity.Name);

            // Cria o bag de extratos
            if(selectedConta != null)
                ViewBag.Extrato = extratoServices.BuildExtratoCollection(transacaoRepository.GetByContaAndDate(selectedConta, startDate, endDate, User.Identity.Name), selectedConta.GetSaldoEm(startDate));
            else
                ViewBag.Extrato = extratoServices.BuildExtratoCollection(transacaoRepository.GetAll(User.Identity.Name), transacaoRepository.GetTotalTransacoesEm(startDate, User.Identity.Name));


            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }
        
        /// <summary>
        /// Ação para criar uma transação. Obtém o tipo da transação pela rota recebida na requisição
        /// e chama a View com o form para criar a nova transação.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            string tipo = Request.QueryString["tipo"];

            ViewBag.TipoTransacao = GetTipoTransacaoValue(tipo).ToString();
            ViewBag.ContasDebito = new SelectList(contaRepository.GetAll(User.Identity.Name), "ContaID", "Nome");
            ViewBag.ContasCredito = new SelectList(contaRepository.GetAll(User.Identity.Name), "ContaID", "Nome");
            ViewBag.Categorias = new SelectList(categoriaRepository.GetAll(User.Identity.Name), "CategoriaID", "Nome");

            return ContextDependentView();
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(JournalModel model)
        {
            try
            {
                throw new NotImplementedException();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonCreate(JournalModel model)
        {
            UpdateJournalModelProperties(model, ModelState);

            if (ModelState.IsValid)
            {
                JOURNAL journal = new JOURNAL(model, User.Identity.Name);

                journalRepository.InsertOnSubmit(journal);
                journalRepository.Save();

                return Json(new { success = true });
            }

            return Json(new { errors = GetErrorsFromModelState() });
        }
        
        //
        // GET: /Transacoes/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Transacoes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Transacoes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Transacoes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void UpdateJournalModelProperties(JournalModel model, ModelStateDictionary modelState)
        {
            if (model.CategoriaID != 0)
                ModelState.Remove("Categoria");
            else
                ModelState.Remove("CategoriaID");

            if (model.ContaCreditoID.HasValue)
                model.CONTACREDITO = contaRepository.FindById(model.ContaCreditoID.Value, User.Identity.Name);
            
            if (model.ContaDebitoID.HasValue)
                model.CONTADEBITO = contaRepository.FindById(model.ContaDebitoID.Value, User.Identity.Name);
            
            model.CATEGORIA = categoriaRepository.FindById(model.CategoriaID, User.Identity.Name);
        }

        private int GetTipoTransacaoValue(string tipo)
        {
            switch (tipo)
            {
                case "credito":
                    return (int)PLANTAEUTILS.TipoTransacao.Credito;
                case "debito":
                    return (int)PLANTAEUTILS.TipoTransacao.Debito;
                case "transferencia":
                    return (int)PLANTAEUTILS.TipoTransacao.Transferencia;
                default:
                    return (int)PLANTAEUTILS.TipoTransacao.Credito;

            }
        }

        private ActionResult ContextDependentView(ContaModel model = null)
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView(model);
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View(model);
            }
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors
                .Select(error => error.ErrorMessage));
        }
    }
}
