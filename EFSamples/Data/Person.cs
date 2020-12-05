using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSamples.Data
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        public List<Subject> EnrolledSubjects { get; set; } = new();
    }
}
