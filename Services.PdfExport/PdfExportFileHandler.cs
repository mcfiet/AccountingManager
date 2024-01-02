using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Events;
using iText.Kernel.Geom;

namespace De.HsFlensburg.ClientApp078.Services.PdfExport
{
    public class PdfExportFileHandler
    {
        public void PDFExport(Offer of)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "Offer",
                DefaultExt = ".pdf",
                Filter = "PDF (.pdf)|*.pdf"
            };

            string dir = System.IO.Path.Combine(sfd.FolderPath, sfd.FileName + sfd.DefaultExt);

            using (PdfWriter writer = new PdfWriter(dir))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf);
                    Text text = new Text(of.Date);
                    PageSize ps = pdf.GetDefaultPageSize();
                    Table layout, OfferDetails, OfferItems, details;
                    AddTables(out layout, out OfferDetails, out OfferItems, out details);

                    AddSenderReceiptBlock(of, layout);
                    AddHeaderContactDetails(OfferDetails);
                    AddOfferDetailsBlock(of, OfferDetails);

                    Cell offerDetailsCell = new Cell(1, 1)
                            .SetBorder(Border.NO_BORDER)
                            .Add(OfferDetails);

                    layout.AddCell(offerDetailsCell);
                    doc.Add(layout);

                    AddOfferNumberAndText(of, doc);
                    AddOfferItems(of, doc, OfferItems);
                    AddSignature(doc);
                    AddFooterCompanyDetails(details);
                    details.SetFixedPosition(doc.GetLeftMargin(), doc.GetBottomMargin(), ps.GetWidth() - doc.GetLeftMargin() - doc.GetRightMargin());
                    doc.Add(details);
                }
            }
        }

        private static void AddTables(out Table layout, out Table OfferDetails, out Table OfferItems, out Table details)
        {
            layout = new Table(2, false);
            OfferDetails = new Table(2, false);
            OfferItems = new Table(5, false);
            details = new Table(3, false);
        }

        private static void AddOfferNumberAndText(Offer of, Document doc)
        {
            doc.Add(new Paragraph(new Text("Angebot Nr. " + of.OfferNr)));

            doc.Add(new Paragraph(new Text(of.Text)));
        }

        private static void AddSignature(Document doc)
        {
            doc.Add(new Paragraph(new Text("Bitte überweisen Sie den Rechnungsbetrag innerhalb von 14 Tagen. Vielen Dank für Ihren Auftrag.")));
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

        private static void AddOfferItems(Offer of, Document doc, Table OfferItems)
        {
            OfferItems.SetMarginTop(5);
            AddOfferItemsTableHaders(OfferItems);
            AddOfferItemsTableValues(of, OfferItems);

            doc.Add(OfferItems);
        }

        private static void AddOfferItemsTableValues(Offer of, Table OfferItems)
        {
            foreach (OfferItem item in of.OfferItems)
            {

                Cell offerItemNumber = new Cell(1, 1)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph(new Text(item.OfferItemNr.ToString())));

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

                OfferItems.AddCell(offerItemNumber);
                OfferItems.AddCell(article);
                OfferItems.AddCell(quantity);
                OfferItems.AddCell(articlePrice);
                OfferItems.AddCell(totalPrice);
            }
        }

        private static void AddOfferItemsTableHaders(Table OfferItems)
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

            OfferItems.AddCell(offerItemsDes);
            OfferItems.AddCell(articlesDes);
            OfferItems.AddCell(quantityDes);
            OfferItems.AddCell(articlePriceDes);
            OfferItems.AddCell(totalPriceDes);
        }

        private static void AddOfferDetailsBlock(Offer of, Table OfferDetails)
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
                .Add(new Paragraph(of.Client.Id.ToString()))
                .Add(new Paragraph(of.Date))
                .Add(new Paragraph(of.Reference));

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

        private static void AddSenderReceiptBlock(Offer of, Table layout)
        {
            Cell Client = new Cell(1, 1)
                                    .SetBorder(Border.NO_BORDER)
                                    .Add(new Paragraph("DEVONIQ" + " · " + "Lüdemannstraße 47" + " · " + "24114 Kiel").SetFontSize(8))
                                    .Add(new Paragraph(of.Client.Name))
                                    .Add(new Paragraph("Firma"))
                                    .Add(new Paragraph("Straße"))
                                    .Add(new Paragraph("PLZ & ORT"));

            layout.AddCell(Client);
        }
    }
}
