using AddressBook.Models;

namespace AddressBook.Interfaces
{
    public interface IContactServices
    {
        ContactModel GetContactById(int id);
        IEnumerable<ContactModel> GetAllContacts();

        void AddContact(ContactModel contact);
        void UpdateContact(ContactModel contact);
        void DeleteContact(int id);
    }
}
