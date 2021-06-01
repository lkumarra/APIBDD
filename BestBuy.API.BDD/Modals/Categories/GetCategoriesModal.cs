using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.Categories
{
    public class GetCategoriesModal
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<Datum> data { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetCategoriesModal modal &&
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

    public class SubCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SubCategory category &&
                   id == category.id &&
                   name == category.name &&
                   createdAt == category.createdAt &&
                   updatedAt == category.updatedAt;
        }
    }

    public class CategoryPath
    {
        public string id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryPath path &&
                   id == path.id &&
                   name == path.name &&
                   createdAt == path.createdAt &&
                   updatedAt == path.updatedAt;
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

    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public List<SubCategory> subCategories { get; set; }
        public List<CategoryPath> categoryPath { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Datum datum &&
                   id == datum.id &&
                   name == datum.name &&
                   createdAt == datum.createdAt &&
                   updatedAt == datum.updatedAt &&
                   subCategories.SequenceEqual(datum.subCategories) &&
                   categoryPath.SequenceEqual(datum.categoryPath);
        }

        public override int GetHashCode()
        {
            int hashCode = 1357889944;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<SubCategory>>.Default.GetHashCode(subCategories);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CategoryPath>>.Default.GetHashCode(categoryPath);
            return hashCode;
        }
    }
}
