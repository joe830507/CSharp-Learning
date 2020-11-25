using System.ComponentModel.DataAnnotations;

namespace Example378
{
    public class User
    {
        public int UID { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
