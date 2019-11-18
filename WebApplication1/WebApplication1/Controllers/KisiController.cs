using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kisi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kisi/Create
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

        // GET: Kisi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kisi/Edit/5
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

        // GET: Kisi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kisi/Delete/5
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
