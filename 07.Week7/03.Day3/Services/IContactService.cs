using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAll();
        ContactInfo GetByContactId(int id);
        public void Add(ContactInfo contact);
       
    }
}
