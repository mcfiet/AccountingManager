using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.XmlBuilder
{
    public class XmlBuilder
    {
        public void ExportClientCollectionToXMLFile(ClientCollection clientCollection)
        {
            XmlWriter xmlWriter = getDir("clients");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("clients");

            foreach (Client client in clientCollection)
            {
                writeClient(xmlWriter, client);
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
        
        public void ExportArticleCollectionToXMLFile(ArticleCollection articleCollection)
        {
            XmlWriter xmlWriter = getDir("article");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("article");

            foreach (Article article in articleCollection)
            {
                writeArticle(xmlWriter, article);
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }


        private static XmlWriter getDir(string filename)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = filename,
                DefaultExt = ".xml",

                Filter = "XML (*.xml)|*.xml",
        };
            Nullable<bool> result = sfd.ShowDialog();
            string dir = sfd.FileName;
            XmlWriterSettings settings = WriterSettings();
            XmlWriter xmlWriter = XmlWriter.Create(dir, settings);
            return xmlWriter;
        }

        private static XmlWriterSettings WriterSettings()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            return settings;
        }

        private static void writeClient(XmlWriter xmlWriter, Client client)
        {
            xmlWriter.WriteStartElement("client");
            xmlWriter.WriteAttributeString("clientID", client.Id.ToString());
            writeElement(xmlWriter, "Name", client.Name);
            xmlWriter.WriteStartElement("Adresse");
            writeElement(xmlWriter, "Straße", client.Street);
            writeElement(xmlWriter, "Hausnummer", client.HouseNumber.ToString());
            writeElement(xmlWriter, "PLZ", client.ZipCode.ToString());
            writeElement(xmlWriter, "Ort", client.City);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }
        private static void writeArticle(XmlWriter xmlWriter, Article article)
        {
            xmlWriter.WriteStartElement("article");
            xmlWriter.WriteAttributeString("articleID", article.Id.ToString());
            writeElement(xmlWriter, "Name", article.Name);
            writeElement(xmlWriter, "Description", article.Description);
            writeElement(xmlWriter, "Price", article.Price.ToString());
            xmlWriter.WriteEndElement();
        }

        private static void writeElement (XmlWriter xmlWriter, string name, string value)
        {
            xmlWriter.WriteStartElement(name);
            xmlWriter.WriteString(value);
            xmlWriter.WriteEndElement();
        }
    }
}
