using System;

#nullable disable

namespace DockerWebAPIWithDB.Models
{
    public partial class User
    {
        public string UserName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
    }
}
