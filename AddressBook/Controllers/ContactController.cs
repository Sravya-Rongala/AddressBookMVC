using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Services;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private ContactServices _contactServicesObj;
        private IEnumerable<ContactModel> contactDetailsList;
        public ContactController(ContactServices db)
        {
            _contactServicesObj = db;
            this.contactDetailsList = _contactServicesObj.GetAllContacts();
        }
        public IActionResult DisplayContactForm()
        {
            ViewData["List"] = this.contactDetailsList.ToList();
            return View("ContactForm");
        }
        public IActionResult DisplayContact(int Id)
        {
            ViewData["List"] = this.contactDetailsList.ToList();
            ContactModel contact = _contactServicesObj.GetContactById(Id);
            return RedirectToAction("index", "home", new { id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactFormOperations(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                if(contact.Id==0)
                {
                    _contactServicesObj.AddContactDetails(contact);
                    return RedirectToAction("index", "home",new {id=contact.Id});
                }
                _contactServicesObj.UpdateContactDetails(contact);
                return RedirectToAction("index", "home", new {id=contact.Id});

            }
            else
            {
                ViewData["List"] = this.contactDetailsList.ToList();
                return View("contactform",contact);
            }
            
        }
       
        public IActionResult UpdateContactForm(int Id) 
        {
            ContactModel contact = _contactServicesObj.GetContactById(Id);
            ViewData["List"] = this.contactDetailsList.ToList();
            return View("contactform",contact);        
        }   
        public IActionResult DeleteContact(int Id) 
        {
            _contactServicesObj.DeleteContact(Id);
            return RedirectToAction("index", "home");
        }
    }
}