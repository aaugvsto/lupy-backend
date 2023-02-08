namespace Lupy.Models
{
    public class UserModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
    }
}
