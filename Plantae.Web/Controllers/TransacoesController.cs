using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plantae.Core;
using Plantae.Core.Repositories;
using Plantae.Web.Models;

namespace Plantae.Web.Controllers
{
    [Authorize(Roles="Membros")]
    public class TransacoesController : Controller
    {
        ContaRepository contaRepository;
        JournalRepository journalRepository;
        TransacaoRepository transacaoRepository;

        public TransacoesController()
        {
            contaRepository = new ContaRepository(new ContextFactory());
            journalRepository = new JournalRepository(new ContextFactory());
            transacaoRepository = new TransacaoRepository(new ContextFactory());
        }

        //
        // GET: /Transacoes/

        public ActionResult Index()
        {
            ViewBag.Contas = contaRepository.GetAll(User.Identity.Name);

            return View();
        }

        //
        // GET: /Transacoes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
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
