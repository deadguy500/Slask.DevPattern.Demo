using AutoMapper;
using Slask.Domain.Contract;
using Slask.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Slask.Domain.Contract.Models;

namespace Slask.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();
            var model = _mapper.Map<List<UserModel>>(users);

            return View(model);
        }

        public async Task<ActionResult> Inspect(Guid? id)
        {
            if (!id.HasValue || id.Equals(Guid.Empty))
            {
                return Redirect("Index");
            }

            var user = await _userService.GetUserAsync(id.Value);
            var model = _mapper.Map<UserModel>(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await _userService.AddUserAsync(user);

            return Redirect("Index");
        }
    }
}