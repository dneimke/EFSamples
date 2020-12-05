using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSamples.Data
{
    public class Subject
    {
        public Guid Id { get; set; }

        [Required]
        public Person TaughtBy { get; set; }

        public List<Person> Participants { get; set; } = new();
    }
}
