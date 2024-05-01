using BuyMeAbook.Data;
using BuyMeAbook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuyMeAbook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; //calling object of application dvb context to work with db so we can list add delet update objs

        public CategoryController(ApplicationDbContext db) //all implementation of connection string and tables
                                                           //are needed to retrive data so we can populate our local db obj
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList= _db.Categories; //retirve categories from the table
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX \n"+objCategoryList);

            return View(objCategoryList);
        }
    }
}
