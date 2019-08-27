/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 13, 2019
LAST MODIFIED ON    :   Aug 27, 2019
DESCRIPTION         :   JWTAuth Controller
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using JWT_Authentication.Models;
using JWT_Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT_Authentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JWTAuthController : ControllerBase
    {
        #region VARIABLE
        private readonly IJWTAuthService _service;
        #endregion

        #region CONSTRUCTOR
        public JWTAuthController(IJWTAuthService service)
        {
            _service = service;
        }
        #endregion

        #region METHODS

        // POST: api/JWTAuth/Authenticate
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody]User user)
        {
            var result = _service.Authenticate(user.Username, user.Password);
            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(result);
        }

        // GET: api/JWTAuth
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<User> result = new List<User>();

            if (User.IsInRole(Enums.Role.Admin.ToString()))
            {
                result = await _service.GetAll();
            }

            else if (User.IsInRole(Enums.Role.Admin.ToString()) || User.IsInRole(Enums.Role.Manager.ToString()))
            {
                result = await _service.GetManager();
            }

            else
            {
                result = await _service.GetUser();
            }

            return Ok(result);
        }

        // GET: api/JWTAuth/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User result = new Models.User();

            if (User.IsInRole(Enums.Role.Admin.ToString()))
            {
                result = await _service.FindAsync(id);
            }

            if (User.IsInRole(Enums.Role.Manager.ToString()))
            {
                result = await _service.GetManager(id);
            }

            if (User.IsInRole(Enums.Role.User.ToString()))
            {
                result = await _service.GetUser(id);
            }

            return Ok(result);
        }

        // POST: api/JWTAuth
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                await _service.Add(user);

                return CreatedAtAction("Get", new { id = user.UserId }, user);
            }
            catch (DbUpdateException)
            {
                if (_service.FindAsync(user.UserId) != null)
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
        }

        // PUT: api/JWTAuth/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                await _service.Put(id, user);
                return CreatedAtAction("Get", new { id = user.UserId }, user);
            }
            catch (DbUpdateException)
            {
                if (_service.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/JWTAuth/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var result = await _service.Delete(user);

            return Ok(user);
        }

        #endregion
    }
}