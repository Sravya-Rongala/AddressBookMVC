using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Services;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private  ContactServices _contactServicesObj;
        public HomeController(ContactServices db)
        {
            _contactServicesObj = db;
        } 
        public IActionResult Index(int id)
        {
            IEnumerable<ContactModel> ContactDetailsList = _contactServicesObj.GetAllContacts();
            ViewData["List"] = ContactDetailsList.ToList();
            if (id == 0)
            {
                ContactModel firstItem = ContactDetailsList.FirstOrDefault()!;
                return View(firstItem);
            }
            else
            {   ContactModel ContactDetails = _contactServicesObj.GetContactById(id);
                return View(ContactDetails);
            }
        }
    }
} 