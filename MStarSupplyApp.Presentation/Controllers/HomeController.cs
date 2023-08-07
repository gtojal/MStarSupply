using Microsoft.AspNetCore.Mvc;
using MStarSupplyApp.Data.Repositories;
using MStarSupplyApp.Presentation.Models.Movimentacao;

namespace MStarSupplyApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new GraficoViewModel 
            { 
            };

            try
            {
                var movimentacaoRepository = new MovimentacaoRepository();
                var dadosGrafico = movimentacaoRepository.RecuperarDadosGrafico();

                //var model = new GraficoViewModel
                //{
                //    Mes = dadosGrafico.Select(s => s.Mes),
                //    QuantidadeEntrada = DateTime.Now.Year,
                //    QuantidadeSaida = DateTime.Now.Year,
                //};

                ViewBag.Mes = dadosGrafico.Select(s => s.Mes); 
                ViewBag.QuantidadeEntrada = dadosGrafico.Select(s => s.QuantidadeEntrada);
                ViewBag.QuantidadeSaida = dadosGrafico.Select(s => s.QuantidadeSaida);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }
    }
}