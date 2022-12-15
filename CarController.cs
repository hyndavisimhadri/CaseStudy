using Carwash_web_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Carwash_web_api.Models;

namespace Carwash_web_api.Controllers
{
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {
        IDataRepository<Car> _carRepository;
        public CarController()
        {
            this._carRepository = new CarRepository(new CarwashEntities());
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<Car> GetCars() 
        {
            var Car = _carRepository.GetAll();
            return Car;
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCar(Car car) 
        {
            try
            {
              if(!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _carRepository.Add(car);
            }
            catch (Exception e)
            {
            }
            return Ok("Car Added");
        }
    }
}
