using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MStarSupplyApp.Data.Entities;
using MStarSupplyApp.Data.Enums;
using MStarSupplyApp.Data.Repositories;
using MStarSupplyApp.Presentation.Export;
using MStarSupplyApp.Presentation.Models.Movimentacao;

namespace MStarSupplyApp.Presentation.Controllers
{
    public class MovimentacoesController : Controller
    {
        public IActionResult Cadastro()
        {
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)));
            ViewBag.Mercadorias = RecuperarMercadorias();
         
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movimentacao = new Movimentacao
                    {
                        Id = Guid.NewGuid(),
                        DataHora = model.DataHora,
                        Quantidade = model.Quantidade,
                        Local = model.Local,
                        MercadoriaId = model.MercadoriaId,
                        Tipo = model.Tipo
                    };

                    var movimentacaoRepository = new MovimentacaoRepository();
                    movimentacaoRepository.Add(movimentacao);

                    TempData["Mensagem"] = $"A movimentação de {model.Tipo} foi cadastrada com sucesso!";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)));
            ViewBag.Mercadorias = RecuperarMercadorias();
            return View();
        }

        public IActionResult Consulta()
        {
            var model = new List<ConsultaViewModel>();

            try
            {
                var movimentacaoRepository = new MovimentacaoRepository();
                foreach (var item in movimentacaoRepository.GetAll())
                {
                    model.Add(new ConsultaViewModel
                    {
                        Id = item.Id,
                        DataHora = item.DataHora,
                        Local = item.Local,
                        NomeMercadoria = item.Mercadoria?.Nome,
                        Tipo = item.Tipo,
                        Quantidade = item.Quantidade
                    });
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        public IActionResult RelatorioPdf()
        {
            try
            {
                var movimentacaoRepository = new MovimentacaoRepository();
                var movimentacoes = movimentacaoRepository.GetAll();

                var export = new MovimentacoesExport();
                var relatorio = export.GerarPdf(movimentacoes);

                return File(relatorio, "application/pdf");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
                return RedirectToAction("Consulta");
            }
        }

        public IActionResult RelatorioExcel()
        {
            try
            {
                var movimentacaoRepository = new MovimentacaoRepository();
                var movimentacoes = movimentacaoRepository.GetAll();

                var export = new MovimentacoesExport();
                var relatorio = export.GerarExcel(movimentacoes);

                return File(relatorio, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
                return RedirectToAction("Consulta");
            }
        }

        private List<SelectListItem> RecuperarMercadorias()
        {
            var lista = new List<SelectListItem>();

            var mercadoriaRepository = new MercadoriaRepository();
            foreach (var item in mercadoriaRepository.GetAll())
            {
                lista.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Nome
                });
            }

            return lista;
        }

        [HttpGet]
        public JsonResult Grafico()
        {
            var movimentacaoRepository = new MovimentacaoRepository();
            var dadosGrafico = movimentacaoRepository.RecuperarDadosGrafico();

            return Json(dadosGrafico);
        }
    }
}
