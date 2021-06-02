using System.Collections.Generic;
using System.Linq;

namespace BestBuy.API.BDD.Modals.Services
{
    class GetServicesModal
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<Datum> data { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetServicesModal modal &&
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

    public class Datum
    {
        public long id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Datum datum &&
                   id == datum.id &&
                   name == datum.name &&
                   createdAt == datum.createdAt &&
                   updatedAt == datum.updatedAt;
        }

        public override int GetHashCode()
        {
            int hashCode = 1799605657;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            return hashCode;
        }
    }

}
