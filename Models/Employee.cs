using System.ComponentModel.DataAnnotations;

namespace APIFuelStation.Models {
    public class Employee {
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
        public bool Gender { get; set; }

        [MaxLength (100)]
        public string? Password { get; set; }

        [MaxLength (250)]
        public string? Avatar { get; set; }

        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string? JoiningDate { get; set; }

        public int? DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        // public Department Department { get; set; }
        // public Designation Designation { get; set; }
    }
}