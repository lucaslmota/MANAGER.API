using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login não pode ser vasio")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "A senha não pode ser vasia")]
        public string Password { get; set; }
    }
}