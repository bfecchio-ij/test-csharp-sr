using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Entities
{
    public class Candidates
    {
        [Key]
        public int IdCandidates { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Surname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }

        [MaxLength(250)]
        public string Email { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
