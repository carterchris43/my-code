// proprietary code removed //
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace // proprietary code removed //
{
    public class ContactsService : IContactsService
    {
        /* proprietary code removed */ _data = null;

        public ContactsService(/* proprietary code removed */ data)
        {
            _data = data;
        }

        public int Add(ContactAddRequest model, int userId)
        {
            string procName = "[dbo].[Contacts_Insert]";
            int id = 0;

            _data./* proprietary code removed */(procName, /* proprietary code removed */: delegate (SqlParameterCollection col)
            {
                AddCommonParams(model, col);
                col.AddWithValue("@CreatedBy", userId);

                SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                idOut.Direction = ParameterDirection.Output;

                col.Add(idOut);
            },
            /* proprietary code removed */: delegate (SqlParameterCollection returnCollection)
            {
                object oId = returnCollection["@Id"].Value;
                int.TryParse(oId.ToString(), out id);
                Console.WriteLine("");
            });
            return id;
        }

        public void Update(ContactUpdateRequest model, int userId)
        {
            string procName = "[dbo].[Contacts_Update]";
            _data./* proprietary code removed */(procName, /* proprietary code removed */: delegate (SqlParameterCollection col)
            {
                AddCommonParams(model, col);
                col.AddWithValue("@CreatedBy", userId);
                col.AddWithValue("@Id", model.Id);
            },
            /* proprietary code removed */: null);
        }

        public Paged<Contact> Get(int userId, int pageIndex, int pageSize)
        {
            Paged<Contact> page = null;
            List<Contact> list = null;
            
            int totalCount = 0;

            string procName = "[dbo].[Contacts_Select_ByCreatedBy]";

            _data./* proprietary code removed */(procName, delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@PageIndex", pageIndex);
                paramCollection.AddWithValue("@PageSize", pageSize);
                paramCollection.AddWithValue("@CreatedBy", userId);

            }, delegate (IDataReader reader, short set)
            {
                int idx = 0;
                Contact contact = MapSingleContact(reader, ref idx);
                if(totalCount == 0)
                {
                    totalCount = reader./* proprietary code removed */(idx++);
                }
                if (list == null)
                {
                    list = new List<Contact>();
                }
                list.Add(contact);
            }
            );
            if (list != null)
            {
                page = new Paged<Contact>(list, pageIndex, pageSize, totalCount);
            }
            return page;
        }

        public Paged<Contact> Search(int userId,string query, int pageIndex, int pageSize)
        {
            Paged<Contact> page = null;
            List<Contact> list = null;

            int totalCount = 0;

            string procName = "[dbo].[Contacts_Search]";

            _data./* proprietary code removed */(procName, delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@PageIndex", pageIndex);
                paramCollection.AddWithValue("@PageSize", pageSize);
                paramCollection.AddWithValue("@CreatedBy", userId);
                paramCollection.AddWithValue("@Query", query);

            }, delegate (IDataReader reader, short set)
            {
                int idx = 0;
                Contact contact = MapSingleContact(reader, ref idx);
                if (totalCount == 0)
                {
                    totalCount = reader./* proprietary code removed */(idx++);
                }
                if (list == null)
                {
                    list = new List<Contact>();
                }
                list.Add(contact);
            }
            );
            if (list != null)
            {
                page = new Paged<Contact>(list, pageIndex, pageSize, totalCount);
            }
            return page;
        }

        public void Delete(int id)
        {
            string procName = "[dbo].[Contacts_Delete_ById]";
            _data./* proprietary code removed */(procName, /* proprietary code removed */: delegate (SqlParameterCollection col)
            {
                col.AddWithValue("@Id", id);
            },
            /* proprietary code removed */: null);
        }

        private static void AddCommonParams(ContactAddRequest model, SqlParameterCollection col)
        {
            col.AddWithValue("@Name", model.Name); 
            col.AddWithValue("@AvatarUrl", model.AvatarUrl);
            col.AddWithValue("@Email", model.Email);
            col.AddWithValue("@Phone", model.Phone);
            col.AddWithValue("@Notes", model.Notes);
        }

        private static Contact MapSingleContact(IDataReader reader, ref int startingIndex)
        {
            Contact aContact = new Contact();

            aContact.Id = reader./* proprietary code removed */(startingIndex++);
            aContact.Name = reader./* proprietary code removed */(startingIndex++);
            aContact.AvatarUrl = reader./* proprietary code removed */(startingIndex++);
            aContact.Email = reader./* proprietary code removed */(startingIndex++);
            aContact.Phone = reader./* proprietary code removed */(startingIndex++);
            aContact.Notes = reader./* proprietary code removed */(startingIndex++);
            aContact.CreatedBy = reader./* proprietary code removed */(startingIndex++);

            return aContact;
        }
    }
}
