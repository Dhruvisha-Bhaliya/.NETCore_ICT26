using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQWithModel_withoutDB.Controllers
{
    public class StudentTestController : Controller
    {
       public ActionResult ShowData()
        {
            string s = "ICT2";
            return View("ShowData", s);
        }

        // GET: StudentTestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentTestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentTestController/Create
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

        // GET: StudentTestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentTestController/Edit/5
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

        // GET: StudentTestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentTestController/Delete/5
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
