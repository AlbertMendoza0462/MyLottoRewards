using MyLotoRewards.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MyLotoRewards.BLL.Reports
{
    public class TicketsReport : PdfFooterPart
    {
        PdfWriter _pdfWriter;
        Document _document;
        MemoryStream _memoryStream = new MemoryStream();

        public byte[] Report(List<Tickets> tickets)
        {
            // _productos = productos;
            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);

            _pdfWriter = PdfWriter.GetInstance(_document, _memoryStream);
            _pdfWriter.PageEvent = new PdfFooterPart();

            _document.Open();

            Paragraph titlePricipal = new Paragraph();
            titlePricipal.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f);
            titlePricipal.Alignment = Element.ALIGN_CENTER;
            titlePricipal.Add("Reporte de Jugadas por Ticket");
            titlePricipal.SpacingAfter = 25;
            _document.Add(titlePricipal);

            Font fontHeader = new Font(Font.TIMES_ROMAN, 12, Font.BOLD, BaseColor.Black);
            Font fontNormal = new Font(Font.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.Black);

            //tabla detalle monto mensual
            PdfPTable tblLocal = new PdfPTable(5);
            tblLocal.WidthPercentage = 100;
            float[] widths = new float[] { 1.5f, 2f, 5f, 5f, 2f };
            tblLocal.SetWidths(widths);

            PdfPCell celda = new PdfPCell(new Phrase("TicketId", fontHeader));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase("Fecha", fontHeader));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase("Loteria", fontHeader));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase("Tipo de Jugada", fontHeader));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase("Monto", fontHeader));
            tblLocal.AddCell(celda);



            foreach (var _ticket in tickets)
            {
                foreach (var _jugada in _ticket.Jugadas)
                {
                    celda = new PdfPCell(new Phrase(_jugada.TicketId.ToString(), fontNormal));
                    tblLocal.AddCell(celda);

                    celda = new PdfPCell(new Phrase(_ticket.Fecha.ToString("dd/MM/yyyy"), fontNormal));
                    tblLocal.AddCell(celda);

                    celda = new PdfPCell(new Phrase(_jugada.LoteriaDescripcion, fontNormal));
                    tblLocal.AddCell(celda);

                    celda = new PdfPCell(new Phrase(_jugada.TipoJugadaDescripcion, fontNormal));
                    tblLocal.AddCell(celda);

                    celda = new PdfPCell(new Phrase(_jugada.Monto.ToString("C"), fontNormal));
                    celda.HorizontalAlignment = 2;
                    tblLocal.AddCell(celda);

                }
            }

            _document.Add(tblLocal);

            this.OnEndPage(_pdfWriter, _document);
            _document.Close();

            return _memoryStream.ToArray();
        }
    }
}
