using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Reflection;
using WebApplication7.Models;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public class ContactRepository:IContactRepository
    {
        private readonly string _connstr;
        public ContactRepository(IConfiguration config)
        {
            _connstr= config.GetConnectionString("DefaultConnection");
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connstr);
        }
        public IEnumerable<ContactInfo> GetAllContacts()
        {
            string sqlQuery = @"select * from ContactInfo c inner join Company co on co.CompanyId=c.CompanyId inner join Department d on d.DepartmentId=c.DepartmentId";
            var db= GetConnection();
            var result = db.Query<ContactInfo, Company, Department, ContactInfo>(
           sqlQuery,
           (contact, company, department) =>
           {
               contact.Company = company;
               contact.Department = department;
               return contact;
           },
          splitOn: "CompanyId,DepartmentId"
          );
            return result;
        }
        public ContactInfo GetContactById(int id)
        {
            string sqlQuery = @"SELECT *
            FROM ContactInfo c
            INNER JOIN Company co ON co.CompanyId = c.CompanyId
            INNER JOIN Department d ON d.DepartmentId = c.DepartmentId
            WHERE c.ContactId = @Id";
            var db=GetConnection();
            var result = db.Query<ContactInfo, Company, Department, ContactInfo>(
                sqlQuery,
                (contact, company, department) =>
                {
                    contact.Company = company;
                    contact.Department = department;
                    return contact;
                },
                new { Id = id },
                splitOn: "CompanyId,DepartmentId"
            ).FirstOrDefault();

            return result;

        }
        public void AddContact(ContactInfo contact)
        {
           string sqlQuery= @"INSERT INTO ContactInfo (FirstName,LastName,EmailId,MobileNo,Designation,CompanyId,DepartmentId) VALUES (@FirstName, @LastName,@EmailId,@MobileNo,@Designation,@CompanyId,@DepartmentId)";
            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }
        public void UpdateContact(ContactInfo contact)
        {
            string sqlQuery = @"
           UPDATE ContactInfo 
           SET 
           FirstName = @FirstName,
           LastName = @LastName,
           EmailId = @EmailId,
           MobileNo = @MobileNo,
           Designation = @Designation,
           CompanyId = @CompanyId,
           DepartmentId = @DepartmentId
           WHERE ContactId = @ContactId";

            var db = GetConnection();
             db.Execute(sqlQuery, contact);
            
        }
        public void DeleteContact(int id)
        {
            string sqlQuery = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using (var db = GetConnection())
            {
                db.Execute(sqlQuery, new { Id = id });
            }
        }
    }
}
