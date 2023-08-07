namespace MStarSupplyApp.Data.Entities
{
    public class Mercadoria
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public int? NumeroRegistro { get; set; }
        public string? Fabricante { get; set; }
        public string? Tipo { get; set; }
        public string? Descricao { get; set; }
        public List<Movimentacao>? Movimentacoes { get; set; }
    }
}