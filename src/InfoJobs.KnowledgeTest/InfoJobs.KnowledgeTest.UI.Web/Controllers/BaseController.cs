using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InfoJobs.KnowledgeTest.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IConfiguration _configuration;

        protected readonly string _hostWebApi;

        public BaseController() { }

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;

            _hostWebApi = configuration.GetSection("WebApis:UrlApi").Value;
        }

        public enum TipoMensagem
        {
            Sucesso,
            Erro,
            Alerta,
            Informacao
        }

        public void ExibirMensagem(string mensagem, TipoMensagem tipoMensagem)
        {
            if (TempData is null)
                return;

            if (!string.IsNullOrEmpty(mensagem))
            {
                switch (tipoMensagem)
                {
                    case TipoMensagem.Sucesso:

                        TempData.Remove("Sucesso");
                        TempData.Add("Sucesso", mensagem);
                        break;

                    case TipoMensagem.Erro:

                        TempData.Remove("Erro");
                        TempData.Add("Erro", mensagem);
                        break;

                    case TipoMensagem.Alerta:

                        TempData.Remove("Alerta");
                        TempData.Add("Alerta", mensagem);
                        break;

                    case TipoMensagem.Informacao:

                        TempData.Remove("Informacao");
                        TempData.Add("Informacao", mensagem);
                        break;
                }
            }
        }
    }
}
