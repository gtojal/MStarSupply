using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MStarSupplyApp.Data.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MStarSupplyApp.Presentation.Export
{
    public class MovimentacoesExport
    {
        public byte[] GerarPdf(List<Movimentacao> movimentacoes)
        {
            var memoryStream = new MemoryStream();

            memoryStream.Flush();
            memoryStream.Position = 0;

            //var pdf = new PdfDocument(new PdfWriter(memoryStream));

            var writer = new iText.Kernel.Pdf.PdfWriter(memoryStream);

            var pdf = new PdfDocument(writer);

            using (var document = new Document(pdf))
            {
                var title = new Paragraph("Relatório de Movimentações")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18)
                    .SetBold();

                var generatedAt = new Paragraph("Gerado em: " + System.DateTime.Now.ToString("dd/MM/yyyy H:mm"))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(12);

                var emptyLine = new Paragraph("\n");

                var table = new Table(5).UseAllAvailableWidth();

                var headerCell = new Cell().SetBackgroundColor(new DeviceRgb(169, 169, 169));
                headerCell.Add(new Paragraph("Data da Movimentação").SetBold());
                table.AddHeaderCell(headerCell);

                headerCell = new Cell().SetBackgroundColor(new DeviceRgb(169, 169, 169));
                headerCell.Add(new Paragraph("Nome da mercadoria").SetBold());
                table.AddHeaderCell(headerCell);

                headerCell = new Cell().SetBackgroundColor(new DeviceRgb(169, 169, 169));
                headerCell.Add(new Paragraph("Tipo de Movimentação").SetBold());
                table.AddHeaderCell(headerCell);

                headerCell = new Cell().SetBackgroundColor(new DeviceRgb(169, 169, 169));
                headerCell.Add(new Paragraph("Quantidade").SetBold());
                table.AddHeaderCell(headerCell);

                headerCell = new Cell().SetBackgroundColor(new DeviceRgb(169, 169, 169));
                headerCell.Add(new Paragraph("Local").SetBold());
                table.AddHeaderCell(headerCell);

                foreach (var item in movimentacoes)
                {
                    table.AddCell(item.DataHora?.ToString("dd/MM/yyyy HH:mm"));
                    table.AddCell(item.Mercadoria?.Nome);
                    table.AddCell(item.Tipo.ToString());
                    table.AddCell(item.Quantidade.ToString());
                    table.AddCell(item.Local);
                }

                document.Add(title);
                document.Add(generatedAt);
                document.Add(emptyLine);
                document.Add(table);
            }

            return memoryStream.ToArray();
        }

        public byte[] GerarExcel(List<Movimentacao> movimentacoes)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage())
            {
                var planilha = excelPackage.Workbook.Worksheets.Add("Movimentações");

                var titleCell = planilha.Cells["A1"];
                titleCell.Value = "Relatório de Movimentações";
                titleCell.Style.Font.Size = 18;
                titleCell.Style.Font.Bold = true;
                titleCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var generatedAtCell = planilha.Cells["A2"];
                generatedAtCell.Value = $"Gerado em: {System.DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
                generatedAtCell.Style.Font.Size = 12;
                generatedAtCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                planilha.Cells["A4"].Value = "Data da Movimentação";
                planilha.Cells["B4"].Value = "Nome da Mercadoria";
                planilha.Cells["C4"].Value = "Tipo de Movimentação";
                planilha.Cells["D4"].Value = "Quantidade";
                planilha.Cells["E4"].Value = "Local";

                var linha = 5;
                foreach (var item in movimentacoes)
                {
                    planilha.Cells[$"A{linha}"].Value = item.DataHora?.ToString("dd/MM/yyyy HH:mm");
                    planilha.Cells[$"B{linha}"].Value = item.Mercadoria?.Nome;
                    planilha.Cells[$"C{linha}"].Value = item.Tipo.ToString();
                    planilha.Cells[$"D{linha}"].Value = item.Quantidade;
                    planilha.Cells[$"E{linha}"].Value = item.Local;

                    linha++;
                }

                planilha.Cells["A:E"].AutoFitColumns();
                planilha.Cells["A1:E1"].Merge = true;
                planilha.Cells["A2:E2"].Merge = true;
                planilha.Cells["A4:E4"].Style.Font.Bold = true;
                planilha.Cells["A4:E4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                planilha.Cells["A4:E4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                return excelPackage.GetAsByteArray();
            }
        }
    }
}