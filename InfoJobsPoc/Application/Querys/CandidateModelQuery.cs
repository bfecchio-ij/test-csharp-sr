namespace InfoJobsPoc.Application.Querys
{
    public class CandidateModelQuery : QueryBase
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthdate { get; set; }


        public string Email { get; set; }


        public ICollection<ExperienceModelQuery>? Experiences { get; set; }
    }
}
