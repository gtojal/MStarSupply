using Microsoft.AspNetCore.Mvc;
using MStarSupplyApp.Data.Entities;
using MStarSupplyApp.Data.Repositories;
using MStarSupplyApp.Presentation.Models.Mercadoria;

namespace MStarSupplyApp.Presentation.Controllers
{
    public class MercadoriasController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mercadoria = new Mercadoria
                    {
                        Id = Guid.NewGuid(),
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Fabricante = model.Fabricante,
                        NumeroRegistro = model.NumeroRegistro,
                        Tipo = model.Tipo
                    };

                    var mercadoriaRepository = new MercadoriaRepository();
                    mercadoriaRepository.Add(mercadoria);

                    TempData["Mensagem"] = "Mercadoria cadastrada com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Consulta()
        {
            var model = new List<ConsultaViewModel>();

            try
            {
                var mercadoriaRepository = new MercadoriaRepository();
                foreach (var item in mercadoriaRepository.GetAll())
                {
                    model.Add(new ConsultaViewModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Fabricante = item.Fabricante,
                        NumeroRegistro = item.NumeroRegistro,
                        Tipo = item.Tipo
                    });
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }
    }
}
