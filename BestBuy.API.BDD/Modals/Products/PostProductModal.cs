using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.Products
{
    class PostProductModal
    {
        public string name { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public decimal shipping { get; set; }
        public string upc { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string url { get; set; }
        public string image { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PostProductModal modal &&
                   name == modal.name &&
                   type == modal.type &&
                   price == modal.price &&
                   shipping == modal.shipping &&
                   upc == modal.upc &&
                   description == modal.description &&
                   manufacturer == modal.manufacturer &&
                   model == modal.model &&
                   url == modal.url &&
                   image == modal.image;
        }

        public override int GetHashCode()
        {
            int hashCode = 1841150284;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            hashCode = hashCode * -1521134295 + shipping.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(upc);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(url);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(image);
            return hashCode;
        }
    }
}
