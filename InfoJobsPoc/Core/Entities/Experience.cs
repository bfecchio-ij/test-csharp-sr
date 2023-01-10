using InfoJobsPoc.Core.Enums;

namespace InfoJobsPoc.Core.Entities
{
    public class Experience : EntityBase<Experience>
    {
        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public float Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int IdCandidate { get; set; }
        public virtual Candidate Candidate { get; set; }

        public override ResultNormalized<Experience> Validate()
        {
            var notifications = new ResultNormalized<Experience>();

            if (string.IsNullOrEmpty(Company?.Trim())) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Company", "required"));
            if (string.IsNullOrEmpty(Job?.Trim())) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Job", "required"));
            if (string.IsNullOrEmpty(Description?.Trim())) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Description", "required"));
            if (Salary <= 0.0) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Salary", "invalid"));
            if (IdCandidate < 0) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "IdCandidate", "invalid"));
            if (BeginDate.Date.Year <= 1) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "BeginDate", "invalid"));

            notifications.KeyPattern = typeof(Experience).Name;
            notifications.Data = this;
            return notifications;
        }
    }
}
