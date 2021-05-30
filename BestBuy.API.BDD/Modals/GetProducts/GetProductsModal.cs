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
                   EqualityComparer<List<Datum>>.Default.Equals(data, modal.data);
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
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public string upc { get; set; }
        public int shipping { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<Category> categories { get; set; }
    }
}
