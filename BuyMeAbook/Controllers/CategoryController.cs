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

        //list categories
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList= _db.Categories; //retirve categories from the table
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX \n"+objCategoryList);

            return View(objCategoryList);
        }

        //create new category GET
        public IActionResult Create()
        {
        
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //prevent xcsrf attacks
        public IActionResult Create(Category obj)
        {
           if (obj.Name==obj.DisplayOrder.ToString() ){ //validation in the serveer  side

                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

            }
           if(ModelState.IsValid) { //model validation
                _db.Categories.Add(obj); //we created an object 
                _db.SaveChanges(); //we saved it
                return RedirectToAction("Index"); //redirect to the Index methode in the controller
                                                  // if you want to redirect to another controller just define it using "metohde","controllername"
            }
           return View(obj);

        }


        //EDIT GET
		public IActionResult Edit(int? id)
		{
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id); //find item based on ID
            /*            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id); other ways to retrive object from DB
                        var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);*/
            if (categoryFormDb == null) { return NotFound(); }

			return View(categoryFormDb);
		}
		// EDIT Post
		[HttpPost]
		[ValidateAntiForgeryToken] //prevent xcsrf attacks
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{ //validation in the serveer  side

				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

			}
			if (ModelState.IsValid)
			{ //model validation
				_db.Categories.Update(obj); //we updated theobject object 
				_db.SaveChanges(); //we saved it
				return RedirectToAction("Index"); //redirect to the Index methode in the controller
												  // if you want to redirect to another controller just define it using "metohde","controllername"
			}
			return View(obj);

		}
	}



}
