using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Modals.Strores
{
    public class GetStoresModal
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<Datum> data { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GetStoresModal modal &&
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

    public class Storeservices
    {
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public long storeId { get; set; }
        public long serviceId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Storeservices storeservices &&
                   createdAt == storeservices.createdAt &&
                   updatedAt == storeservices.updatedAt &&
                   storeId == storeservices.storeId &&
                   serviceId == storeservices.serviceId;
        }

        public override int GetHashCode()
        {
            int hashCode = -2049617609;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            hashCode = hashCode * -1521134295 + storeId.GetHashCode();
            hashCode = hashCode * -1521134295 + serviceId.GetHashCode();
            return hashCode;
        }
    }

    public class Service
    {
        public long id { get; set; }
        public string name { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public Storeservices storeservices { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   id == service.id &&
                   name == service.name &&
                   createdAt == service.createdAt &&
                   updatedAt == service.updatedAt &&
                   EqualityComparer<Storeservices>.Default.Equals(storeservices, service.storeservices);
        }

        public override int GetHashCode()
        {
            int hashCode = -722911933;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<Storeservices>.Default.GetHashCode(storeservices);
            return hashCode;
        }
    }

    public class Datum
    {
        public long id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string hours { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public List<Service> services { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Datum datum &&
                   id == datum.id &&
                   name == datum.name &&
                   type == datum.type &&
                   address == datum.address &&
                   address2 == datum.address2 &&
                   city == datum.city &&
                   state == datum.state &&
                   zip == datum.zip &&
                   lat == datum.lat &&
                   lng == datum.lng &&
                   hours == datum.hours &&
                   createdAt == datum.createdAt &&
                   updatedAt == datum.updatedAt &&
                   services.SequenceEqual(datum.services);
        }

        public override int GetHashCode()
        {
            int hashCode = -1067660065;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address2);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(city);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(state);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(zip);
            hashCode = hashCode * -1521134295 + lat.GetHashCode();
            hashCode = hashCode * -1521134295 + lng.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(hours);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(createdAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(updatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Service>>.Default.GetHashCode(services);
            return hashCode;
        }
    }
}
