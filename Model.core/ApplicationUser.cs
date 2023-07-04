using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Model.core
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum Status
    {
        Pending,
        Reject,
        Approval
    }
    public class ApplicationUser: IdentityUser
    {
        public Gender? gender { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public byte[] image { get; set; }
        public string? NationalId { get; set; }
        [DefaultValue("Pending")]
        public Status? Status { get; set; }
        public bool IsDeleted { get; set; }

    }
}