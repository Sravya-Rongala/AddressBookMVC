using AddressBook.Data;
using Dapper.Contrib.Extensions;
using AddressBook.Models;
using AddressBook.Interfaces;

namespace AddressBook.Repositories
{
    public class DapperContactRepository : IContactServices
    {

        private ContactDetailsContext _db;
        public DapperContactRepository(ContactDetailsContext db)
        {
            _db = db;
        }

        public IEnumerable<ContactModel> GetAllContacts()
        {
            return _db.connection.GetAll<ContactModel>();
        }

        public void AddContact(ContactModel contact)
        {
            _db.connection.Insert(contact);
        }

        public ContactModel GetContactById(int id)
        {
            ContactModel contact = _db.connection.Get<ContactModel>(id);
            return contact;
        }

        public void UpdateContact(ContactModel contact)
        {
            _db.connection.Update(contact);
        }

        public void DeleteContact(int Id)
        {
            ContactModel contact = this.GetContactById(Id);
            _db.connection.Delete(contact);
        }

    }
}
