using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Dtos.UserDtos;
using wordmedia.Repositories.UserRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("getallUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var values = await _userRepository.GetAllUser();
            return Ok(values);
        }
        [HttpPost("CreatUser")]
        public async Task<IActionResult> CreatUser(CreateUserDto userDto) 
        {
            _userRepository.CreatUser(userDto);
            return Ok("User Oluşturuldu");
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok("User başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto userDto)
        {
            _userRepository.UpdateUser(userDto);
            return Ok("User başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByUserId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _userRepository.GetUserId(id);
            return Ok(value);
        }
        [HttpGet("{id}GetByUserWithOtherId")]
        public async Task<IActionResult> GetAllUserWithOther()
        {
            var value = await _userRepository.GetAllUserWithOther();
            return Ok(value);
        }
    }
}
