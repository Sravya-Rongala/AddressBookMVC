using AddressBook.Data;
using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Repositories
{
    public class EFContactRepository : IContactServices
    {

        private ContactDbContext _dbo;
        public EFContactRepository(ContactDbContext db)
        {
            _dbo = db;
        }

        public IEnumerable<ContactModel> GetAllContacts()
        {
            IEnumerable<ContactModel> ContactDetailsList = _dbo.ContactDetails;
            return ContactDetailsList;
        }

        public void AddContact(ContactModel contact)
        {
            _dbo.ContactDetails.Add(contact);
            _dbo.SaveChanges();
        }

        public ContactModel GetContactById(int id)
        {
            ContactModel contact = _dbo.ContactDetails.Single(contact => contact.Id == id);
            return contact;
        }

        public void UpdateContact(ContactModel contact)
        {
            _dbo.ContactDetails.Update(contact);
            _dbo.SaveChanges();
        }

        public void DeleteContact(int Id)
        {
            ContactModel contact = this.GetContactById(Id);
            _dbo.ContactDetails.Remove(contact);
            _dbo.SaveChanges();
        }

    }
}


