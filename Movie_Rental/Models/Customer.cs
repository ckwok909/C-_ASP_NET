using System.ComponentModel.DataAnnotations;

namespace Movie_Rental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubsribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        [Display (Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

    }
}
