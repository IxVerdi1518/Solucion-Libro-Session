using LibroSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibroSession.Session;

namespace LibroSession.Controllers
{
    public class LibroController : Controller
    {
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

        // GET: LibroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibroController/Create
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
                try
                {
                    List<Libro> list = SessionHelper.GetObjectFromJson<List<Libro>>(HttpContext.Session, "libros");
                    if (list == null)
                        list = new List<Libro>();
                    list.Add(libro);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "libros", list);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["errorCedula"] = ex.Message;
                    return View("Create", libro);
                }


            }
            else
            {

                return View("Create", libro);
            }

        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
