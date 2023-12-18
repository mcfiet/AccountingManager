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

namespace Services.PdfExport
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

            //Nullable<bool> result = sfd.ShowDialog();

            string dir = System.IO.Path.Combine(sfd.FolderPath, sfd.FileName + sfd.DefaultExt);

            using (PdfWriter writer = new PdfWriter(dir))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf);
                    Text text = new Text(of.Date);


                    String logo = "DEVONIQ";


                    float col = 300f;
                    float[] colwidth = { col, col };

                    Table layout = new Table(2, false);
                    Table OfferDetails = new Table(2, false);

                    Cell Client = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph("DEVONIQ" + " · " + "Lüdemannstraße 47" + " · " + "24114 Kiel").SetFontSize(8))
                        .Add(new Paragraph(of.Client.Name))
                        .Add(new Paragraph("Firma"))
                        .Add(new Paragraph("Straße"))
                        .Add(new Paragraph("PLZ & ORT"));

                    layout.AddCell(Client);

                    Cell cell11 = new Cell(1, 2)
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph("DEVONIQ"))
                        .Add(new Paragraph("Lüdemannstraße 47"))
                        .Add(new Paragraph("24114 Kiel"))
                        .Add(new Paragraph(""))
                        .Add(new Paragraph("Telefon: +49 151 51 75 28 93"))
                        .Add(new Paragraph("E-Mail: info@devoniq.de"))
                        .Add(new Paragraph(""));

                    OfferDetails.AddCell(cell11);

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


                    Cell offerDetailsCell = new Cell(1, 1)
                            .SetBorder(Border.NO_BORDER)
                            .Add(OfferDetails);

                    layout.AddCell(offerDetailsCell);

                    doc.Add(layout);

                    doc.Add(new Paragraph(new Text("Angebot Nr. " + of.OfferNr)));

                    doc.Add(new Paragraph(new Text(of.Text)));

                    Table OfferItems = new Table(5, false);

                    OfferItems.SetMarginTop(5);

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

                    doc.Add(OfferItems);

                    doc.Add(new Paragraph(new Text("Bitte überweisen Sie den Rechnungsbetrag innerhalb von 14 Tagen. Vielen Dank für Ihren Auftrag.")));
                    doc.Add(new Paragraph(new Text("Mit freundlichen Grüßen")));
                    doc.Add(new Paragraph(new Text("Fiete Scheel")));

                    Table details = new Table(3, false);

                    Cell companyDetails = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetFontSize(8)
                        .Add(new Paragraph("DEVONIQ"))
                        .Add(new Paragraph("Geschäftsführer: Fiete Scheel"))
                        .Add(new Paragraph("Lüdemannstraße 47"))
                        .Add(new Paragraph("24114 Kiel"));

                    details.AddCell(companyDetails);

                    Cell companyFinances = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetFontSize(8)
                        .Add(new Paragraph("Bank: Musterbank Musterstadt"))
                        .Add(new Paragraph("IBAN: DE123450000067890"))
                        .Add(new Paragraph("USt-ID Nr. DE-123456789"))
                        .Add(new Paragraph("HRB-Nr. 987654"));

                    details.AddCell(companyFinances);

                    Cell companyContacts = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetFontSize(8)
                        .Add(new Paragraph("E-Mail: info@devoniq.de"))
                        .Add(new Paragraph("Internet: www.example.de"))
                        .Add(new Paragraph("Telefon: +49 151 75 28 93"))
                        .Add(new Paragraph("Telefax: +49 151 75 28 93"));

                    details.AddCell(companyContacts);

                    doc.Add(details);
                }
            }
        }
    }
}
