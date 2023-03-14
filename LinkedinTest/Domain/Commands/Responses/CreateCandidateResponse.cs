using LinkedinTest.Model;
using System.Collections.Generic;
using System;

namespace LinkedinTest.Domain.Commands.Responses
{
    public class CreateCandidateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        //public virtual ICollection<ExperienceModel> Experiences { get; set; }
    }
}
