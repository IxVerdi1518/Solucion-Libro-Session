using LibroSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibroSession.Session;
using System.Collections.Generic;

namespace LibroSession.Controllers
{
    public class LibroController : Controller
    {
        List<Libro> list = new List<Libro>();
        public IActionResult Index()
        {
            return View(listaLibros());
        }
        public List<Libro> listaLibros()
        {
            List<Libro> list = SessionHelper.GetObjectFromJson<List<Libro>>(HttpContext.Session, "libros");
            if (list == null)
            {
                list = new List<Libro>();
            }
            return list;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                List<Libro> list = SessionHelper.GetObjectFromJson<List<Libro>>(HttpContext.Session, "libros");
                if (list == null)
                list = new List<Libro>();
                list.Add(libro);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "libros", list);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", libro);
            }
        }

        [HttpGet("Libro/Delete/{titulo}")]
        public IActionResult Delete(String titulo)
        {
            if (ModelState.IsValid)
            {
                List<Libro> list = SessionHelper.GetObjectFromJson<List<Libro>>(HttpContext.Session, "libros");
                if (list == null)
                {
                    list = new List<Libro>();
                    list.RemoveAll(x => x.Titulo == titulo);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "libros", list);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
    }
}
