using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plantae.Web.Models;
using Plantae.Core.Repositories;
using Plantae.Core;

namespace Plantae.Web.Controllers
{
    public class ContaController : Controller
    {
        ContaRepository contaRepository;

        public ContaController()
        {
            contaRepository = new ContaRepository(new ContextFactory());
        }

        //
        // GET: /Conta/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Conta/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Conta/Create

        public ActionResult Create()
        {
            return ContextDependentView();
        } 

        //
        // POST: /Conta/Create

        [HttpPost]
        public ActionResult Create(ContaModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult JsonCreate(ContaModel model)
        {
            if (ModelState.IsValid)
            {
                CONTA conta = new CONTA(model.Nome, model.DataInicial, model.SaldoInicial, User.Identity.Name);

                contaRepository.InsertOnSubmit(conta);
                contaRepository.Save();

                return Json(new { success = true });
            }

            return Json(new { errors = GetErrorsFromModelState() });
        }
        
        //
        // GET: /Conta/Edit/5
 
        public ActionResult Edit(long id)
        {
            var conta = contaRepository.FindById(id, User.Identity.Name);

            return ContextDependentView(new ContaModel(conta));
        }

        //
        // POST: /Conta/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
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

        [HttpPost]
        public JsonResult JsonEdit(long id, ContaModel model)
        {
            if (ModelState.IsValid)
            {
                CONTA conta = contaRepository.FindById(id, User.Identity.Name);

                conta.Update(model.Nome, model.DataInicial, model.SaldoInicial);

                contaRepository.Save();

                return Json(new { success = true });
            }

            return Json(new { errors = GetErrorsFromModelState() });
        }

        //
        // GET: /Conta/Delete/5
 
        public ActionResult Delete(long id)
        {
            return ContextDependentView();
        }

        //
        // POST: /Conta/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
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
