using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace /*removed*/.Models.Requests.Contacts
{
    public class ContactAddRequest
    {
        [Required][StringLength(255, MinimumLength = 3, ErrorMessage = "An email address is required")]
        [EmailAddress] public string Email { get; set; }
#nullable enable
        [StringLength(200)] public string? Name { get; set; }
        [StringLength(255)] public string? AvatarUrl { get; set; }
        [StringLength(20)] public string? Phone { get; set; }
        [StringLength(400)] public string? Notes { get; set; }
#nullable disable
    }
}
