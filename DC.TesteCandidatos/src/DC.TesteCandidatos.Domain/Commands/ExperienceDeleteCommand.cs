using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Commands
{
    public class ExperienceDeleteCommand : IRequest<String>
    {
        public int IdExperience { get; set; }
    }
}
