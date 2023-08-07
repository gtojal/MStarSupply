using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApp.Presentation.Models.Mercadoria
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório - Informe o nome da mercadoria.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe o número de registro.")]
        public int? NumeroRegistro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe o fabricante.")]
        public string? Fabricante { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe o tipo da mercadoria.")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório - Informe a descrição da mercadoria.")]
        public string? Descricao { get; set; }
    }
}
