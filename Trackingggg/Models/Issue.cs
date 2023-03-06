using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Trackingggg.Models
{
    public class Issue
    {
        // when writing validations the [required] attribute will determine if it needs to pass validation check putting them above the property -> this is important
        public uint Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;
        public IssueType IssueType { get; set; }
        public Priority Priority { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }


    }

    public enum Priority { 
        Low, 
        Medium,
        High,
    }

    public enum IssueType { 
        Feature,
        Bug,
        Documentation
    }
}
