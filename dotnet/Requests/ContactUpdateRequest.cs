using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace /*removed*/.Models.Requests.Contacts
{
    public class ContactUpdateRequest : ContactAddRequest, IModelIdentifier
    {
        [Required] public int Id { get; set; }
    }
}
