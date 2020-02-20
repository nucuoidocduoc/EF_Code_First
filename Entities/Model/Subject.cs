using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Model
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name of subject is so long")]
        public string SubjectName { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Teacher))]
        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}