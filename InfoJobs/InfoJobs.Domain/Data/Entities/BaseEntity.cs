
namespace InfoJobs.Domain.Data.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime InsertDate { get; set; }

        public virtual DateTime? ModifyDate { get; set; }

    }
}
