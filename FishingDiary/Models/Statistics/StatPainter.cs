//30.11.24
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using Avalonia.Media.Imaging;
using PDFiumSharp;
using PDFiumSharp.Types;
using iTextSharp.text.html;
using Avalonia.Controls;
using FishingDiary.Models.Statistics;

namespace FishingDiary.Models
{
    internal class StatPainter : IDisposable
    {
        private MemoryStream _StatStream = null;

        private double _CoefSize = 1.0;

        private float _FontSize;

        private int _CountColumn = 5;

        private string _FontName = "Times.ttf";

        private Font _Font;

        private iTextSharp.text.Font.FontFamily fontFamily = Font.FontFamily.TIMES_ROMAN;

        public StatPainter(float FontSize) 
        {
            _FontSize = FontSize;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Full path to the font file
            string FontTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), _FontName);

            // Create a base font object making sure to specify IDENTITY-H
            BaseFont baseFont = BaseFont.CreateFont(FontTtf, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Create a specific font object
            _Font = new Font(baseFont, _FontSize, Font.NORMAL);
        }

        public void PaintStat(StatisticsTimeMode timeMode, int Param)
        {
            _StatStream = new MemoryStream();

            // Create our document object
            var doc = new Document();

            doc.SetMargins(0, 0, 20, 20);

            // Bind PDF writer to document and stream
            PdfWriter writer = PdfWriter.GetInstance(doc, _StatStream);

            // Open document for writing
            doc.Open();

            // Add a page
            doc.NewPage();

            PdfPTable table = new PdfPTable(_CountColumn);

            float[] widths = new float[] { 2f, 7f, 5f, 10f, 4f };

            table.SetWidths(widths);

            // Header
            AddCell(table, CommonData.GenLanguages.StatWindow.sHeader, _CountColumn);

            //PdfPCell cell = new PdfPCell(new Phrase("Simple table",

            //  new iTextSharp.text.Font(fontFamily, _FontSize,

            //  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));

            //cell.BackgroundColor = new BaseColor(Color.Wheat);

            //cell.Padding = 5;

            //cell.Colspan = 3;

            //cell.HorizontalAlignment = Element.ALIGN_CENTER;

            //table.AddCell(cell);

            // Column headers
            AddCell(table, CommonData.GenLanguages.StatWindow.sNumber);
            AddCell(table, CommonData.GenLanguages.StatWindow.sFishName);
            AddCell(table, CommonData.GenLanguages.StatWindow.sQuantity);
            AddCell(table, CommonData.GenLanguages.StatWindow.sBaits);
            AddCell(table, CommonData.GenLanguages.StatWindow.sPercent);

            CalcStat calcStat = new CalcStat(timeMode, Param);
            calcStat.Calc();


            int Number = 1;
            foreach(StatFish fish in calcStat.Fishes)
            {
                AddCell(table, Number.ToString());
                AddCell(table, fish.Name);
                AddCell(table, fish.Quantity.ToString());
                AddCell(table, "???");
                AddCell(table, String.Format("{0:N2}", fish.Percent));
                Number++;
            }

            //table.AddCell("Col 1 Row 2");

            //table.AddCell("Col 2 Row 2");

            //table.AddCell("Col 3 Row 2");


            //cell = new PdfPCell(new Phrase("Col 2 Row 3"));

            //cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            //cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            //table.AddCell(cell);

            doc.Add(table);


            string GeneralData = String.Format("{0} {1}. {2} {3}.", 
                CommonData.GenLanguages.StatWindow.sAllReport, calcStat.ReportCount,
                CommonData.GenLanguages.StatWindow.sAllFishes, calcStat.TotalFishCount);
            Paragraph p = new Paragraph(new Phrase(GeneralData, _Font));
            p.Alignment = 1;
            doc.Add(p);


            doc.Close();

            writer.Close();
        }

        private void AddCell(PdfPTable table, string Text, int cosplan = 1)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, _Font));

            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cell.PaddingTop = 0f;
            cell.PaddingBottom = _FontSize / 2;

            cell.Colspan = cosplan;

            table.AddCell(cell);
        }

        public Bitmap GetImage()
        {
            using var pdfDocument = new PDFiumSharp.PdfDocument(_StatStream.GetBuffer());
            var firstPage = pdfDocument.Pages[0];

            using var pageBitmap = new PDFiumBitmap((int)(firstPage.Width * _CoefSize), (int)(firstPage.Height * _CoefSize), true);

            firstPage.Render(pageBitmap);

            //var imageJpgPath = Path.ChangeExtension(@"D:\Document.pdf", "jpg");
            var image = new Bitmap(pageBitmap.AsBmpStream());

            // Set the background to white, otherwise it's black.
            //image.Mutate(x => x.BackgroundColor(Rgba32.White));

            //image.Save(imageJpgPath, new JpegEncoder());

            return image;
        }

        public void Save()
        {
            if (_StatStream != null)
            {
                using (FileStream file = new FileStream("D:\\testStat.pdf", FileMode.Create))
                {
                    file.Write(_StatStream.GetBuffer());
                }
            }
        }

        public void Dispose()
        {
            _StatStream.Close();
            _StatStream = null;
        }
    }
}
