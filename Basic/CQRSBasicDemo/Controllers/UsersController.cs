namespace CQRSBasicDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CQRSBasicDemo.Domains.Users.Commands;
    using CQRSBasicDemo.Infrastructure;
    using CQRSBasicDemo.Reporting.Users;
    using CQRSBasicDemo.Reporting.Users.Queries;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public UsersController(IDispatcher dispatcher)
        {
            this._dispatcher = dispatcher;
        }

        // GET api/users?type=1
        [HttpGet]
        public async Task<IEnumerable<string>> Get([FromQuery]int type = 1)
        {
            if (type == 1)
            {
                var rd = new Random();
                var createUser = new CreateUser($"catcher-{rd.Next(1, 9999)}");
                await _dispatcher.SendAsync(createUser);
                return new string[] { "value1", "value2" };
            }
            else
            {
                var getUserById = new GetUserById(1);
                var user = await _dispatcher.GetResultAsync<GetUserById, GetUserByIdVm>(getUserById);
                return new string[] { "value1", "value2", user.Name };
            }
        }
    }
}
