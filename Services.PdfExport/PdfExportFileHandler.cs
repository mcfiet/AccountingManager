using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Geom;
using Microsoft.Win32;

namespace De.HsFlensburg.ClientApp078.Services.PdfExport
{
    public class PdfExportFileHandler
    {
        public void PDFExport(Accounting accounting)
        {
            SaveFileDialog sfd = initSaveFileDianlog(accounting);
            Nullable<bool> result = sfd.ShowDialog();

            string dir = System.IO.Path.Combine(sfd.FileName);

            using (PdfWriter writer = new PdfWriter(dir))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf);
                    PageSize ps = pdf.GetDefaultPageSize();
                    Table layout, OfferDetails, Positions, details;
                    AddTables(out layout, out OfferDetails, out Positions, out details);

                    AddSenderReceiptBlock(accounting, layout);
                    AddHeaderContactDetails(OfferDetails);
                    AddOfferDetailsBlock(accounting, OfferDetails);

                    Cell offerDetailsCell = new Cell(1, 1)
                            .SetBorder(Border.NO_BORDER)
                            .Add(OfferDetails);

                    layout.AddCell(offerDetailsCell);
                    doc.Add(layout);

                    AddOfferNumberAndText(accounting, doc);
                    AddPositions(accounting, doc, Positions);
                    AddSignature(doc, accounting);
                    AddFooterCompanyDetails(details);
                    details.SetFixedPosition(doc.GetLeftMargin(), doc.GetBottomMargin(), ps.GetWidth() - doc.GetLeftMargin() - doc.GetRightMargin());
                    doc.Add(details);
                }
            }
        }

        private static bool isOffer(Accounting accounting)
        {
            return accounting.GetType() == typeof(Offer);
        }
        private static bool isOrder(Accounting accounting)
        {
            return accounting.GetType() == typeof(Order);
        }
        private static bool isInvoice(Accounting accounting)
        {
            return accounting.GetType() == typeof(Invoice);
        }

        private static SaveFileDialog initSaveFileDianlog(Accounting accounting)
        {
            string fileName = getFileName(accounting);
            return new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = fileName,
                DefaultExt = ".pdf",
                Filter = "PDF (.pdf)|*.pdf",
                Title = "Speichern unter"
            };
        }

        private static string getFileName(Accounting accounting)
        {
            if (isOffer(accounting))
            {
                return ((Offer)accounting).OfferNr;
            }
            if (isInvoice(accounting))
            {
                return ((Invoice)accounting).InvoiceNr;
            }
            if (isOrder(accounting))
            {
                return ((Order)accounting).OrderNr;
            }

            return "";
        }

        private static void AddTables(out Table layout, out Table OfferDetails, out Table Positions, out Table details)
        {
            layout = new Table(2, false);
            OfferDetails = new Table(2, false);
            Positions = new Table(5, false);
            details = new Table(3, false);
        }

        private static void AddOfferNumberAndText(Accounting accounting, Document doc)
        {
            if(isOffer(accounting))
            {
                doc.Add(new Paragraph(new Text("Angebot Nr. " + ((Offer)accounting).OfferNr)).SetBold());

            }
            if(isOrder(accounting))
            {
                doc.Add(new Paragraph(new Text("Auftrag Nr. " + ((Order)accounting).OrderNr)).SetBold());

            }
            if(isInvoice(accounting))
            {
                doc.Add(new Paragraph(new Text("Rechnung Nr. " + ((Invoice)accounting).InvoiceNr)).SetBold());

            }

            doc.Add(new Paragraph(new Text(accounting.Text)));
        }

        private static void AddSignature(Document doc, Accounting accounting)
        {
            if (isInvoice(accounting))
            {
                doc.Add(new Paragraph(new Text("Bitte überweisen Sie den Rechnungsbetrag innerhalb von 14 Tagen. Vielen Dank für Ihren Auftrag.")));
            }
            doc.Add(new Paragraph(new Text("Mit freundlichen Grüßen")));
            doc.Add(new Paragraph(new Text("Fiete Scheel")));
        }

        private static void AddFooterCompanyDetails(Table details)
        {
            AddCompanyDetails(details);
            AddCompanyFinances(details);
            AddCompanyContacts(details);
        }

        private static void AddCompanyContacts(Table details)
        {
            Cell companyContacts = new Cell(1, 1)
                .SetBorder(Border.NO_BORDER)
                .SetFontSize(8)
                .Add(new Paragraph("E-Mail: info@devoniq.de"))
                .Add(new Paragraph("Internet: www.example.de"))
                .Add(new Paragraph("Telefon: +49 151 75 28 93"))
                .Add(new Paragraph("Telefax: +49 151 75 28 93"));

            details.AddCell(companyContacts);
        }

        private static void AddCompanyFinances(Table details)
        {
            Cell companyFinances = new Cell(1, 1)
                            .SetBorder(Border.NO_BORDER)
                            .SetFontSize(8)
                            .Add(new Paragraph("Bank: Musterbank Musterstadt"))
                            .Add(new Paragraph("IBAN: DE123450000067890"))
                            .Add(new Paragraph("USt-ID Nr. DE-123456789"))
                            .Add(new Paragraph("HRB-Nr. 987654"));

            details.AddCell(companyFinances);
        }

        private static void AddCompanyDetails(Table details)
        {
            Cell companyDetails = new Cell(1, 1)
                                                .SetBorder(Border.NO_BORDER)
                                                .SetFontSize(8)
                                                .Add(new Paragraph("DEVONIQ"))
                                                .Add(new Paragraph("Geschäftsführer: Fiete Scheel"))
                                                .Add(new Paragraph("Lüdemannstraße 47"))
                                                .Add(new Paragraph("24114 Kiel"));

            details.AddCell(companyDetails);
        }

        private static void AddPositions(Accounting accounting, Document doc, Table Positions)
        {
            Positions.SetMarginTop(5);
            AddOfferItemsTableHaders(Positions);
            AddOfferItemsTableValues(accounting, Positions);

            doc.Add(Positions);
        }

        private static void AddOfferItemsTableValues(Accounting accounting, Table Positions)
        {
            foreach (Position item in accounting.Positions)
            {

                Cell offerItemNumber = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.PositionNr.ToString())));

                Cell article = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.Article.Name)));

                Cell quantity = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.Quantity.ToString())));

                Cell articlePrice = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.Article.Price.ToString())));

                Cell totalPrice = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.TotalPrice.ToString())));

                Positions.AddCell(offerItemNumber);
                Positions.AddCell(article);
                Positions.AddCell(quantity);
                Positions.AddCell(articlePrice);
                Positions.AddCell(totalPrice);
            }
        }

        private static void AddOfferItemsTableHaders(Table Positions)
        {
            Cell offerItemsDes = new Cell(1, 1)
                                                    .Add(new Paragraph("Positionsnr."));
            Cell articlesDes = new Cell(1, 1)
                    .Add(new Paragraph("Artikel"));

            Cell quantityDes = new Cell(1, 1)
                    .Add(new Paragraph("Anzahl"));

            Cell articlePriceDes = new Cell(1, 1)
                    .Add(new Paragraph("Einzelpreis"));

            Cell totalPriceDes = new Cell(1, 1)
                    .Add(new Paragraph("Gesamtpreis"));

            Positions.AddCell(offerItemsDes);
            Positions.AddCell(articlesDes);
            Positions.AddCell(quantityDes);
            Positions.AddCell(articlePriceDes);
            Positions.AddCell(totalPriceDes);
        }

        private static void AddOfferDetailsBlock(Accounting accounting, Table OfferDetails)
        {
            Cell offerDetailsDes = new Cell(1, 1)
                                    .SetBorder(Border.NO_BORDER)
                                    .SetBold()
                                    .Add(new Paragraph("Kundennummer: "))
                                    .Add(new Paragraph("Datum: "))
                                    .Add(new Paragraph("Betreff: "));

            OfferDetails.AddCell(offerDetailsDes);

            Cell offerDetailsValue = new Cell(1, 1)
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph(accounting.Client.Id.ToString()))
                .Add(new Paragraph(accounting.Date.ToString("dd.MM.yyyy")))
                .Add(new Paragraph(accounting.Reference));

            OfferDetails.AddCell(offerDetailsValue);
        }

        private static void AddHeaderContactDetails(Table OfferDetails)
        {
            Cell cell11 = new Cell(1, 2)
                                    .SetBorder(Border.NO_BORDER)
                                    .Add(new Paragraph("DEVONIQ")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Lüdemannstraße 47")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("24114 Kiel")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("Telefon: +49 151 51 75 28 93")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("E-Mail: info@devoniq.de")).SetTextAlignment(TextAlignment.RIGHT)
                                    .Add(new Paragraph("")).SetTextAlignment(TextAlignment.RIGHT);

            OfferDetails.AddCell(cell11);
        }

        private static void AddSenderReceiptBlock(Accounting accounting, Table layout)
        {
            Cell Client = new Cell(1, 1)
                                    .SetBorder(Border.NO_BORDER)
                                    .Add(new Paragraph("DEVONIQ" + " · " + "Lüdemannstraße 47" + " · " + "24114 Kiel").SetFontSize(8))
                                    .Add(new Paragraph(accounting.Client.Name))
                                    .Add(new Paragraph(accounting.Client.Street + " " + accounting.Client.HouseNumber))
                                    .Add(new Paragraph(accounting.Client.ZipCode + " " + accounting.Client.City));

            layout.AddCell(Client);
        }
    }
}
