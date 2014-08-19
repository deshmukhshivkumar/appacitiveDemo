using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppacitiveRepository;
using Appacitive_demo.Models;
using Model = Facade.Model;

namespace Appacitive_demo.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        public async Task<ActionResult> Index()
        {
            try
            {
                AppacitiveRepository.HotelRepository hotelRepository = new HotelRepository();
                var modelHotelList = new List<Hotel>();
                var hotelList = await hotelRepository.GetHotels();
                foreach (var hotel in hotelList)
                {
                    modelHotelList.Add(new Hotel()
                    {
                        Name = hotel.Name,
                        StarRating = hotel.StarRating,
                        Address = hotel.Address == null ? new Address() : new Address()
                        {
                            AddressLine = hotel.Address.AddressLine ?? "",
                            Id = hotel.Address.Id,
                            City = new City()
                            {
                                Name = hotel.Address.City.Name ?? "",
                                Id = hotel.Address.City.Id
                            }
                        }
                    });
                }
                return View(modelHotelList);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotel/Create
        [HttpPost]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            try
            {
                AppacitiveRepository.HotelRepository hotelRepository = new HotelRepository();
                Model.Hotel facadeHotel = new Model.Hotel();
                facadeHotel.Id = 1;
                facadeHotel.Name = hotel.Name;
                facadeHotel.StarRating = hotel.StarRating;

                await hotelRepository.Create(facadeHotel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
