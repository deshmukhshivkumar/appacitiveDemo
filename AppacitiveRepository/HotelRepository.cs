using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appacitive.Sdk;
using Appacitive.Sdk.Services;
using AppacitiveRepository.AppacitiveModel;
using Model = Facade.Model;

namespace AppacitiveRepository
{
    public class HotelRepository
    {
        public async Task<bool> Create(Model.Hotel hotel)
        {
            var apiHotel = new APHotel("hotel");
            apiHotel.name = hotel.Name;
            apiHotel.starrating = hotel.StarRating;
            try
            {
                await apiHotel.SaveAsync();
                //var conn = await APConnection.New("hotel")
                //    .ToNewObject("hotel", apiHotel)
                //    .SaveAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public async Task<List<Model.Hotel>> List()
        {
            var hotelList = new List<Model.Hotel>();
            var apiHotel = new APObject("hotel");



            return hotelList;
        }

        public async Task<List<Model.Hotel>> GetHotels()
        {

            var results = await APObjects.FindAllAsync("hotel");
            var hotelList = new List<Model.Hotel>();
            var listIds = new List<string>();
            foreach (APObject apObject in results)
            {
                //hotelList.Add(new Model.Hotel()
                //{
                //    Name = apObject.Get<string>("name"),
                //    StarRating = apObject.Get<int>("starrating"),
                //    Id = Convert.ToInt64(apObject.Id)

                //});
                listIds.Add(apObject.Id);
            }

            var graphApiResult = await Graph.Select("getallhotelswithaddress", listIds);

            graphApiResult.ForEach(node =>
            {
                var hotel = node.Object.ToHotel();
                var address = node.GetChildren("address").SingleOrDefault();
                if (address != null)
                {
                    var city = address.GetChildren("city").SingleOrDefault();
                    hotel.Address = address.Object.ToAddress();
                    hotel.Address.City = city.Object.ToCity();
                }
                hotelList.Add(hotel);
            });
            return hotelList;
        }
    }
}
