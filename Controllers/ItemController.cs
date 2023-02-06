using ItemSellingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemSellingApp.Controllers
{
    public class ItemController : Controller
    {
        public static List<Item> items = new List<Item>();
        public static Boolean isFirstRun = true;   //using a flag is better than items.count
        public static Item itemtodelete;
        public static Item itemtoedit;
        public IActionResult Index()
        {
            if (isFirstRun)
            {
                items.Add(new Item { Id = "12", Name = "Laptop", Price = 15, DESC = "good" });
                isFirstRun = false;
            }
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection data)
        {
            Item temp=new Item();   
            temp.Name=data["Name"];
            temp.Id=data["Id"]; 
            temp.DESC=data["DESC"];
            temp.Price = int.Parse(data["Price"]);
            items.Add(temp);    


            return View("Index",items);
        }
       
        public IActionResult Details(string Id)
        {
            Item temp = items.Find(item => item.Id == Id);
            return View(temp);
        }

        //public IActionResult Delete(string Id)
        //{
        //    Item temp = items.Find(item => item.Id == Id);
        //    items.Remove(temp);
            
        //    return View("Index",items);
        //}
        public IActionResult Delete(string Id)
        {
           itemtodelete = items.Find(item => item.Id == Id);
            

            return View(itemtodelete);
        }

        [HttpPost]
        public IActionResult Delete() //no need for IFormCollection because the form has no data
        {
            
            items.Remove(itemtodelete);
            itemtodelete = null;
            return View("Index",items);
        }

        public IActionResult Edit(string Id)
        {
            itemtoedit= items.Find(item => item.Id == Id);

            return View(itemtoedit);
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection data)
        {
            itemtoedit.Price = int.Parse(data["Price"]);
            itemtoedit.Name = data["Name"];
            itemtoedit.DESC = data["DESC"];


            return View("Index", items);
        }
    }
}
