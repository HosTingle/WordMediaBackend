using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Repositories.UserRoleRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet("{id}GetByUserRoleId")] 
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _userRoleRepository.GetUserRoleId(id);
            return Ok(value);
        }
    }

}
