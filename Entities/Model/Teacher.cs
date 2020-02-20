using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "FirstName of Teacher is so long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "LastName of Teacher is so long")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Position of Teacher is so long")]
        public string Position { get; set; }

        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}