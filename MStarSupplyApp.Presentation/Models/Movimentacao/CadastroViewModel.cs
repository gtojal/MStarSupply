using MStarSupplyApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApp.Presentation.Models.Movimentacao
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório - Informe a quantidade.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe a data e hora.")]
        public DateTime? DataHora { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe o local.")]
        public string? Local { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Selecione a mercadoria.")]
        public Guid? MercadoriaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Selecione o tipo.")]
        public TipoMovimentacao? Tipo { get; set; }
    }
}
