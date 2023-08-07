using MStarSupplyApp.Data.Contexts;
using MStarSupplyApp.Data.Entities;
using MStarSupplyApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MStarSupplyApp.Data.Dto;
using System.Globalization;

namespace MStarSupplyApp.Data.Repositories
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>
    {
        public override List<Movimentacao> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Movimentacao
                    .Include(m => m.Mercadoria)
                    .OrderByDescending(m => m.DataHora)
                    .ToList();
            }
        }

        public List<GraficoDTO> RecuperarDadosGrafico()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            var movimentacoes = 
                GetAll().OrderBy(o => o.DataHora)
                .GroupBy(g => new { g.DataHora.Value.Year, g.DataHora.Value.Month })
                .ToList();

            var dadosGrafico = new List<GraficoDTO>();

            foreach (var item in movimentacoes)
            {

                dadosGrafico.Add(new GraficoDTO 
                { 
                    Mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(item.Key.Month)),
                    QuantidadeEntrada = item.Where(s => s.Tipo == Enums.TipoMovimentacao.Entrada).Count(), 
                    QuantidadeSaida = item.Where(s => s.Tipo == Enums.TipoMovimentacao.Saida).Count()
                });
            }            

            return dadosGrafico;

        }

    }
}
