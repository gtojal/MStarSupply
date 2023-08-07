using MStarSupplyApp.Data.Enums;

namespace MStarSupplyApp.Presentation.Models.Movimentacao
{
    public class ConsultaViewModel
    {
        public Guid? Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Local { get; set; }
        public string? NomeMercadoria { get; set; }
        public TipoMovimentacao? Tipo { get; set; }
    }
}
