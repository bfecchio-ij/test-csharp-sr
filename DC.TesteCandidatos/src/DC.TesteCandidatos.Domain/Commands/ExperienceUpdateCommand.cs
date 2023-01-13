using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Commands
{
    public class ExperienceUpdateCommand : IRequest<string>
    {
        public int IdExperience { get; set; }
        public String Company { get; set; }
        public String Job { get; set; }
        public String Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
