using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace InfoJobs.KnowledgeTest.UI.Web.ApiHelper.Validators
{
    public static class RestResponseValidator
    {
        public static RestResponse Validar(this RestResponse restResponse)
        {
            if (restResponse.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException(restResponse.ErrorMessage ?? JsonConvert.DeserializeObject<string>(restResponse.Content));

            return restResponse;
        }
    }
}