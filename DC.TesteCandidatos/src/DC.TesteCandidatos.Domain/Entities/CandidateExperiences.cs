using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Entities
{
    public class CandidateExperiences
    {
        [Key]
        public int IdCandidateExperiences { get; set; }
        public int IdCandidate { get; set; }

        [MaxLength(150)]
        public String Company { get; set; } = string.Empty;

        [MaxLength(150)]
        public String Job { get; set; } = string.Empty;

        [MaxLength(4000)]
        public String Description { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
