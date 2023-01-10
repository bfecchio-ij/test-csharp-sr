using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Vo;

namespace InfoJobsPoc.Core.Entities
{
    public class Candidate : EntityBase<Candidate>
    {
        public Candidate(string Name, string Surname, DateTime Birthdate, string Email, ICollection<Experience> experiences)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Birthdate = Birthdate;
            this.Email = Email;
            Experiences = experiences;
        }
        public Candidate(string Name, string Surname, DateTime Birthdate, string Email)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Birthdate = Birthdate;
            this.Email = Email;
            Experiences = new List<Experience>();
        }

        public Candidate()
        {
        }

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public DateTime Birthdate { get; set; } = new DateTime(1, 1, 1);

        public string Email { get; set; } = "";

        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();

        public override ResultNormalized<Candidate> Validate()
        {

            var notifications = new ResultNormalized<Candidate>()
            {
                KeyPattern = typeof(Candidate).Name,
                Data = this
            };

            if (string.IsNullOrWhiteSpace(Name?.Trim())) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Name", "required"));
            if (string.IsNullOrEmpty(Surname?.Trim())) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Surname", "required"));
            if (Birthdate.Date.Year < 1000) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Birthdate", "invalid"));
            if (!EmailVo.IsValid(Email ?? "")) notifications.Messages.Add(new Notify(StatusEnum.Invalid, "Email", "invalid"));
            foreach (var item in Experiences)
            {
                var retvalidate = item.Validate();
                notifications.Messages.AddRange(retvalidate.Messages);
            }
            return notifications;
        }
    }
}
