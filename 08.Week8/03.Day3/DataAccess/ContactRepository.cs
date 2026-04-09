using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication9.Controllers;
using WebApplication9.Models;

namespace WebApplication9.DataAccess
{
    public class ContactRepository:IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo(){ContactId=1,FirstName="soujanya",LastName="shetty",EmailId="souji@gmail.com",MobileNo=9989897767,DepartmentId=1,CompanyId=1},
             new ContactInfo(){ContactId=2,FirstName="kalpana",LastName="Reddy",EmailId="kalpana@gmail.com",MobileNo=8987897767,DepartmentId=1,CompanyId=2},
        };
        private static int _id = 3;
        public async Task<IEnumerable<ContactInfo>> GetAllContactsAsync()
        {
            return await Task.FromResult(contacts);
        }
        public async Task<ContactInfo> GetContactByIdAsync(int id)
        {
            var contact=contacts.Find(c=>c.ContactId==id);
            return await Task.FromResult(contact);
        }
        public async Task<ContactInfo> CreateContactAsync(ContactInfo contact)
        {
            contact.ContactId = _id++;
            contacts.Add(contact);
            return await Task.FromResult(contact);

        }
        public async Task<bool> UpdateContactAsync(int id, ContactInfo contact)
        {
            var existing = contacts.Find(c => c.ContactId == id);
            if (existing == null) return false;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;
            return await Task.FromResult(true);

        }
        public async Task<bool> DeleteContactAsync(int id)
        {
            var delete = contacts.Find(c => c.ContactId == id);
            if (delete == null) return false;
            contacts.Remove(delete);
            return await Task.FromResult(true);
        }

    }
}
