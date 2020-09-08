using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Contact.Models
{
    public class ContactData
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}