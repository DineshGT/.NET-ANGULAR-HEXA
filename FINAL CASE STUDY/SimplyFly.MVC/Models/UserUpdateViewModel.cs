namespace SimplyFly.MVC.Models
{
    public class UserUpdateViewModel
    {
        public int UserId { get; set; }
        public string Role { get; set; }         
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }

        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

}
