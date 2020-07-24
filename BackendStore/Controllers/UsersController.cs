using BackendStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendStore.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult GetUsers()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var users = context.Users.ToList();
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult GetUser(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = context.Users.FirstOrDefault(n => n.Id == id);
                    if (user == null) return NotFound();
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
