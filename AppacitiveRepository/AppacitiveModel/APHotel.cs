using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appacitive.Sdk;

namespace AppacitiveRepository.AppacitiveModel
{
    public class APHotel : APObject
    {
        protected APHotel(APObject existing)
            : base(existing)
        {

        }

        public APHotel(string type)
            : base(type)
        {

        }

        public APHotel(string type, string id)
            : base(type, id)
        {

        }


        public string name
        {
            get { return base.Get<string>("name"); }
            set { base.Set("name", value); }
        }

        public int starrating
        {
            get { return base.Get<int>("starrating"); }
            set { base.Set("starrating", value); }
        }

        public string id
        {
            get { return base.Get<string>("_id"); }
            set { base.Set("_id", value); }
        }
    }
}
