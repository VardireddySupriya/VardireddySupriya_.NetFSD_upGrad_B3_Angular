using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public interface IContactRepository
    {
        IEnumerable<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contactInfo);
        void UpdateContact(ContactInfo contactInfo);
        void DeleteContact(int id);
    }
}
