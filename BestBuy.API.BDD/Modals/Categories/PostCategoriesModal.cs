using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.Categories
{
    class PostCategoriesModal
    {
        public string name { get; set; }
        public string id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PostCategoriesModal modal &&
                   name == modal.name &&
                   id == modal.id;
        }

        public override int GetHashCode()
        {
            int hashCode = 1289958070;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            return hashCode;
        }
    }
}
