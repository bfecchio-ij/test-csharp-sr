using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Validators;
using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum;
using Newtonsoft.Json;
using RestSharp;

namespace InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Api
{
    public static class CandidateExperienceHelper
    {
        public static IEnumerable<CandidateExperienceViewModel> ListByCandidate(string hostApi, int idCandidate)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/CandidateExperience/ListByCandidate/{idCandidate}", Method.Get)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var returnApi = servico.Execute(pedido).Validar();

                var lstCandidates = JsonConvert.DeserializeObject<IEnumerable<CandidateExperienceViewModel>>(returnApi.Content);
                return lstCandidates;
            }
            catch
            {
                throw;
            }
        }

        public static void AddCandidateExperience(string hostApi, CandidateExperienceViewModel candidateExperience)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/CandidateExperience/AddCandidateExperience", Method.Post)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddJsonBody(candidateExperience);
                servico.Execute(pedido).Validar();
            }
            catch
            {
                throw;
            }
        }

        public static CandidateExperienceViewModel GetCandidateExperience(string hostApi, int id)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/CandidateExperience/GetCandidateExperience/{id}", Method.Post)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var returnApi = servico.Execute(pedido).Validar();

                var oCandidate = JsonConvert.DeserializeObject<CandidateExperienceViewModel>(returnApi.Content);
                return oCandidate;
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateCandidateExperience(string hostApi, CandidateExperienceViewModel candidate)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/CandidateExperience/UpdateCandidateExperience", Method.Put)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddJsonBody(candidate);

                servico.Execute(pedido).Validar();
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteCandidateExperience(string hostApi, int id)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/CandidateExperience/DeleteCandidateExperience/{id}", Method.Delete)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                servico.Execute(pedido).Validar();
            }
            catch
            {
                throw;
            }
        }
    }
}