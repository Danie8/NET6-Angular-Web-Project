using System.ComponentModel.DataAnnotations;

namespace NET6_Angular_Web_Project.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, ErrorMessage = "The {0} must be between 3 and {1} characters lenght.", MinimumLength = 3)]
        //[RegularExpression(@"/^[a-z0-9_.,+*?¿¡!$@#:;-]*$/", ErrorMessage = "Characters are not allowed.")]
        [RegularExpression(@"^[\S]+$", ErrorMessage = "Blank spaces are not allowed.")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, ErrorMessage = "The {0} must be between 5 and {1} characters lenght.", MinimumLength = 5)]
        [Display(Name = "Full Name")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, ErrorMessage = "The {0} must be between 3 and {1} characters lenght.", MinimumLength = 3)]
        [Display(Name = "Firm")]
        public string? Empresa { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, ErrorMessage = "The {0} must be between 3 and {1} characters lenght.", MinimumLength = 3)]
        [Display(Name = "Area")]
        public string? Area { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Reference")]
        public string? Referencia { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
