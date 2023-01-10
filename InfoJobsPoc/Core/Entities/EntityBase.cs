namespace InfoJobsPoc.Core.Entities
{
    public abstract class EntityBase<T>
    {

        public int Id { get; set; } = 0;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public abstract ResultNormalized<T> Validate();
    }
}
