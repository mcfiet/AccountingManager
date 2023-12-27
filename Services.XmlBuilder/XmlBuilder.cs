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
        private ClientCollection clientCollection;
        public void ExportClientCollectionToHtmlFile(ClientCollection clientCollection)
        {
            this.clientCollection = clientCollection;
            ExportXmlTextToFile(clientCollection);
        }
        private void ExportXmlTextToFile(ClientCollection clientCollection)
        {
            XmlWriter xmlWriter = getDir();

            foreach (var client in clientCollection)
            {
                writeClient(xmlWriter, client);
            }

            CloseDocument(xmlWriter);
        }

        private static void CloseDocument(XmlWriter xmlWriter)
        {
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private static XmlWriter getDir()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = "Kunden",
                DefaultExt = ".xml",

                Filter = "XML (*.xml)|*.xml",
        };
            Nullable<bool> result = sfd.ShowDialog();
            string dir = sfd.FileName;
            XmlWriterSettings settings = WriterSettings();
            XmlWriter xmlWriter = XmlWriter.Create(dir, settings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("clients");
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
            xmlWriter.WriteStartElement("Kunde");
            xmlWriter.WriteAttributeString("clientID", client.Id.ToString());
            writeElement(xmlWriter, "Name", client.Name);
            writeElement(xmlWriter, "Straße", client.Street);
            writeElement(xmlWriter, "Hausnummer", client.HouseNumber.ToString());
            writeElement(xmlWriter, "PLZ", client.ZipCode.ToString());
            writeElement(xmlWriter, "Ort", client.City);
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
