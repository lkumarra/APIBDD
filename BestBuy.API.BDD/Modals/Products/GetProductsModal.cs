using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.GetProducts
{
    class GetProductsModal
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<Datum> data { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetProductsModal modal &&
                   total == modal.total &&
                   limit == modal.limit &&
                   skip == modal.skip &&
                   data.SequenceEqual(modal.data);
        }

        public override int GetHashCode()
        {
            int hashCode = -1462670464;
            hashCode = hashCode * -1521134295 + total.GetHashCode();
            hashCode = hashCode * -1521134295 + limit.GetHashCode();
            hashCode = hashCode * -1521134295 + skip.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Datum>>.Default.GetHashCode(data);
            return hashCode;
        }
    }

    class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   id == category.id &&
                   name == category.name &&
                   createdAt == category.createdAt &&
                   updatedAt == category.updatedAt;
        }

        public override int GetHashCode()
        {
            int hashCode = 1799605657;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            return hashCode;
        }
    }

    class Datum
    {
        public long id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public string upc { get; set; }
        public decimal shipping { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public List<Category> categories { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Datum datum &&
                   id == datum.id &&
                   name == datum.name &&
                   type == datum.type &&
                   price == datum.price &&
                   upc == datum.upc &&
                   shipping == datum.shipping &&
                   description == datum.description &&
                   manufacturer == datum.manufacturer &&
                   model == datum.model &&
                   url == datum.url &&
                   image == datum.image &&
                   createdAt == datum.createdAt &&
                   updatedAt == datum.updatedAt &&
                   categories.SequenceEqual(datum.categories);
        }

        public override int GetHashCode()
        {
            int hashCode = -538890732;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(upc);
            hashCode = hashCode * -1521134295 + shipping.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(url);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Category>>.Default.GetHashCode(categories);
            return hashCode;
        }
    }
}
