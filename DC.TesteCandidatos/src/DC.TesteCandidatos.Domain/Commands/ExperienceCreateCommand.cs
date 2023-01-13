using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Commands
{
    public class ExperienceCreateCommand : IRequest<string>
    {
        public int IdCandidatos { get; set; }   
        public string Company { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
