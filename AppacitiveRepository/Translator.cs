using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appacitive.Sdk;
using Facade.Model;

namespace AppacitiveRepository
{
    internal static class Translator
    {
        public static Hotel ToHotel(this APObject obj)
        {
            return new Hotel()
            {
                Id = Convert.ToInt64(obj.Id),
                Name = obj.Get<string>("name"),
                StarRating = obj.Get<int>("starrating")

            };
        }

        public static Address ToAddress(this APObject obj)
        {
            return new Address()
            {
                AddressLine = obj.Get<string>("addressline"),
                Id = Convert.ToInt64(obj.Id)
            };

        }

        public static City ToCity(this APObject obj)
        {
            return new City()
            {
                Name = obj.Get<string>("name"),
                Id = Convert.ToInt64(obj.Id)
            };

        }
    }
}
