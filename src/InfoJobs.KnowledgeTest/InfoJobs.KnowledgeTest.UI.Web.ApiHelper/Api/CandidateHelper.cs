using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Validators;
using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum;
using Newtonsoft.Json;
using RestSharp;

namespace InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Api
{
    public static class CandidateHelper
    {
        public static IEnumerable<CandidateViewModel> ListCandidate(string hostApi)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/Candidate/ListCandidate", Method.Get)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var returnApi = servico.Execute(pedido).Validar();

                var lstCandidates = JsonConvert.DeserializeObject<IEnumerable<CandidateViewModel>>(returnApi.Content);
                return lstCandidates;
            }
            catch
            {
                throw;
            }
        }

        public static int AddCandidate(string hostApi, CandidateViewModel candidate)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/Candidate/AddCandidate", Method.Post)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddJsonBody(candidate);

                var returnApi = servico.Execute(pedido).Validar();

                var idCandidate = JsonConvert.DeserializeObject<int>(returnApi.Content);
                return idCandidate;
            }
            catch
            {
                throw;
            }
        }

        public static CandidateViewModel GetCandidate(string hostApi, int id)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/Candidate/GetCandidate/{id}", Method.Post)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var returnApi = servico.Execute(pedido).Validar();

                var oCandidate = JsonConvert.DeserializeObject<CandidateViewModel>(returnApi.Content);
                return oCandidate;
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateCandidate(string hostApi, CandidateViewModel candidate)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/Candidate/UpdateCandidate", Method.Put)
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

        public static void DeleteCandidate(string hostApi, int id)
        {
            try
            {
                var servico = new RestClient(hostApi);

                var pedido = new RestRequest($"/api/Candidate/DeleteCandidate/{id}", Method.Delete)
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