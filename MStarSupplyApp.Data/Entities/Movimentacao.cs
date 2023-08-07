using MStarSupplyApp.Data.Enums;

namespace MStarSupplyApp.Data.Entities
{
    public class Movimentacao
    {
        public Guid? Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Local { get; set; }
        public Guid? MercadoriaId { get; set; }
        public TipoMovimentacao? Tipo { get; set; }
        public Mercadoria? Mercadoria { get; set; }
    }
}