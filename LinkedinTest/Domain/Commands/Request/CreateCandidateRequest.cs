using LinkedinTest.Model;
using System.Collections.Generic;
using System;
using MediatR;

namespace LinkedinTest.Domain.Commands.Request
{
    public class CreateCandidateRequest : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        //public DateTime InsertDate { get; set; }
        //public DateTime ModifyDate { get; set; }

        //public virtual ICollection<ExperienceModel> Experiences { get; set; }
    }
}
