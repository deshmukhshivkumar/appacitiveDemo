using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appacitive.Sdk;
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
            apiHotel.Id = hotel.Id + 1;
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
    }
}
