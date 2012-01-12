using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plantae.Core;
using Plantae.Core.Repositories;

namespace Plantae.Web.Controllers
{
    [Authorize(Roles="Membros")]
    public class TransacoesController : Controller
    {
        ContaRepository contaRepository;

        public TransacoesController()
        {
            contaRepository = new ContaRepository(new ContextFactory());
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

        //
        // GET: /Transacoes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Transacoes/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
    }
}
