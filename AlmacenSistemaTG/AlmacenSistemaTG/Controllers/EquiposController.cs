using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenSistemaTG.Models;

namespace AlmacenSistemaTG.Controllers
{
    public class EquiposController : Controller
    {
        private SistemaAlmacenEntities db = new SistemaAlmacenEntities();

        // GET: Equipos
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Almacen).Include(e => e.Marca).Include(e => e.Modelo);
            return View(equipo.ToList());
        }

        // GET: Equipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "Descripcion");
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descripcion");
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Descripcion");
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipo,IdMarca,IdModelo,NoSerie,Existencia,Proveedor,IdAlmacen")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "Descripcion", equipo.IdAlmacen);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descripcion", equipo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Descripcion", equipo.IdModelo);
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "Descripcion", equipo.IdAlmacen);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descripcion", equipo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Descripcion", equipo.IdModelo);
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEquipo,IdMarca,IdModelo,NoSerie,Existencia,Proveedor,IdAlmacen")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "Descripcion", equipo.IdAlmacen);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descripcion", equipo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Descripcion", equipo.IdModelo);
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
