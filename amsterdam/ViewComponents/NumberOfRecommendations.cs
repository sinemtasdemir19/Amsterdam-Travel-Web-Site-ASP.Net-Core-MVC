using amsterdam.Models;
using Microsoft.AspNetCore.Mvc;

namespace amsterdam.ViewComponents
{
    public class NumberOfRecommendation : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public NumberOfRecommendation(ApplicationDbContext db)
        {
            _db = db;
        }
        public string Invoke()
        {
            return $"Total Recommendation:{_db.recommendations.Count()}";
            
        }
    }
}
