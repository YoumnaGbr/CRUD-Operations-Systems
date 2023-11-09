using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(5, ErrorMessage = "Minimum Length Is 5 Chars")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(NewPassword), ErrorMessage = "Password DOSENOT Match")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
