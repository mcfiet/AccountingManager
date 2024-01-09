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
            XElement XmlClients = loadXmlFile();

            ClientCollection clients = new ClientCollection();

            foreach (XElement XmlClient in XmlClients.Elements("client"))
            {
                Client client = new Client();
                client.Id = int.Parse(XmlClient.Attribute("clientID").Value);
                client.FirstName = XmlClient.Element("name").Value;
                XElement clientAddress = XmlClient.Element("adress");
                client.Street = clientAddress.Element("street").Value;
                client.HouseNumber = int.Parse(clientAddress.Element("housenumber").Value);
                client.ZipCode = int.Parse(clientAddress.Element("zipcode").Value);
                client.City = clientAddress.Element("city").Value;
                clients.Add(client);
            }
            return clients;
        }
        public ArticleCollection ImportArticles()
        {
            XElement XmlArticles = loadXmlFile();

            ArticleCollection articles = new ArticleCollection();

            foreach (XElement XmlArticle in XmlArticles.Elements("article"))
            {
                Article article = new Article();
                article.Id = int.Parse(XmlArticle.Attribute("articleID").Value);
                article.Name = XmlArticle.Element("Name").Value;
                article.Description = XmlArticle.Element("Description").Value;
                article.Price = int.Parse(XmlArticle.Element("Price").Value);
                articles.Add(article);
            }
            return articles;
        }

        private static XElement loadXmlFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml|Alle Dateien|*.*";
            Nullable<bool> result = ofd.ShowDialog();
            string dir = ofd.FileName;
            XElement XmlElement = XElement.Parse("<empty>empty</empty>");
            try
            {
                XmlElement = XElement.Load(dir);
            }
            catch (Exception e)
            {
                Console.WriteLine("Falsche XML-Sytax: \n" + e);
            }

            return XmlElement;
        }
    }
}
