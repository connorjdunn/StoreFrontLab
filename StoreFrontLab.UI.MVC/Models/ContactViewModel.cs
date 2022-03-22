using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreFrontLab.UI.MVC.Models
{
    public class ContactViewModel
    {
        //FIELDS - N/A

        //PROPERTIES
        [Required(ErrorMessage = "*Name is required")] //Makes the field a requirement
        public string Name { get; set; }

        [Required(ErrorMessage = "*Email is required")]
        [DataType(DataType.EmailAddress)] //Ensures the value in the field is an email address
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [UIHint("MultilineText")] //Makes the <inputs> in this field a TextArea
        public string Message { get; set; }

        //CONSTRUCTORS - N/A (handled by the form)

        //METHODS - N/A
    }
}
