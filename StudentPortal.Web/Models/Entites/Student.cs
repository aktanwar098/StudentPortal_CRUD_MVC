using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entites
{
    public class Student
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, ErrorMessage = "Please do not enter values over 10 digits")]
        public string Phone { get; set; }

        
        public bool Subscribed { get; set; }
    }
}
