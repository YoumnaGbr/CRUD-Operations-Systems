using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
         
		[Required(ErrorMessage = "First Name is Required")]
		public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
		public string LName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Password Is Required")]
        [MinLength(5,ErrorMessage ="Minimum Length Is 5 Chars")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password Is Required")]
        [Compare(nameof(Password),ErrorMessage ="Password DOSENOT Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
