using MStarSupplyApp.Data.Enums;

namespace MStarSupplyApp.Presentation.Models.Movimentacao
{
    public class GraficoViewModel
    {
        public int? QuantidadeSaida { get; set; }
        public int? QuantidadeEntrada { get; set; }
        public string? Mes { get; set; }
    }
}
