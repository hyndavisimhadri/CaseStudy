using Carwash_web_api.Models;
using Carwash_web_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Carwash_web_api.Controllers
{
    [RoutePrefix("api/User")]

    public class UserController : ApiController
    {
        IDataRepository<UserTable> _dataRepository;
        public UserController()
        {
            this._dataRepository = new UserRepository(new CarwashEntities());  
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<UserTable>GetAllusers()
        {
            var users = _dataRepository.GetAll();
            return users;   
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(UserTable user)
        {
            UserTable userObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _dataRepository.Add(user);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Data Saved");
        }
    }
}
    

