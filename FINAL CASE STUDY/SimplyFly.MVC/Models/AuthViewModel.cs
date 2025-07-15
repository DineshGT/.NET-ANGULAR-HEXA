using SimplyFly.MVC.DTO.Auth;

namespace SimplyFly.MVC.Models
{
    public class AuthViewModel
    {
        public RequestLogin Login { get; set; } = new();
        public RegisterRequest Register { get; set; } = new();
    }

}
