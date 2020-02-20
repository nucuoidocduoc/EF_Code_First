using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "FirstName of Student is so long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "LasrName of Student is so long")]
        public string LastName { get; set; }

        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}