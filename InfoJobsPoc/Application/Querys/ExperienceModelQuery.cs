namespace InfoJobsPoc.Application.Querys
{
    public class ExperienceModelQuery : QueryBase
    {
        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public float Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual CandidateModelQuery? Candidate { get; set; }

        public int IdCandidate { get; set; }
    }
}
