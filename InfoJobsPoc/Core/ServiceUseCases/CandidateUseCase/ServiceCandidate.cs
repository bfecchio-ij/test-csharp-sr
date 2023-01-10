using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Core.Interfaces.IService;
using InfoJobsPoc.Core.ServiceUseCases.ServiceBase;

namespace InfoJobsPoc.Core.ServiceUseCases.CandidateUseCase
{
    public class ServiceCandidate : ServiceBase<Candidate>, IServiceBase<Candidate>
    {

        private readonly IRepositoryWriteBase<Candidate> repositoryWriteBase;

        public ServiceCandidate(IRepositoryWriteBase<Candidate> repositoryWriteBase) : base(repositoryWriteBase)
        {
            this.repositoryWriteBase = repositoryWriteBase ?? throw new ArgumentNullException(nameof(repositoryWriteBase));
        }

        public ResultNormalized<Candidate> Add(Candidate entity)
        {
            var notifications = new ResultNormalized<Candidate>()
            {
                KeyPattern = typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddCandidate)
            };
            try
            {
                var entityValidate = entity.Validate();

                if (entityValidate.Messages.Where(x => x.Status != StatusEnum.Ok).Count() > 0)
                {
                    notifications.Messages.AddRange(entityValidate.Messages.Select(x => new Notify(x.Status, entityValidate.KeyPattern + "." + x.Key, x.msg)));
                    notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceCandidate).Name + ".Add", "Invalid"));
                    return notifications;
                }

                var entityExist = Find(x => x.Email.Trim() == entity.Email.Trim());
                var retExist = entityExist.Count();
                if (retExist > 0)
                {
                    notifications.Messages.Add(new Notify(StatusEnum.AlreadyExists, typeof(ServiceCandidate).Name + ".Add", "Already Exists"));
                    notifications.Data = entityExist.First();
                    return notifications;
                }

                var retEntry = repositoryWriteBase.Add(entity);
                if (retEntry != null)
                {
                    notifications.Data = retEntry;
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceCandidate).Name + ".Add", "success"));
                }
            }
            catch (Exception e)
            {
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceCandidate).Name + ".Add", e.Message));
                return notifications;
            }
            return notifications;
        }

        public ResultNormalized<Candidate> Remove(int identity)
        {
            var notifications = new ResultNormalized<Candidate>()
            {
                KeyPattern = typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddCandidate)
            };
            try
            {
                var item = Find(x => x.Id == identity).ToList();
                if (item.Count() == 0)
                {
                    notifications.Messages.Clear();
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceCandidate).Name + ".Remove", "does not exist"));
                    return notifications;
                }

                repositoryWriteBase.Remove(item.First());

                notifications.Data = item.First();
                notifications.Messages.Clear();
                notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceCandidate).Name + ".Remove", "success"));
            }
            catch (Exception e)
            {
                notifications.Messages.Clear();
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceCandidate).Name + ".Remove", e.Message));
            }
            return notifications;
        }

        public ResultNormalized<Candidate> Update(Candidate entity)
        {
            string functionName = "Update";
            var notifications = new ResultNormalized<Candidate>()
            {
                KeyPattern = typeof(ServiceCandidate).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.UpdateCandidate)
            };
            try
            {

                var entityIsValid = ValidateEntity(entity, notifications, functionName);
                if (!entityIsValid) return notifications;

                var ExistInDb = Find(x => x.Email.Trim() == entity.Email.Trim() || x.Id > 0 && x.Id == entity.Id);
                if (ExistInDb.Count() == 0)
                {
                    notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceCandidate).Name + "." + functionName, "Does not exist"));
                    return notifications;
                }
                //
                var retExist = ExistInDb.First();
                retExist.Birthdate = entity.Birthdate;
                retExist.Surname = entity.Surname;
                retExist.Name = entity.Name;
                retExist.ModifyDate = DateTime.Now;
                var retEntry = repositoryWriteBase.Edit(retExist);
                //
                if (retEntry != null)
                {
                    notifications.Data = retEntry;
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceCandidate).Name + "." + functionName, "success"));
                }
            }
            catch (Exception e)
            {
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceCandidate).Name + "." + functionName, e.Message));
                return notifications;
            }
            return notifications;
        }

        private static bool ValidateEntity(Candidate entity, ResultNormalized<Candidate> notifications, string functionName)
        {
            var entityValidate = entity.Validate();

            if (entityValidate.Messages.Where(x => x.Status != StatusEnum.Ok).Count() > 0)
            {
                notifications.Messages.AddRange(entityValidate.Messages.Select(x => new Notify(x.Status, entityValidate.KeyPattern + "." + x.Key, x.msg)));
                notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceCandidate).Name + "." + functionName, "Invalid"));
                return false;
            }
            return true;
        }
    }
}
