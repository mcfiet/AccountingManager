using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Services.XmlImport
{
    public class XmlImport
    {
        public ClientCollection ImportClients()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml|Alle Dateien|*.*";
            ofd.ShowDialog();
            var path = ofd.FileName;
            XElement XmlClients = XElement.Parse("<empty>empty</empty>");
            try
            {
                XmlClients = XElement.Load(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Falsche XML-Sytax: \n" + e);
            }

            ClientCollection clients = new ClientCollection();

            foreach (XElement XmlClient in XmlClients.Elements("Kunde")) 
            {
                string elementValue = XmlClient.Value;
                Client client = new Client();
                client.Id = int.Parse(XmlClient.Attribute("clientID").Value);
                client.Name = XmlClient.Element("Name").Value;
                XElement clientAddress = XmlClient.Element("Adresse");
                client.Street = clientAddress.Element("Straße").Value;
                client.HouseNumber = int.Parse(clientAddress.Element("Hausnummer").Value);
                client.ZipCode = int.Parse(clientAddress.Element("PLZ").Value);
                client.City = clientAddress.Element("Ort").Value;
                clients.Add(client);
            }
            return clients;
        }
    }
}
