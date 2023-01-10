using InfoJobsPoc.Core.Entities;
using InfoJobsPoc.Core.Enums;
using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Core.Interfaces.IService;
using InfoJobsPoc.Core.ServiceUseCases.ServiceBase;

namespace InfoJobsPoc.Core.ServiceUseCases.ExperienceUseCase
{
    public class ServiceExperience : ServiceBase<Experience>, IServiceBase<Experience>
    {
        private readonly IRepositoryWriteBase<Experience> repositoryWriteBase;
        private readonly IRepositoryWriteBase<Candidate> repositoryCandidate;
        public ServiceExperience(IRepositoryWriteBase<Experience> repositoryWriteBase, IRepositoryWriteBase<Candidate> repositoryCandidate
) : base(repositoryWriteBase)
        {
            this.repositoryWriteBase = repositoryWriteBase;
            this.repositoryCandidate= repositoryCandidate;
        }

        public ResultNormalized<Experience> Add(Experience entity)
        {
            var notifications = new ResultNormalized<Experience>()
            {
                KeyPattern = typeof(ServiceExperience).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddExperience)
            };
            try
            {
                var entityValidate = entity.Validate();

                if (entityValidate.Messages.Where(x => x.Status != StatusEnum.Ok).Count() > 0)
                {
                    notifications.Messages.AddRange(entityValidate.Messages.Select(x => new Notify(x.Status, entityValidate.KeyPattern + "." + x.Key, x.msg)));
                    notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceExperience).Name + ".Add", "Invalid"));
                    return notifications;
                }

                var entityExist = repositoryCandidate.List().Where(x => x.Id == entity.IdCandidate);
                var retExist = entityExist.Count();
                if (retExist == 0)
                {
                    notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceExperience).Name + ".Add", "candidate does not exist"));
                    notifications.Data = entity;
                    return notifications;
                }

                var retEntry = repositoryWriteBase.Add(entity);
                if (retEntry != null)
                {
                    notifications.Data = retEntry;
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceExperience).Name + ".Add", "success"));
                }
            }
            catch (Exception e)
            {
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceExperience).Name + ".Add", e.Message));
                return notifications;
            }
            return notifications;
        }

        public ResultNormalized<Experience> Remove(int identity)
        {
            var notifications = new ResultNormalized<Experience>()
            {
                KeyPattern = typeof(ServiceExperience).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.AddExperience)
            };
            try
            {
                var item = Find(x => x.Id == identity).ToList();
                if (item.Count() == 0)
                {
                    notifications.Messages.Clear();
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceExperience).Name + ".Remove", "does not exist"));
                    return notifications;
                }

                repositoryWriteBase.Remove(item.First());

                notifications.Data = item.First();
                notifications.Messages.Clear();
                notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceExperience).Name + ".Remove", "success"));
            }
            catch (Exception e)
            {
                notifications.Messages.Clear();
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceExperience).Name + ".Remove", e.Message));
            }
            return notifications;
        }

        public ResultNormalized<Experience> Update(Experience entity)
        {
            string functionName = "Update";
            var notifications = new ResultNormalized<Experience>()
            {
                KeyPattern = typeof(ServiceExperience).Name + "." + Enum.GetName(typeof(UseCaseEnums), UseCaseEnums.UpdateExperience)
            };
            try
            {

                var entityIsValid = ValidateEntity(entity, notifications, functionName);
                if (!entityIsValid) return notifications;

                var ExistInDb = Find(x => x.Id == entity.Id).ToList();
                if (ExistInDb.Count() == 0)
                {
                    notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceExperience).Name + "." + functionName, "Does not exist"));
                    return notifications;
                }
                //
                var retExist = ExistInDb.First();
                retExist.Company = entity.Company;
                retExist.Job = entity.Job;
                retExist.Description = entity.Description;
                retExist.Salary = entity.Salary;
                retExist.BeginDate = entity.BeginDate;
                retExist.EndDate = entity.EndDate;
                retExist.ModifyDate = DateTime.Now;
                var retEntry = repositoryWriteBase.Edit(retExist);
                //
                if (retEntry != null)
                {
                    notifications.Data = retEntry;
                    notifications.Messages.Add(new Notify(StatusEnum.Ok, typeof(ServiceExperience).Name + "." + functionName, "success"));
                }
            }
            catch (Exception e)
            {
                notifications.Messages.Add(new Notify(StatusEnum.Error, typeof(ServiceExperience).Name + "." + functionName, e.Message));
                return notifications;
            }
            return notifications;
        }
        private static bool ValidateEntity(Experience entity, ResultNormalized<Experience> notifications, string functionName)
        {
            var entityValidate = entity.Validate();

            if (entityValidate.Messages.Where(x => x.Status != StatusEnum.Ok).Count() > 0)
            {
                notifications.Messages.AddRange(entityValidate.Messages.Select(x => new Notify(x.Status, entityValidate.KeyPattern + "." + x.Key, x.msg)));
                notifications.Messages.Add(new Notify(StatusEnum.Invalid, typeof(ServiceExperience).Name + "." + functionName, "Invalid"));
                return false;
            }
            return true;
        }
    }
}
