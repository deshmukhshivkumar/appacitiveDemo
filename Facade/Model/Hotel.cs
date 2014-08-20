using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Model
{
    public class Hotel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public Address Address;
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public List<string> GeoCode { get; set; }
        public long Id { get; set; }
        public City City;

    }

    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}
