using InfoJobsPoc.Core.Enums;

namespace InfoJobsPoc.Core.Entities
{
    public record Notify(StatusEnum Status, string Key, string msg);

    public class ResultNormalized<T>
    {
        public string KeyPattern { get; set; } = "";
        public List<Notify> Messages { get; set; } = new List<Notify>();
        public T? Data { get; set; }

        public StatusEnum Status() => Messages.Where(x => x.Status != StatusEnum.Ok).Select(x => x.Status).ToList().Count() > 0 ? StatusEnum.Error : StatusEnum.Ok;
    }
}
