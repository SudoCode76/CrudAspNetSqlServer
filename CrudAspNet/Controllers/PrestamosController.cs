using CrudAspNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAspNet.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: Prestamos
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Prestamos.ToList());
            }
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Prestamos.Where(x => x.idPrestamo == id).FirstOrDefault());
            }
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestamos/Create
        [HttpPost]
        public ActionResult Create(Prestamos prestamos)
        {
            try
            {
               using (DbModels context = new DbModels())
                {
                    context.Prestamos.Add(prestamos);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Prestamos.Where(x => x.idPrestamo == id).FirstOrDefault());
            }
        }

        // POST: Prestamos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Prestamos prestamos)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(prestamos).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Prestamos.Where(x => x.idPrestamo == id).FirstOrDefault());
            }
        }

        // POST: Prestamos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Prestamos prestamos = context.Prestamos.Where(x => x.idPrestamo == id).FirstOrDefault();
                    context.Prestamos.Remove(prestamos);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
