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
using System.Linq;
using Avalonia;
using System.Reflection;
using static iTextSharp.text.pdf.AcroFields;

namespace FishingDiary.Models
{
    internal class StatPainter : IDisposable
    {
        private MemoryStream _StatStream = null;

        private double _CoefSize = 1.0;

        private float _FontSize;

        private const float MARGINS = 20f;

        private const int GENEGAL_COUNT_COLUMN = 6;
        private const int DATA_COUNT_COLUMN = 4;
        private const int METHOD_COUNT_COLUMN = 3;

        private const float WIDTH_NUMBER = 1.5f;
        private const float WIDTH_NAME = 10f;
        private const float WIDTH_BAIT = 10f;
        private const float WIDTH_METHOD = 10f;
        private const float WIDTH_QUANTITY = 4f;
        private const float WIDTH_LENGHT = 5f;



        private string _FontName = "Times.ttf";

        private Font _Font;

        private iTextSharp.text.Font.FontFamily fontFamily = Font.FontFamily.TIMES_ROMAN;


        // Page counter to display information about the current page
        private static PageCounter _PageCounter = null;

        public bool FirstPage => _PageCounter == null ? false : _PageCounter.FirstPage;
        public bool EndPage => _PageCounter == null ? false : _PageCounter.EndPage;

        public uint CurrentPage => _PageCounter == null ? 0 : _PageCounter.CurrentPage;
        public uint CountPages => _PageCounter == null ? 0 : _PageCounter.TotalPages;

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

            doc.SetMargins(MARGINS, MARGINS, MARGINS, MARGINS);

            // Bind PDF writer to document and stream
            PdfWriter writer = PdfWriter.GetInstance(doc, _StatStream);

            // Open document for writing
            doc.Open();

            // Add a page
            doc.NewPage();

            PdfPTable generalTable = new PdfPTable(GENEGAL_COUNT_COLUMN);

            float[] widths = new float[GENEGAL_COUNT_COLUMN] { WIDTH_NUMBER, WIDTH_NAME,
                WIDTH_BAIT, WIDTH_METHOD, WIDTH_QUANTITY, WIDTH_LENGHT };

            // Draw on the whole page
            generalTable.WidthPercentage = 100;
            generalTable.SetWidths(widths);

            // Header
            if (timeMode == StatisticsTimeMode.AllTime)
            {
                AddCell(generalTable, CommonData.GenLanguages.StatWindow.sHeader, GENEGAL_COUNT_COLUMN);
            }
            else
            {
                AddCell(generalTable, CommonData.GenLanguages.StatWindow.sHeaderYear + Param.ToString(), GENEGAL_COUNT_COLUMN);
            }


            // Column headers for General table
            AddCell(generalTable, CommonData.GenLanguages.StatWindow.sNumber);
            AddCell(generalTable, CommonData.GenLanguages.StatWindow.sFishName);
            AddCell(generalTable, CommonData.GenLanguages.StatWindow.sBaits);
            AddCell(generalTable, CommonData.GenLanguages.StatWindow.sMethod);
            AddCell(generalTable, CommonData.GenLanguages.StatWindow.sQuantity);
            AddCell(generalTable, String.Format("{0}, {1}",
                CommonData.GenLanguages.StatWindow.sAverageLenght,
                CommonData.GenLanguages.StatWindow.sCentimeter));

            CalcStat calcStat = new CalcStat(timeMode, Param);
            calcStat.Calc();


            int Number = 1;
            foreach (StatFish fish in calcStat.Fishes)
            {
                PdfPTable dataTable = new PdfPTable(DATA_COUNT_COLUMN);
                widths = new float[DATA_COUNT_COLUMN] { WIDTH_BAIT, WIDTH_METHOD, WIDTH_QUANTITY, WIDTH_LENGHT };
                dataTable.SetWidths(widths);

                // Column headers for Data table
                AddCell(dataTable, String.Format("{0}: {1:N2}", CommonData.GenLanguages.StatWindow.sPercent, fish.Percent));
                var currentRecord = calcStat.Records.FishRecords.Find(x => x.FishId == fish.Id);
                if (currentRecord != null)
                {
                    AddCell(dataTable, String.Format("{0}: {1} {2}", 
                        CommonData.GenLanguages.StatWindow.sRecord,
                        currentRecord.Length,
                        CommonData.GenLanguages.StatWindow.sCentimeter));
                }
                else
                {
                    AddCell(dataTable, CommonData.GenLanguages.StatWindow.sNothing);
                }
                AddCell(dataTable, fish.Quantity.ToString());

                if (fish.AverageLength != 0)
                {
                    AddCell(dataTable, String.Format("{0:N1}", fish.AverageLength));
                }
                else
                {
                    AddCell(dataTable, CommonData.GenLanguages.StatWindow.sNothing);
                }

                foreach (StatBait bait in fish.StatBaits)
                {
                    // Bait name
                    AddCell(dataTable, bait.Name);


                    PdfPTable methodTable = new PdfPTable(METHOD_COUNT_COLUMN);
                    widths = new float[METHOD_COUNT_COLUMN] { WIDTH_METHOD, WIDTH_QUANTITY, WIDTH_LENGHT };
                    methodTable.SetWidths(widths);


                    if (bait.StatMethods.Count > 1)
                    {
                        foreach (StatMethod method in bait.StatMethods)
                        {
                            AddCell(methodTable, method.Name);
                            AddCell(methodTable, method.Quantity.ToString());

                            if (method.AverageLength != 0)
                            {
                                AddCell(methodTable, string.Format("{0:N1}", method.AverageLength));
                            }
                            else
                            {
                                AddCell(methodTable, CommonData.GenLanguages.StatWindow.sNothing);
                            }
                        }
                        dataTable.AddCell(new PdfPCell(methodTable) { Colspan = METHOD_COUNT_COLUMN });
                    }
                    else
                    {
                        AddCell(dataTable, bait.StatMethods.First().Name);
                        AddCell(dataTable, bait.Quantity.ToString());

                        if (bait.AverageLength != 0)
                        {
                            AddCell(dataTable, String.Format("{0:N1}", bait.AverageLength));
                        }
                        else
                        {
                            AddCell(dataTable, CommonData.GenLanguages.StatWindow.sNothing);
                        }
                    }
                }

                AddCell(generalTable, Number.ToString());
                string FishData;
                if (fish.AverageLength != 0 && currentRecord.Length != 0 && fish.Quantity >= 10)
                {
                    FishData = String.Format("{0}\n{1} < {2:N1} {3}\n{2:N1} {3} ≤ {4} < {5:N1} {3}\n{7} ≥ {5:N1} {3}\n{7} ≥ {8:N1} {3}",
                        fish.Name,
                        CommonData.GenLanguages.StatWindow.sSmall,
                        fish.AverageLength,
                        CommonData.GenLanguages.StatWindow.sCentimeter,
                        CommonData.GenLanguages.StatWindow.sAverage,
                        fish.AverageLength + (currentRecord.Length - fish.AverageLength) / 3,
                        CommonData.GenLanguages.StatWindow.sGood,
                        CommonData.GenLanguages.StatWindow.sTrophy,
                        fish.AverageLength + (currentRecord.Length - fish.AverageLength) * 2 / 3
                        );
                }
                else
                {
                    FishData = fish.Name;
                }
                AddCell(generalTable, FishData);

                PdfPCell pdfPCell = new PdfPCell(dataTable)
                {
                    Colspan = 4
                };
                generalTable.AddCell(pdfPCell);

                Number++;
            }


            doc.Add(generalTable);


            string GeneralData = String.Format("{0} {1}. {2} {3}.",
                CommonData.GenLanguages.StatWindow.sAllReport, calcStat.ReportCount,
                CommonData.GenLanguages.StatWindow.sAllFishes, calcStat.TotalFishCount);
            Paragraph p = new Paragraph(new Phrase(GeneralData, _Font));
            p.Alignment = 1;
            doc.Add(p);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Records
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string Inscription;

            if (timeMode == StatisticsTimeMode.AllTime)
            {
                Inscription = CommonData.GenLanguages.StatWindow.sRecordHeader;
            }
            else
            {
                Inscription = CommonData.GenLanguages.StatWindow.sRecordHeaderYear + Param.ToString();
            }
            p = new Paragraph(new Phrase(Inscription, _Font));
            p.Alignment = 1;
            doc.Add(p);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Fish Records

            int index = 1;
            foreach (var record in calcStat.Records.FishRecords)
            {
                if (record.Weight != 0)
                {
                    Inscription = String.Format("{0}) {1} ({2}{3}) {4} {5} {6}, " +
                        "{7}, {8}, {9} {10} {11}, {12} {13} {14}",
                        index,
                        CommonData.EditableTexts.Fishes[record.FishId].Text,
                        record.Time.Year,
                        CommonData.GenLanguages.StatWindow.sStatisticYear,
                        record.Time.Date.ToString("dd-MM-yyyy"),
                        CommonData.GenLanguages.StatWindow.sStatisticCatching,
                        CommonData.EditableTexts.Baits[record.BaitId].Text,
                        CommonData.EditableTexts.Methods[record.MethodId].Text,
                        record.BodyOfWater,
                        CommonData.GenLanguages.StatWindow.sStatisticLenght,
                        record.Length,
                        CommonData.GenLanguages.StatWindow.sCentimeter,
                        CommonData.GenLanguages.StatWindow.sStatisticWeight,
                        record.Weight,
                        CommonData.GenLanguages.StatWindow.sGram);
                }
                else
                {
                    Inscription = String.Format("{0}) {1} ({2}{3}) {4} {5} {6}, " +
                        "{7}, {8}, {9} {10} {11}",
                        index,
                        CommonData.EditableTexts.Fishes[record.FishId].Text,
                        record.Time.Year,
                        CommonData.GenLanguages.StatWindow.sStatisticYear,
                        record.Time.Date.ToString("dd-MM-yyyy"),
                        CommonData.GenLanguages.StatWindow.sStatisticCatching,
                        CommonData.EditableTexts.Baits[record.BaitId].Text,
                        CommonData.EditableTexts.Methods[record.MethodId].Text,
                        record.BodyOfWater,
                        CommonData.GenLanguages.StatWindow.sStatisticLenght,
                        record.Length,
                        CommonData.GenLanguages.StatWindow.sCentimeter);
                }
                p = new Paragraph(new Phrase(Inscription, _Font));
                doc.Add(p);
                index++;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Fish Count Records
            Inscription = CommonData.GenLanguages.StatWindow.sStatisticFish;
            p = new Paragraph(new Phrase(Inscription, _Font));
            p.Alignment = 1;
            doc.Add(p);

            index = 1;
            foreach (var record in calcStat.Records.FishCountRecords)
            {
                Inscription = String.Format("{0}. {1}:",
                    index,
                    CommonData.EditableTexts.Fishes[record.Item1].Text);

                ViewRecords(doc, record.Item2.Items, Inscription);
                index++;
            }


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Variety Records
            ViewRecords(doc, calcStat.Records.VarietyRecords.Items, CommonData.GenLanguages.StatWindow.sStatisticVariety);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Quantity Records
            ViewRecords(doc, calcStat.Records.QuantityRecords.Items, CommonData.GenLanguages.StatWindow.sStatisticQuantity);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Nibble Records
            Inscription = CommonData.GenLanguages.StatWindow.sStatisticNibble;
            p = new Paragraph(new Phrase(Inscription, _Font));
            p.Alignment = 1;
            doc.Add(p);

            index = 1;
            foreach (var record in calcStat.Records.NibbleRecords.Items)
            {
                if (record.Count < 2)
                {
                    Inscription = String.Format("{0}) {1} ({2:N2} {3})",
                        index,
                        record.First().Date.Date.ToString("dd-MM-yyyy"),
                        record.First().Record,
                        CommonData.GenLanguages.StatWindow.sStatisticPcs);
                }
                else
                {
                    Inscription = String.Format("{0}) ", index);
                    foreach (var part in record)
                    {
                        if (part != record.Last())
                        {
                            Inscription += String.Format("{0}; ",
                                part.Date.Date.ToString("dd-MM-yyyy"));
                        }
                        else
                        {
                            Inscription += String.Format("{0} ",
                                part.Date.Date.ToString("dd-MM-yyyy"));
                        }
                    }
                    Inscription += String.Format("({0} {1:N2})",
                        record.First().Record,
                        CommonData.GenLanguages.StatWindow.sStatisticPcs);
                }
                p = new Paragraph(new Phrase(Inscription, _Font));
                doc.Add(p);
                index++;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Best days
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (timeMode == StatisticsTimeMode.AllTime)
            {
                Inscription = CommonData.GenLanguages.StatWindow.sBestDaysHeader;
            }
            else
            {
                Inscription = CommonData.GenLanguages.StatWindow.sBestDaysHeaderYear + Param.ToString();
            }
            p = new Paragraph(new Phrase(Inscription, _Font));
            p.Alignment = 1;
            doc.Add(p);


            index = 1;

            foreach (var day in calcStat.Records.BestDays)
            {
                Inscription = String.Format("{0}) {1} {2}:{3} {4}:{5} {6}:{7} {8}:{9})",
                    index,
                    day.Date.ToString("dd-MM-yyyy"),
                    CommonData.GenLanguages.StatWindow.sBestDaysFirst,
                    day.Record.FirstPlace,
                    CommonData.GenLanguages.StatWindow.sBestDaysSecond,
                    day.Record.SecondPlace,
                    CommonData.GenLanguages.StatWindow.sBestDaysThird,
                    day.Record.ThirdPlace,
                    CommonData.GenLanguages.StatWindow.sBestDaysAll,
                    day.Record.FirstPlace + day.Record.SecondPlace + day.Record.ThirdPlace);
                p = new Paragraph(new Phrase(Inscription, _Font));
                doc.Add(p);

                if (index >= 10)
                {
                    break;
                }
                index++;
            }


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

        private void ViewRecords(Document doc, List<List<RecordData<ushort>>> Items, string HeaderText)
        {
            string Inscription = HeaderText;
            Paragraph p = new Paragraph(new Phrase(Inscription, _Font));
            p.Alignment = 1;
            doc.Add(p);


            int index = 1;
            foreach (var record in Items)
            {
                if (record.Count < 2)
                {
                    Inscription = String.Format("{0}) {1} ({2} {3})",
                        index,
                        record.First().Date.Date.ToString("dd-MM-yyyy"),
                        record.First().Record,
                        CommonData.GenLanguages.StatWindow.sStatisticPcs);
                }
                else
                {
                    Inscription = String.Format("{0}) ", index);
                    foreach (var part in record)
                    {
                        if (part != record.Last())
                        {
                            Inscription += String.Format("{0}; ",
                                part.Date.Date.ToString("dd-MM-yyyy"));
                        }
                        else
                        {
                            Inscription += String.Format("{0} ",
                                part.Date.Date.ToString("dd-MM-yyyy"));
                        }
                    }
                    Inscription += String.Format("({0} {1})",
                        record.First().Record,
                        CommonData.GenLanguages.StatWindow.sStatisticPcs);
                }
                p = new Paragraph(new Phrase(Inscription, _Font));
                doc.Add(p);
                index++;
            }
        }

        public Bitmap GetImage(int NumberPage = 0, bool FirstPaint = true)
        {
            using var pdfDocument = new PDFiumSharp.PdfDocument(_StatStream.GetBuffer());

            // an attempt to draw something that does not exist
            if (NumberPage >= pdfDocument.Pages.Count)
            {
                return null;
            }

            var page = pdfDocument.Pages[NumberPage];

            if (FirstPaint)
            {
                // Create PageCounter
                _PageCounter = new PageCounter((uint)pdfDocument.Pages.Count, 1);
            }

            using var pageBitmap = new PDFiumBitmap((int)(page.Width * _CoefSize), (int)(page.Height * _CoefSize), true);

            page.Render(pageBitmap);

            //var imageJpgPath = Path.ChangeExtension(@"D:\Document.pdf", "jpg");
            var image = new Bitmap(pageBitmap.AsBmpStream());

            // Set the background to white, otherwise it's black.
            //image.Mutate(x => x.BackgroundColor(Rgba32.White));

            //image.Save(imageJpgPath, new JpegEncoder());

            return image;
        }

        //ViewFunctions
        public void SetPage(uint NumberPage)
        {
            if (_PageCounter != null)
            {
                _PageCounter.SetPage(NumberPage);
            }
        }

        public Bitmap IncrementPage()
        {
            Bitmap bitmap = GetImage((int)CurrentPage, false);
            _PageCounter.IncrementPage();
            return bitmap;

        }

        public Bitmap DecrementPage()
        {
            _PageCounter.DecrementPage();
            return GetImage((int)CurrentPage - 1, false);
        }


        public MemoryStream GetStream()
        {
            return _StatStream;
        }

        public void Dispose()
        {
            _StatStream.Close();
            _StatStream = null;
        }
    }
}
