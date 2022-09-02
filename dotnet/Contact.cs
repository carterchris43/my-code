using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public int CreatedBy { get; set; }
    }
}
