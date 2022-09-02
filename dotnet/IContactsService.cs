using Sabio.Models;
using Sabio.Models.Domain;
using Sabio.Models.Requests.Contacts;
using System.Collections.Generic;

namespace Sabio.Services.Interfaces
{
    public interface IContactsService
    {
        Paged<Contact> Get(int CreatedBy, int pageIndex, int pageSize);
        Paged<Contact> Search(int createdBy, string query, int pageIndex, int pageSize);
        int Add(ContactAddRequest model, int userId);
        void Update(ContactUpdateRequest model, int userId);
        void Delete(int id);
    }
}