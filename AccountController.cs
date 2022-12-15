using Carwash_web_api.Models;
using Carwash_web_api.Repository;
using System;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Carwash_web_api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountRepository _accountRepository;
        public AccountController()
        {
            this._accountRepository = new AccountRepository(new CarwashEntities());
        }
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult VerifyLogin(UserTable objlogin)
        {
            UserTable user = null;
            try
            {
                user = _accountRepository.VerifyLogin(objlogin.Email,objlogin.Password);
                if(user != null) 
                {
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
            }
            return NotFound();

        }
    }
}
