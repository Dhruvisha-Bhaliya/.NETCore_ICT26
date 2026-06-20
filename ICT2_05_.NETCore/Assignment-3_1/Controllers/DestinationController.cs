using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3_1.Controllers
{
    public class DestinationController : Controller
    {
        private static List<Tuple<int, string, string, int, string>> destinations = new List<Tuple<int, string, string, int, string>>()
        {
            new Tuple<int,string,string,int,string>(1,"Bali","Indonesia",1200,"Summer"),
            new Tuple<int,string,string,int,string>(2,"Paris","France",2000,"Spring"),
            new Tuple<int,string,string,int,string>(3,"Dubai","UAE",1500,"Winter"),
            new Tuple<int, string, string, int, string>(4, "Tokyo", "Japan", 1800, "Autumn"),
            new Tuple<int, string, string, int, string>(5, "New York", "USA", 2200, "Fall")

        };

        // GET: DestinationController
        public ActionResult Index()
        {
            return View(destinations);
        }

        // GET: DestinationController/Details/5
        public ActionResult Details(int id)
        {
            var data = destinations.FirstOrDefault(x => x.Item1 == id);
            return View(data);
        }

        // GET: DestinationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["DestinationId"].ToString());
                string name = collection["DestinationName"].ToString() ?? "";
                string country = collection["Country"].ToString() ?? "";
                int cost = Convert.ToInt32(collection["EstimatedCost"].ToString());
                string season = collection["BestSeason"].ToString() ?? "";

                destinations.Add(new Tuple<int, string, string, int, string>(id, name, country, cost, season));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DestinationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(destinations.SingleOrDefault(d => d.Item1 == id));
        }

        // POST: DestinationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var dest = destinations.SingleOrDefault(d => d.Item1 == id);

                destinations.Remove(dest);

                string name = collection["DestinationName"].ToString() ?? "";
                string country = collection["Country"].ToString() ?? "";
                int cost = Convert.ToInt32(collection["EstimatedCost"].ToString());
                string season = collection["BestSeason"].ToString() ?? "";

                destinations.Add(new Tuple<int, string, string, int, string>(id, name, country, cost, season));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DestinationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(destinations.SingleOrDefault(d => d.Item1 == id));
        }

        // POST: DestinationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var dest = destinations.SingleOrDefault(d => d.Item1 == id);

                if (dest != null)
                    destinations.Remove(dest);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
