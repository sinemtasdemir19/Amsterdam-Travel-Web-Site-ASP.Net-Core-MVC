using amsterdam.Models;
using Microsoft.AspNetCore.Mvc;

namespace amsterdam.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RecommendationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<recommendation> objList = _db.recommendations.ToList();
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            recommendation obj = new recommendation();
            if (id == null)
            {
                //create
                return View(obj);
            }
            //update
            obj = _db.recommendations.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update_Insert(recommendation obj)
        {

            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    //create
                    _db.recommendations.Add(obj);
                }
                else
                {
                    _db.recommendations.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var obj = _db.recommendations.FirstOrDefault(u => u.Id == id);
            _db.recommendations.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
