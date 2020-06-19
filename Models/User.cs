using System.ComponentModel.DataAnnotations;

namespace APIFuelStation.Models {
    public class User {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength (50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength (30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength (50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength (100)]
        public string Email { get; set; }

        [Required]
        [MaxLength (15)]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength (100)]
        public string Password { get; set; }

        [Required]
        [MaxLength (250)]
        public string Avatar { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}