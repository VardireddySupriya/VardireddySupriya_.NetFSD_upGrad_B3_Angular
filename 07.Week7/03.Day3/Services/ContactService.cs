using System.Reflection.Metadata.Ecma335;
using WebApplication2.Models;
using System.Linq;

namespace WebApplication2.Services
{
    public class ContactService : IContactService
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>();
       

        public List<ContactInfo> GetAll()
        {
            return contacts;
        }
        public ContactInfo GetByContactId(int id)
        {
            var result=contacts.FirstOrDefault(c => c.ContactId== id);
            return result;
        }
        public void Add(ContactInfo contact)
        {
            contacts.Add(contact);
        }
    }
    }
