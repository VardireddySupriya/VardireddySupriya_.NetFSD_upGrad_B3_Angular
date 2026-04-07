using WebApplication7.Models;
using WebApplication7.Repository;

namespace WebApplication7.Services
{
    public class ContactService:IContactService
    {
        private readonly IContactRepository _repo;
        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<ContactInfo> GetAllContacts()
        {
            return _repo.GetAllContacts();
        }
        public ContactInfo GetContactById(int id)
        {
            return _repo.GetContactById(id);
        }
        public void AddContact(ContactInfo contact)
        {
           _repo.AddContact(contact);
        }
        public void UpdateContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
        }
        public void DeleteContact(int id)
        {
            _repo.DeleteContact(id);
        }
    }
}
