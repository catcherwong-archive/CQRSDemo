namespace BasicDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BasicDemo.Models;
    using BasicDemo.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            this._userRepo = userRepo;
        }

        // GET api/users?type=1
        [HttpGet]
        public async Task<IEnumerable<string>> Get([FromQuery]int type = 1)
        {
            if (type == 1)
            {
                var rd = new Random();
                var user = new User { Name = $"catcher-{rd.Next(1, 9999)}" };
                await _userRepo.CreateAsync(user);
                return new string[] { "value1", "value2" };
            }
            else
            {
                var user = await _userRepo.GetByIdAsync(1);
                return new string[] { "value1", "value2", user.Name };
            }
        }
    }
}
