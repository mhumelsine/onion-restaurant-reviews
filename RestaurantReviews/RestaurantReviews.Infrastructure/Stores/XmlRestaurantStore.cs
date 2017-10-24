using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using Isf.XC;
using RestaurantReviews.Core.DTOs;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace RestaurantReviews.Infrastructure.Stores
{
    public class XmlRestaurantStore : IRestaurantStore
    {
        private XElement list;
        private string path;
        private string namespaceUrl;
        private const string RESTAURANT_LIST = "RestaurantList",
            RESTAURANT = "Restaurant";

        public XmlRestaurantStore(string path = @"C:\temp\data\restaurants")
        {
            this.path = path;
            this.namespaceUrl = typeof(Restaurant).AssemblyQualifiedName;

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            this.list = XElement.Load(path);
        }        

        public void Add(Restaurant entity)
        {
            this.list.Add(Create(entity));
        }

        public CommandResult CommitChanges()
        {
            var commandResult = new CommandResult();

            using(var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    this.list.Save(stream);                    
                    commandResult.DidComplete = true;
                }
                catch (Exception ex)
                {
                    commandResult.Exception = ex;                    
                }                
            }

            return commandResult;
        }

        public void Delete(string id)
        {
            var itemToDelete = this.list.Elements("Restaurant")              
                .Single(x => (string)x.Element("Id") == id);

            itemToDelete.Remove();
        }

        public IEnumerable<Restaurant> Find(RestaurantSearch search)
        {
            return this.list.Elements("Restaurant")
                .Where(x => string.IsNullOrWhiteSpace(search.Name) || ((string)x.Element("Name")).StartsWith(search.Name))
                .Where(x => string.IsNullOrWhiteSpace(search.City) || ((string)x.Element("City")).StartsWith(search.City))
                .Select(x => Create(x))
                .ToList();
        }

        public Restaurant Find(string id)
        {
            var node = this.list.Elements("Restaurant")
                .Single(x => (string)x.Element("Id") == id);

            return Create(node);                
        }

        private Restaurant Create(XElement x)
        {
            return new Restaurant
            {
                Id = (string)x.Element("Id"),
                Name = (string)x.Element("Name"),
                City = (string)x.Element("City"),
                Country = (string)x.Element("Country")
            };
        }

        private XElement Create(Restaurant entity)
        {
            return new XElement("Restaurant",
                new XElement("Id", entity.Id),
                new XElement("Name", entity.Name),
                new XElement("City", entity.City),
                new XElement("Country", entity.Country));
        }

        public void Update(Restaurant entity)
        {
            this.Delete(entity.Id);
            this.Add(entity);
        }
    }
}
