using DC.TesteCandidatos.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Domain.Queries
{
    public class ExperiencesGetAllQuery : IRequest<IEnumerable<CandidateExperiences>>
    {
    }
}
