namespace InfoJobsPoc.Application.Querys
{
    public abstract class QueryBase
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
