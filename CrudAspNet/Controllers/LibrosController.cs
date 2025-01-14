using CrudAspNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAspNet.Controllers
{
    
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.ToList());
            }
            
        }

        // GET: Libros/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x => x.idLibro == id).FirstOrDefault());
            }
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(Libros libros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Libros.Add(libros);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x => x.idLibro == id).FirstOrDefault());
            }
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Libros libros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(libros).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Libros.Where(x => x.idLibro == id).FirstOrDefault());
            }
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels context = new DbModels())
                {
                    Libros libro = context.Libros.Where(x => x.idLibro == id).FirstOrDefault();
                    context.Libros.Remove(libro);
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
