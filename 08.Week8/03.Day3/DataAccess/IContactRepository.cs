using WebApplication9.Models;

namespace WebApplication9.DataAccess
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllContactsAsync();
        Task<ContactInfo> GetContactByIdAsync(int id);
        Task<ContactInfo> CreateContactAsync(ContactInfo contact);
        Task<bool> UpdateContactAsync(int id, ContactInfo contact);
        Task<bool> DeleteContactAsync(int id);

    }
}
